using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public static int numberOfEnemiesSpawned;
    public event Action EnemiesKilledInBattleField = delegate { };

    [SerializeField] private BattlefieldTrigger battlefieldTrigger;
    [SerializeField] private float spawnSpeedInitialEnemy;
    [SerializeField] private float spawnSpeedContinuousEnemy;
    [SerializeField] private GameObject[] initialEnemy;
    [SerializeField] private GameObject[] continuousEnemy;
    [SerializeField] private Vector2[] spawnPoints;

    private int enemyCounterInitial;
    private int enemyCounterContinuous;

    private bool initialSpawnerDone;
    private bool continuousSpawnerDone;

    void Awake()
    {
        battlefieldTrigger.PlayerTriggered += BeginSpawning;

        if(initialEnemy.Length == 0)
        {
            initialSpawnerDone = true;
        }


        if (continuousEnemy.Length == 0)
        {
            continuousSpawnerDone = true;
        }
    }

    void Update()
    {
        if(initialSpawnerDone && continuousSpawnerDone && numberOfEnemiesSpawned <= 0)
        {
            EnemiesKilledInBattleField();

            initialSpawnerDone = false;
            continuousSpawnerDone = false;
            enemyCounterInitial = 0;
            enemyCounterContinuous = 0;
            numberOfEnemiesSpawned = 0;
        }

    }

    private void BeginSpawning()
    {
        InvokeRepeating("SpawnEnemyInitial", spawnSpeedInitialEnemy, spawnSpeedInitialEnemy);
        InvokeRepeating("SpawnEnemyContinuous", spawnSpeedContinuousEnemy, spawnSpeedContinuousEnemy);
    }

    private void SpawnEnemyInitial()
    {
        if (enemyCounterInitial >= initialEnemy.Length)
        {
            CancelInvoke("SpawnEnemyInitial");
            return;
        }

        int randomNum = UnityEngine.Random.Range(0, spawnPoints.Length);

        GameObject currentObject;
        currentObject = Instantiate(initialEnemy[enemyCounterInitial], spawnPoints[randomNum], transform.rotation);
        currentObject.GetComponent<EnemyHealth>().SetisFromSpawner(true);
        enemyCounterInitial++;
        numberOfEnemiesSpawned++;
        initialSpawnerDone = true;
    }

    private void SpawnEnemyContinuous()
    {
        if (enemyCounterContinuous >= continuousEnemy.Length)
        {
            CancelInvoke("SpawnEnemyContinuous");
            return;
        }

        int randomNum = UnityEngine.Random.Range(0, spawnPoints.Length);

        GameObject currentObject;
        currentObject = Instantiate(continuousEnemy[enemyCounterContinuous], spawnPoints[randomNum], transform.rotation);
        currentObject.GetComponent<EnemyHealth>().SetisFromSpawner(true);
        enemyCounterContinuous++;
        numberOfEnemiesSpawned++;
        continuousSpawnerDone = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (Vector2 i in spawnPoints)
        {
            Gizmos.DrawWireSphere(i, .05f);
        }
    }
}