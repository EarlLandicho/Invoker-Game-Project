using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private Color enemyColorTemp;

    private void Awake()
    {
        enemyColorTemp = enemy.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enemy.GetComponent<SpriteRenderer>().color = new Color(0f, 0.501f, 0.070f);
            Instantiate(enemy, transform.position, transform.rotation);
            enemy.GetComponent<SpriteRenderer>().color = enemyColorTemp;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            enemy.GetComponent<SpriteRenderer>().color = new Color(0.501f, 0.011f, 0f);
            Instantiate(enemy, transform.position, transform.rotation);
            enemy.GetComponent<SpriteRenderer>().color = enemyColorTemp;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            enemy.GetComponent<SpriteRenderer>().color = new Color(0.501f, 0.294f, 0f);
            Instantiate(enemy, transform.position, transform.rotation);
            enemy.GetComponent<SpriteRenderer>().color = enemyColorTemp;
        }
    }
}