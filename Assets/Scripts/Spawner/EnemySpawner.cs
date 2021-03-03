using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

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

    private List<GameObject> enemiesSpawnedList = new List<GameObject>();

    private void Awake()
    {
        battlefieldTrigger.PlayerTriggered += BeginSpawning;

        if (initialEnemy.Length == 0)
        {
            initialSpawnerDone = true;
        }

        if (continuousEnemy.Length == 0)
        {
            continuousSpawnerDone = true;
        }

    }

    private void Update()
    {
        if (initialSpawnerDone && continuousSpawnerDone)
        {
            
            if (EnemySpawnedListHasAllNullElements())
            {
                EnemiesKilledInBattleField();
                ResetInitialValues();
            }
        }

        if (enemyCounterContinuous >= continuousEnemy.Length && !continuousSpawnerDone)
        {
            continuousSpawnerDone = true;
            CancelInvoke("SpawnEnemyContinuous");
            return;
        }

        if (enemyCounterInitial >= initialEnemy.Length && !initialSpawnerDone)
        {
            initialSpawnerDone = true;
            CancelInvoke("SpawnEnemyInitial");
            return;
        }
    }

    private void ResetInitialValues()
    {
        initialSpawnerDone = false;
        continuousSpawnerDone = false;
        enemyCounterInitial = 0;
        enemyCounterContinuous = 0;
    }

    private bool EnemySpawnedListHasAllNullElements()
    {
        foreach(GameObject obj in enemiesSpawnedList)
        {
            if(obj != null)
            {
                return false;
            }

        }
        return true;
    }

    private void BeginSpawning()
    {
        InvokeRepeating("SpawnEnemyInitial", spawnSpeedInitialEnemy, spawnSpeedInitialEnemy);
        InvokeRepeating("SpawnEnemyContinuous", spawnSpeedContinuousEnemy, spawnSpeedContinuousEnemy);
    }

    private void SpawnEnemyInitial()
    {
        int randomNum = UnityEngine.Random.Range(0, spawnPoints.Length);

        GameObject currentObject;
        currentObject = Instantiate(initialEnemy[enemyCounterInitial], spawnPoints[randomNum], transform.rotation);
        enemiesSpawnedList.Add(currentObject);
        currentObject.GetComponent<EnemyHealth>().SetisFromSpawner(true);
        enemyCounterInitial++;

    }

    private void SpawnEnemyContinuous()
    {
        int randomNum = UnityEngine.Random.Range(0, spawnPoints.Length);

        GameObject currentObject;
        currentObject = Instantiate(continuousEnemy[enemyCounterContinuous], spawnPoints[randomNum], transform.rotation);
        enemiesSpawnedList.Add(currentObject);
        currentObject.GetComponent<EnemyHealth>().SetisFromSpawner(true);
        enemyCounterContinuous++;
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