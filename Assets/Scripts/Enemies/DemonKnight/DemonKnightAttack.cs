using UnityEngine;

//SUGGESTION: Maybe split this up to different classes?
public class DemonKnightAttack : MonoBehaviour, IEnemyAttack, IReactToPlayerSeen
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private float attackSpeed = 1;
    private float attackSpeedTimer;
    private GameObject player;
    private Rigidbody2D rb;
    private float speed;

    //bool so that enemy turns off reacting to attack
    private bool isReacting = false;

    //bool to loop in Update so that attack speed work
    private bool isAttacking = false;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GetComponent<EnemyMovement>().GetMovementSpeed();

        if (GetComponent<EnemyPatrol>() != null)
        {
            enemyPatrol = GetComponent<EnemyPatrol>();
        }
    }

    private void Update()
    {
        ChasePlayerCheck();
        AttackLoop();
    }

    public void SetLockAttack(bool isLocked)
    {

    }

    //Called by EnemyAttackRange
    public void Attack(GameObject player)
    {
        isReacting = false;
        isAttacking = true;
        StopHere();
    }

    private void AttackLoop()
    {
        if (isAttacking)
        {
            if (attackSpeedTimer <= 0)
            {
                attackSpeedTimer = 1 / attackSpeed;
                LaunchFireball();
            }
            else
            {
                attackSpeedTimer -= Time.deltaTime;
            }
        }
    }

    //Called by EnemyAttackRange
    public void OutOfAttackRange()
    {
        isReacting = true;
        isAttacking = false;
    }

    //Called by EnemyPatrol
    public void ReactToPlayerSeen(GameObject player)
    {
        isReacting = true;
        this.player = player;
        StopHere();
        //turn off EnemyPatrol
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = false;
        }
    }

    //Called by EnemyPatrol
    public void ReactToPlayerNoLongerSeen()
    {
        isReacting = false;
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = true;
        }
    }

    private void LaunchFireball()
    {
        Instantiate(fireball, transform.position, transform.rotation);
    }

    private void ChasePlayerCheck()
    {
        if (isReacting && !isAttacking)
        {
            if (transform.position.x - player.transform.position.x > .1f)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (transform.position.x - player.transform.position.x < -.1f)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else
        {
        }
    }

    private void StopHere()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}