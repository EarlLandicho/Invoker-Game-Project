using System;
using System.Collections;
using System.IO;
using EasyFeedback.APIs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyFeedback
{
    public class FeedbackForm : MonoBehaviour
    {
        public static bool formIsOpened;

        [Tooltip("Easy Feedback configuration file")]
        public EFConfig Config;

        [Tooltip("Key to toggle feedback window")]
        public KeyCode FeedbackKey = KeyCode.F12;

        [Tooltip("Include screenshot with reports?")]
        public bool IncludeScreenshot = true;

        public Transform Form;

        public Alert Alert;

        /// <summary name="OnFormOpened">
        /// Called when the form is first opened, right before it is shown on screen
        /// </summary>
        [Tooltip("Functions to be called when the form is first opened")]
        public UnityEvent OnFormOpened;

        /// <summary name="OnFormSubmitted">
        /// Called right before the report is sent to Trello
        /// </summary>
        [Tooltip("Functions to be called when the form is submitted")]
        public UnityEvent
            OnFormSubmitted; // called before report is sent to Trello, so that any information in the form can be added

        /// <summary name="OnFormClosed">
        /// Called when the form is closed, whether or not it was submitted
        /// </summary>
        [Tooltip("Functions to be called when the form is closed")]
        public UnityEvent OnFormClosed;

        /// <summary>
        /// The current report being built.
        /// Will be sent as next report
        /// </summary>
        public Report CurrentReport;

        private CursorLockMode initCursorLockMode;

        private bool initCursorVisible;

        // form metadata
        private string screenshotPath;

        private Coroutine ssCoroutine;

        private bool submitting;

        // api handler
        private Trello trello;

        /// <summary>
        /// Whether or not the form is currently being displayed
        /// </summary>
        [HideInInspector]
        public bool IsOpen
        {
            get { return Form.gameObject.activeSelf; }
        }


        public void Awake()
        {
            if (!Config.StoreLocal)
                InitTrelloAPI();

            // initialize current report
            InitCurrentReport();
        }

        // Update is called once per frame
        private void Update()
        {
            // show form when player hits F12
            if (Input.GetKeyDown(FeedbackKey)
                && !IsOpen
                && ssCoroutine == null)
            {
                Show();
                
            }
            
            else if ((Input.GetKeyDown(FeedbackKey) ||
                      Input.GetKeyDown(KeyCode.Escape)
                     ) // close form if f12 is hit again,  or escape is hit
                     && IsOpen
                     && !submitting)
            {
                Hide();
            }
        }

        public void InitTrelloAPI()
        {
            // initialize api handler
            trello = new Trello(Config.Token);
        }

        /// <summary>
        /// Replaces currentReport with a new instance of Report
        /// </summary>
        private void InitCurrentReport()
        {
            CurrentReport = new Report();
        }

        /// <summary>
        /// Takes a screenshot, then opens the form
        /// </summary>
        public void Show()
        {
            if (!IsOpen && ssCoroutine == null)
            {
                formIsOpened = true;
                PauseGame();
                ssCoroutine = StartCoroutine(ScreenshotAndOpenForm());
            }

        }

        /// <summary>
        /// Called by the submit button, submits the form.
        /// </summary>
        public void Submit()
        {
            StartCoroutine(SubmitAsync());
        }

        private void ShowAlert(string message)
        {
            Alert.Show(message);
            ReleaseMouse();
        }

        public void HideAlert()
        {
            HideMouse();
            Alert.Hide();
        }

        private IEnumerator SubmitAsync()
        {
            // disable form
            DisableForm();

            submitting = true;

            // show submitting alert
            ShowAlert("Submitting...");

            // call OnFormSubmitted
            OnFormSubmitted.Invoke();


            if (!Config.StoreLocal)
            {
                // add card to board
                yield return trello.AddCard(
                    CurrentReport.Title ?? "[no summary]",
                    CurrentReport.ToString() ?? "[no detail]",
                    CurrentReport.Labels,
                    CurrentReport.List.id,
                    CurrentReport.Screenshot
                );

                // send up attachments 
                if (trello.LastAddCardResponse != null && !trello.UploadError)
                    yield return attachFilesAsync(
                        trello.LastAddCardResponse.id
                    );
            }
            else
            {
                // store entire report locally, then return
                var localPath = WriteLocal(CurrentReport);
                Debug.Log(localPath);
            }

            // close form
            Hide();

            if (!Config.StoreLocal && trello.UploadError)
            {
                // preserve report locally if there's an issue during upload
                Debug.Log(WriteLocal(CurrentReport));

                ShowAlert(
                    "Error: Failed to upload report!\n " + trello.ErrorMessage
                );
                if (trello.UploadException != null)
                    Debug.LogException(trello.UploadException);
                else
                    Debug.LogError(trello.ErrorMessage);
            }
            else
            {
                ShowAlert("Feedback submitted successfully!");
            }

            submitting = false;
            InitCurrentReport();
        }

        /// <summary>
        /// Attaches files on current report to card
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        private IEnumerator attachFilesAsync(string cardID)
        {
            for (var i = 0; i < CurrentReport.Attachments.Count; i++)
            {
                var attachment = CurrentReport.Attachments[i];
                yield return trello.AddAttachmentAsync(
                    cardID, attachment.Data, null, attachment.Name
                );

                if (trello.UploadError) // failed to add attachment
                    ShowAlert(
                        "Error: Failed to attach file to report!\n" +
                        trello.ErrorMessage
                    );
            }
        }

        /// <summary>
        /// Saves the report in a local directory
        /// </summary>
        private string WriteLocal(Report report)
        {
            // create the report directory
            var feedbackDirectory = Application.persistentDataPath +
                                    "/feedback-" +
                                    DateTime.Now.ToString("MMddyyyy-HHmmss");
            Directory.CreateDirectory(feedbackDirectory);

            // save the report
            File.WriteAllText(
                feedbackDirectory + "/report.txt", report.GetLocalFileText()
            );

            // save screenshot
            File.WriteAllBytes(
                feedbackDirectory + "/screenshot.png", report.Screenshot
            );

            // save attachments
            for (var i = 0; i < report.Attachments.Count; i++)
            {
                var attachment = report.Attachments[i];
                File.WriteAllBytes(
                    feedbackDirectory + "/" + attachment.Name, attachment.Data
                );
            }

            return feedbackDirectory;
        }

        /// <summary>
        /// Disables all the Selectable elements on the form.
        /// </summary>
        public void DisableForm()
        {
            foreach (Transform child in Form)
            {
                var selectable = child.GetComponent<Selectable>();
                if (selectable != null) selectable.interactable = false;
            }
        }

        /// <summary>
        /// Enables all the Selectable elements on the form.
        /// </summary>
        public void EnableForm()
        {
            foreach (Transform child in Form)
            {
                var selectable = child.GetComponent<Selectable>();
                if (selectable != null) selectable.interactable = true;
            }
        }

        /// <summary>
        /// Hides the form, called by the Close button.
        /// </summary>
        public void Hide()
        {
            // don't do anything if the form is already hidden
            if (!Form.gameObject.activeInHierarchy)
                return;

            // hide form
            Form.gameObject.SetActive(false);
            formIsOpened = false;
            UnpauseGame();

            // delete temporary screenshot
            if (!Config.StoreLocal && IncludeScreenshot
                                   && File.Exists(screenshotPath))
            {
                if (ssCoroutine != null) StopCoroutine(ssCoroutine);

                File.Delete(screenshotPath);
            }

            screenshotPath = string.Empty;

            // clear screenshot coroutine
            ssCoroutine = null;

            // call OnFormClosed
            OnFormClosed.Invoke();
        }

        /// <param name="preserveState"></param>
        private void ReleaseMouse()
        {
            // show mouse
            initCursorVisible = Cursor.visible;
            initCursorLockMode = Cursor.lockState;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void HideMouse()
        {
            Cursor.visible = initCursorVisible;
            Cursor.lockState = initCursorLockMode;
        }

        private IEnumerator ScreenshotAndOpenForm()
        {
            if (IncludeScreenshot)
            {
                // take screenshot before showing the form
                var filename = "debug-" +
                               DateTime.Now.ToString("MMddyyyy-HHmmss") +
                               ".png";
                screenshotPath = Path.Combine(
                    Application.persistentDataPath, filename
                );

#if UNITY_2017_1_OR_NEWER && !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
				ScreenCapture.CaptureScreenshot(filename);
#elif UNITY_2017_1_OR_NEWER
                ScreenCapture.CaptureScreenshot(screenshotPath);
#elif !UNITY_EDITOR && UNITY_IOS || UNITY_ANDROID
				Application.CaptureScreenshot(filename);
#else
				Application.CaptureScreenshot(screenshotPath);
#endif

                // wait to confirm that screenshot has been taken before moving on
                // (so we don't get the form in the screenshot)
                while (!File.Exists(screenshotPath)) yield return null;

                // add binary data to report
                const int readAttempts = 5;
                const float timeout = 0.1f;
                Exception exception = null;
                for (var i = 0; i < readAttempts; i++)
                {
                    try
                    {
                        CurrentReport.Screenshot =
                            File.ReadAllBytes(screenshotPath);
                        break;
                    }
                    catch (IOException e)
                    {
                        Debug.LogErrorFormat(
                            "[Easy Feedback] IOException on screenshot read attempt {0}",
                            i + 1
                        );
                        Debug.LogException(e);
                    }
                    catch (Exception e)
                    {
                        Debug.LogErrorFormat(
                            "[Easy Feedback] Unexpected error on screenshot read attempt {0}",
                            i + 1
                        );
                        Debug.LogException(e);
                        exception = e;
                        break;
                    }

                    yield return new WaitForSeconds(timeout);
                }

                if (CurrentReport.Screenshot == null && exception != null)
                    ShowAlert(
                        "Error: Failed to capture screenshot!\nSee log for more detail."
                    );
            }

            ReleaseMouse();

            // show form
            EnableForm();
            Form.gameObject.SetActive(true);

            // call OnFormOpened
            OnFormOpened.Invoke();
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void UnpauseGame()
        {
            Time.timeScale = 1;
        }
    }

}