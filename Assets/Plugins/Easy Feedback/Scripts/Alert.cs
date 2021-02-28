using EasyFeedback.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EasyFeedback
{
	/// <summary>
	/// Alert popup window for submitting/submitted notifications.
	/// </summary>
	public class Alert : MonoBehaviour
	{
		[SerializeField] private Text unityText = null;
		[SerializeField] private TMP_Text tmpText = null;

		private IText text;

		private bool initialized = false;

		private void Awake()
		{
			// set IText from Unity or TMP text
			text = UIInterop.GetText(unityText, tmpText);
			if (text == null)
			{
				Debug.LogError(
					"[Easy Feedback] Alert popup is missing text element!"
				);
			}

			initialized = true;
		}

		/// <summary>
		/// Shows the form with the provided message
		/// </summary>
		public void Show(string message)
		{
			if (!initialized) Awake();

			text.Text = message;
			gameObject.SetActive(true);
		}

		public void Hide() { gameObject.SetActive(false); }
	}
}