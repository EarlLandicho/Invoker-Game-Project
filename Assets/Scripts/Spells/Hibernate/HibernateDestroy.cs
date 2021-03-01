using System.Collections;
using UnityEngine;

public class HibernateDestroy : MonoBehaviour
{
    [SerializeField] private float duration = 0;
    [SerializeField] private GameObject[] shards;
    [SerializeField] private int numberOfShards;
    [SerializeField] private float shardsLaunchForce;


    private void Awake()
    {
        StartCoroutine("HibernateDuration");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }

    private IEnumerator HibernateDuration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    public float GetDuration()
    {
        return duration;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < numberOfShards; i++)
        {
            int randomShardNum = Random.Range(0, shards.Length);
            float randomForceAmount = Random.Range(shardsLaunchForce - 70, shardsLaunchForce + 70);

            Instantiate(shards[randomShardNum], transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce((Quaternion.AngleAxis((Random.Range(0, 180)), Vector3.forward).normalized * new Vector2(randomForceAmount, 0)));
        }
    }
}