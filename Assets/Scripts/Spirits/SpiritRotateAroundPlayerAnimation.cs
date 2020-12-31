using UnityEngine;

public class SpiritRotateAroundPlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameObject spirit1;
    [SerializeField] private GameObject spirit2;
    [SerializeField] private GameObject spirit3;
    [SerializeField] private float spiritRotateSpeed = 3f;
    [SerializeField] private float spiritRotationRadius = .1f;

    private float spiritRotationAngle = 0;

    private float oneThirdOfACircle;
    private float twoThirdsOfACircle;

    private void Awake()
    {
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
        spirit1.transform.position = transform.position + new Vector3(Mathf.Sin(spiritRotationAngle), Mathf.Sin(spiritRotationAngle), Mathf.Cos(spiritRotationAngle)) * spiritRotationRadius;
        spirit2.transform.position = transform.position + new Vector3(Mathf.Sin(spiritRotationAngle + oneThirdOfACircle), Mathf.Cos(spiritRotationAngle + oneThirdOfACircle), Mathf.Cos(spiritRotationAngle + oneThirdOfACircle)) * spiritRotationRadius;
        spirit3.transform.position = transform.position + new Vector3(Mathf.Sin(spiritRotationAngle + twoThirdsOfACircle), Mathf.Cos(spiritRotationAngle), Mathf.Cos(spiritRotationAngle + twoThirdsOfACircle)) * spiritRotationRadius;
    }
}