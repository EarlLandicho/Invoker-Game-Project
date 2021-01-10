using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector2 offSet;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = player.transform.position + (Vector3)offSet;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(offSet, .01f);
    }
}