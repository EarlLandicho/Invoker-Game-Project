using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextStage : MonoBehaviour
{
    private float lastLevelSceneIndex = 2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && GetComponent<CloseAndOpenDoor>().GetDoorOpenCloseState())
        {
            if (SceneManager.GetActiveScene().buildIndex == lastLevelSceneIndex)
            {
                Time.timeScale = 0;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}