using UnityEngine;

public class IcicleDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionAnimation;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")
            || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(explosionAnimation, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}