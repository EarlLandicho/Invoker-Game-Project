using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDash : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    [SerializeField] private float dashDistance;
    [SerializeField] private float wallImpactCushion = .1f;
    [SerializeField] private float yHitboxSize = .1f;

    private Transform playerTransform;
    private MovementFlip movementFlip;

    private Vector3 startingPosition;
    private Vector3 endingPosition;

    void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        movementFlip = GameObject.Find("Player").GetComponent<MovementFlip>();

        startingPosition = playerTransform.transform.position;

        FindTeleportPosition();
        DealDamageInPath();
    }

    private void FindTeleportPosition()
    {
        if(!movementFlip.GetIsFacingRight())
        {
            dashDistance = -dashDistance;
            wallImpactCushion = -wallImpactCushion;
        }



        RaycastHit2D hit = Physics2D.CircleCast(startingPosition, .1f, 
            movementFlip.GetIsFacingRight() ? playerTransform.transform.right : -playerTransform.transform.right, 
            dashDistance, 1 << LayerMask.NameToLayer("Ground"));

        if(hit.collider == null)
        {
            playerTransform.transform.position = startingPosition + new Vector3(dashDistance + -wallImpactCushion, 0);
        }
        else
        {
            playerTransform.transform.position = hit.point + new Vector2(-wallImpactCushion, 0);
        }
        
        endingPosition = playerTransform.transform.position;

        Destroy(gameObject);
    }


    private void DealDamageInPath()
    {
        float xHitboxSize = endingPosition.x - startingPosition.x;

        Collider2D[] enemies = Physics2D.OverlapBoxAll(new Vector2(startingPosition.x + xHitboxSize / 2f, yHitboxSize),
            new Vector2(Mathf.Abs(xHitboxSize), yHitboxSize), 0,
            1 << LayerMask.NameToLayer("Enemy"));

        if (enemies.Length > 0)
        {
            foreach(Collider2D enemyCol in  enemies)
            {
                enemyCol.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            }

        }
    }
}
