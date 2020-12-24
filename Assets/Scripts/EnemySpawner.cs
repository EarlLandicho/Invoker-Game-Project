using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject normalEnemy;
    [SerializeField] private GameObject poisonEnemy;
    [SerializeField] private GameObject burnEnemy;
    [SerializeField] private GameObject oilEnemy;
    


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(normalEnemy, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(poisonEnemy, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(burnEnemy, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(oilEnemy, transform.position, transform.rotation);
        }
    }





}
