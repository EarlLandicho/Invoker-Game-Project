using System;
using UnityEngine;

public class BoulderDestroy : MonoBehaviour
{
    //used by BuilderAOEDamage
    public event Action BoulderDestroyed = delegate { };

    [SerializeField] private GameObject explosionAnimation;

    //prevents multiple collisions therefore preventing multiple calls to OnTriggerEnter2D
    private bool isColliding;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isColliding)
        {
            return;
        }
        isColliding = true;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")
            || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            BoulderDestroyed();
            Instantiate(explosionAnimation, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        isColliding = false;
    }
}