using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeKeyAnimation : MonoBehaviour
{
    [SerializeField] private float animationTimeDelay;
    private float animationTimeDelayTemp;
    private bool isAnimating;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animationTimeDelayTemp = animationTimeDelay;

        LeanTween.moveY(gameObject, gameObject.transform.position.y + .1f, 1f).setEaseInOutSine().setLoopPingPong();

    }

    void Update()
    {
        if(!isAnimating)
        {
            if (animationTimeDelayTemp > 0)
            {
                animationTimeDelayTemp -= Time.deltaTime;
            }
            else
            {
                animationTimeDelayTemp = animationTimeDelay;
                AnimateRandomIdle();
            }
        }

    }

    // Called in Animator
    public void DisableIsAnimating()
    {
        isAnimating = false;
    }

    private void AnimateRandomIdle()
    {
        float randomNum = Random.Range(0f, 1f);
        if(randomNum >= 0 && randomNum < .33f)
        {
            animator.SetTrigger("idle1");
        }
        else if(randomNum >= .33f && randomNum < .66f)
        {
            animator.SetTrigger("idle2");
        }
        else if(randomNum >= .66f && randomNum < 1f)
        {
            animator.SetTrigger("idle3");
        }
        isAnimating = true;

    }









}
