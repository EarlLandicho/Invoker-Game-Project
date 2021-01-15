using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLifetime : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private float lifeTImeTemp;

    void Awake()
    {
        lifeTImeTemp = lifeTime;
    }


    void Update()
    {
        if (lifeTImeTemp > 0)
        {
            lifeTImeTemp -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
