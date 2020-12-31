using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }
}