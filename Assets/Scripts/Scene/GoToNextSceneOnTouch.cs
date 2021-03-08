#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class GoToNextSceneOnTouch : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}