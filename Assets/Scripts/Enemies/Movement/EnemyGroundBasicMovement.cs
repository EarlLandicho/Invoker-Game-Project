using UnityEngine;

public class EnemyGroundBasicMovement : EnemyMovement
{
    [SerializeField] private Transform cliffCheck;
    [SerializeField] private Transform wallCheck;

    private bool willGoRight;

    protected override void Awake()
    {
        base.Awake();
        TurnToPlayerDirection();
    }

    private void Update()
    {
        CliffCheck();
        WallCheck();

        if (!isXMovementSpeedLocked)
        {
            Move();
        }
    }

    // Called in Animator
    public void TurnToPlayerDirection()
    {
        if (PlayerIsOnTheRight())
        {
            willGoRight = true;
        }
        else
        {
            willGoRight = false;
        }
    }

    private void Move()
    {
        if (willGoRight)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
    }

    private void CliffCheck()
    {
        if (!(Physics2D.OverlapCircle(new Vector2(cliffCheck.position.x, cliffCheck.position.y), 0.03f, 1 << LayerMask.NameToLayer("Ground"))
            || Physics2D.OverlapCircle(new Vector2(cliffCheck.position.x, cliffCheck.position.y), 0.03f, 1 << LayerMask.NameToLayer("Ledge"))))
        {
            willGoRight = !willGoRight;
        }
    }

    private void WallCheck()
    {
        if (Physics2D.OverlapCircle(new Vector2(wallCheck.position.x, wallCheck.position.y), 0.03f, 1 << LayerMask.NameToLayer("Ground")))
        {
            willGoRight = !willGoRight;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(cliffCheck.position, 0.03f);
        Gizmos.DrawWireSphere(wallCheck.position, 0.03f);
    }
}