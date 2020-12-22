using System;
using UnityEngine;

public class BoulderDestroy : MonoBehaviour
{
    //used by BuilderAOEDamage
    public event Action BoulderDestroyed = delegate { };

    //prevents multiple collisions therefore preventing multiple calls to OnTriggerEnter2D
    private bool isColliding;

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
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        isColliding = false;
    }
}