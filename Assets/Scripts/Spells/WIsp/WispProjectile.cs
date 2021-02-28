using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispProjectile : MonoBehaviour
{
    [SerializeField] private float animationTime;
    
    public void GoToEnemyPosition(Vector3 enemyPosition)
    {
        LeanTween.moveX(gameObject, enemyPosition.x, animationTime).setOnComplete(OnComplete);
        LeanTween.moveY(gameObject, enemyPosition.y, animationTime).setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        Destroy(gameObject);
    }



}
