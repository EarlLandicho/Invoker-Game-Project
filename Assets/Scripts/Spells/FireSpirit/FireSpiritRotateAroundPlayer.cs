using UnityEngine;

public class FireSpiritRotateAroundPlayer : MonoBehaviour
{
    [SerializeField] private GameObject fireRing;

    [SerializeField] private float spiritRotationRadius;
    [SerializeField] private float spiritRotateSpeed;

    private GameObject fireRing1;
    private GameObject fireRing2;
    private GameObject fireRing3;

    private float spiritRotationAngle = 0;
    private Transform playerTransform;

    private float oneThirdOfACircle;
    private float twoThirdsOfACircle;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        fireRing1 = Instantiate(fireRing);
        fireRing2 = Instantiate(fireRing);
        fireRing3 = Instantiate(fireRing);


        oneThirdOfACircle = 4 * Mathf.PI / 6;
        twoThirdsOfACircle = 8 * Mathf.PI / 6;
    }

    private void Update()
    {
        RotateSpiritAroundPlayer();
    }

    private void RotateSpiritAroundPlayer()
    {
        spiritRotationAngle += spiritRotateSpeed * Time.deltaTime;

        if (fireRing1 != null)
        {
            fireRing1.transform.position = playerTransform.position + new Vector3(Mathf.Sin(spiritRotationAngle), Mathf.Cos(spiritRotationAngle), 0) * spiritRotationRadius;
        }
        if (fireRing2 != null)
        {
            fireRing2.transform.position = playerTransform.position + new Vector3(Mathf.Sin(spiritRotationAngle + oneThirdOfACircle), Mathf.Cos(spiritRotationAngle + oneThirdOfACircle), 0) * spiritRotationRadius;
        }
        if (fireRing3 != null)
        {
            fireRing3.transform.position = playerTransform.position + new Vector3(Mathf.Sin(spiritRotationAngle + twoThirdsOfACircle), Mathf.Cos(spiritRotationAngle + twoThirdsOfACircle), 0) * spiritRotationRadius;
        }
    }
}