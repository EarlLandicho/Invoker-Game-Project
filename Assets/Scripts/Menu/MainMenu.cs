#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class MainMenu : MonoBehaviour
{
	//Called by unity buttons
	public void LoadFirstLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}