using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnSpeed;
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private Vector2[] spawnPoints;

    private bool isActivated;
    private int enemyCounter;

    private void Awake()
    {
        
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach(Vector2 i in spawnPoints)
        {
            Gizmos.DrawWireSphere(i, .05f);
        }    
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player") && !isActivated)
        {
            isActivated = true;
            InvokeRepeating("SpawnEnemy", 0, spawnSpeed);
        }
    }

    private void SpawnEnemy()
    {
        if(enemyCounter >= enemy.Length)
        {
            CancelInvoke();
            return;
        }

        int randomNum = Random.Range(0, spawnPoints.Length);


        Instantiate(enemy[enemyCounter], spawnPoints[randomNum], transform.rotation);
        enemyCounter++;
    }
}