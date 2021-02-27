using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IcicleLaunch : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D icicleRigidbody;

    private void Awake()
    {
        icicleRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Launch(float zRotation)
    {
        transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                transform.eulerAngles.z + zRotation);
        icicleRigidbody.velocity = new Vector2(0f, speed);

        switch (zRotation)
        {
            case 90:
                icicleRigidbody.velocity = new Vector2(0f, speed);
                break;

            case -90:
                icicleRigidbody.velocity = new Vector2(0f, -speed);
                break;

            default:
                icicleRigidbody.velocity = new Vector2(speed, 0f) * transform.right;
                break;
        }
    }
}