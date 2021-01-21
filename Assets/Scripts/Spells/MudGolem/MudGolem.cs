using UnityEngine;

public class MudGolem : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float duration;

    private Rigidbody2D rigidBody;
    private Transform playerTranform;
    private bool canMove = true;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerTranform = GameObject.Find("Player").GetComponent<Transform>();

        Destroy(gameObject, duration);
    }


    void Update()
    {
        //check if golem is not moveing in the y direction with as small margin of error (between -.1 and .1)
        if(rigidBody.velocity.y > -0.1f && rigidBody.velocity.y < 0.1f)
        {
            if(playerTranform.position.x - transform.position.x > stopDistance + .1f && canMove)
            {
                rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            }
            else if(playerTranform.position.x - transform.position.x < -stopDistance - .1f && canMove)
            {
                rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }

        }
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }






}