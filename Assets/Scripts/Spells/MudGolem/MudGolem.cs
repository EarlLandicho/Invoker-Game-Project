using UnityEngine;

public class MudGolem : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float duration;
    [SerializeField] private GameObject deathAnimation;

    private Animator animator;
    private Rigidbody2D rigidBody;
    private Transform playerTranform;
    private bool canMove = true;
    private bool movementIsLocked;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerTranform = GameObject.Find("Player").GetComponent<Transform>();

        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
    }

    private void Update()
    {
        if(!movementIsLocked)
        {
            StopWhenCloseToPlayer();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ledge")
            || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetTrigger("hasTouchedGround");
            
            Destroy(gameObject, duration);
        }

    }

    private void OnDestroy()
    {
        Instantiate(deathAnimation, transform.position, transform.rotation);
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    // Called in Animator
    public void LockGolemMovement()
    {
        movementIsLocked = true;
    }

    // Called in Animator
    public void UnlockGolemMovement()
    {
        movementIsLocked = false;
    }

    private void StopWhenCloseToPlayer()
    {
        //check if golem is not moveing in the y direction with as small margin of error (between -.1 and .1)
        if (rigidBody.velocity.y > -0.1f && rigidBody.velocity.y < 0.1f)
        {
            if (playerTranform.position.x - transform.position.x > stopDistance + .1f && canMove)
            {
                rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            }
            else if (playerTranform.position.x - transform.position.x < -stopDistance - .1f && canMove)
            {
                rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }
        }
    }
}