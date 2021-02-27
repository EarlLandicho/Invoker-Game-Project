using System.Collections;
using UnityEngine;

public class HibernateDestroy : MonoBehaviour
{
    [SerializeField] private float duration = 0;

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
}