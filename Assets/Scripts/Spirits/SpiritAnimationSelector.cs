using UnityEngine;

[RequireComponent(typeof(SpiritInput))]
public class SpiritAnimationSelector : MonoBehaviour
{
    //SpriteRenderers of the child sprite objects
    [SerializeField] private SpriteRenderer spiritPosition1SpriteRenderer;

    [SerializeField] private SpriteRenderer spiritPosition2SpriteRenderer;
    [SerializeField] private SpriteRenderer spiritPosition3SpriteRenderer;

    [SerializeField] private Sprite spirit1Sprite;
    [SerializeField] private Sprite spirit2Sprite;
    [SerializeField] private Sprite spirit3Sprite;

    private SpiritArrayManager spiritArrayManager;
    private int[] spiritArrayManagerArray;

    private void Awake()
    {
        GetComponent<SpiritInput>().UpdateSpiritAnimation += UpdateRotatingSpirits;
    }

    private void Start()
    {
        spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
        spiritArrayManagerArray = spiritArrayManager.GetSpiritArray();
        spiritPosition1SpriteRenderer.enabled = false;
        spiritPosition2SpriteRenderer.enabled = false;
        spiritPosition3SpriteRenderer.enabled = false;
    }

    //called by event
    private void UpdateRotatingSpirits()
    {
        UpdateSpritePosition1();
        UpdateSpritePosition2();
        UpdateSpritePosition3();
    }

    private void UpdateSpritePosition1()
    {
        //spiritArrayManagerArray = spiritArrayManager.GetSpiritArray();
        //Debug.Log(spiritArrayManagerArray[0]);
        //Debug.Log(spiritArrayManagerArray[1]);
        //Debug.Log(spiritArrayManagerArray[2]);
        switch (spiritArrayManagerArray[0])
        {
            case 0:
                spiritPosition1SpriteRenderer.enabled = false;
                break;

            case 1:
                spiritPosition1SpriteRenderer.sprite = spirit1Sprite;
                spiritPosition1SpriteRenderer.enabled = true;
                break;

            case 2:
                spiritPosition1SpriteRenderer.sprite = spirit2Sprite;
                spiritPosition1SpriteRenderer.enabled = true;
                break;

            case 3:
                spiritPosition1SpriteRenderer.sprite = spirit3Sprite;
                spiritPosition1SpriteRenderer.enabled = true;
                break;
        }
    }

    private void UpdateSpritePosition2()
    {
        switch (spiritArrayManagerArray[1])
        {
            case 0:
                spiritPosition2SpriteRenderer.enabled = false;
                break;

            case 1:
                spiritPosition2SpriteRenderer.sprite = spirit1Sprite;
                spiritPosition2SpriteRenderer.enabled = true;
                break;

            case 2:
                spiritPosition2SpriteRenderer.sprite = spirit2Sprite;
                spiritPosition2SpriteRenderer.enabled = true;
                break;

            case 3:
                spiritPosition2SpriteRenderer.sprite = spirit3Sprite;
                spiritPosition2SpriteRenderer.enabled = true;
                break;
        }
    }

    private void UpdateSpritePosition3()
    {
        switch (spiritArrayManagerArray[2])
        {
            case 0:
                spiritPosition3SpriteRenderer.enabled = false;
                break;

            case 1:
                spiritPosition3SpriteRenderer.sprite = spirit1Sprite;
                spiritPosition3SpriteRenderer.enabled = true;
                break;

            case 2:
                spiritPosition3SpriteRenderer.sprite = spirit2Sprite;
                spiritPosition3SpriteRenderer.enabled = true;
                break;

            case 3:
                spiritPosition3SpriteRenderer.sprite = spirit3Sprite;
                spiritPosition3SpriteRenderer.enabled = true;
                break;
        }
    }
}