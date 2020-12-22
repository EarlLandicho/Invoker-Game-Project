using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        if(gameObject.name == "GameManager" && SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}