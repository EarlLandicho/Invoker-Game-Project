using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private float distanceX;
    [SerializeField] private float duration;
    private MovementFlip playerMovementFlip;
    private bool isReversed;

    private void Awake()
    {
        playerMovementFlip = GameObject.Find("Player").GetComponent<MovementFlip>();

        if (!playerMovementFlip.GetIsFacingRight())
        {
            distanceX *= -1;
        }


    }

    private void Start()
    {
        Debug.Log(isReversed);
        if (isReversed)
        {
            LeanTween.moveX(gameObject, gameObject.transform.position.x - distanceX, duration).setEaseOutQuad()
                     .setOnComplete(OnComplete);
        }
        else
        {
            LeanTween.moveX(gameObject, gameObject.transform.position.x + distanceX, duration).setEaseOutQuad()
                     .setOnComplete(OnComplete);
        }
    }

    public void SetIsReversed()
    {
        isReversed = true;
    }

    private void OnComplete()
    {
        Debug.Log("check");
        Destroy(gameObject);
    }
}
