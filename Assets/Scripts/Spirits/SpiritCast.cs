using System;
using System.Collections;
using UnityEngine;

//S = earth spirit
//L = water spirit
//G = air spirit

[RequireComponent(typeof(SpiritInput))]
public class SpiritCast : MonoBehaviour
{
    public event Action SpiritsHaveBeenCasted = delegate { };

    [SerializeField] private float spiritCooldown = 5;
    [SerializeField] 
    private GameObject boulder,
        icicle,
        lightning,
        earthArmor,
        slowHeal,
        lightningDash,
        mudGolem,
        fireSpirit,
        poisonExplosion,
        groundSlam,
        hibernate,
        tornado,
        lavaBurst,
        wisp,
        solarFlare;





    private GameObject player;
    private SpiritArrayManager spiritArrayManager;
    private int[] spiritArrayManagerArray;
    private int castNumber = 0;

    private void Awake()
    {
        GetComponent<SpiritInput>().InvokeSpiritsButtonPressed += InvokeSpirits;

        spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
        spiritArrayManagerArray = spiritArrayManager.GetSpiritArray();

        player = GameObject.Find("Player");
    }

    //Uses all spirits up. Sends an event that tells SpiritCast what to cast. Will set castNumber to 0.
    //Will coolddown the used spirits
    private void InvokeSpirits()
    {
        for (int i = 0; i < spiritArrayManagerArray.Length; i++)
        {
            if (spiritArrayManagerArray[i] == 1)
            {
                spiritArrayManager.DecrementSpiritCurrentAmount(1);
                castNumber += 100;
                CooldownSpirit(1);
            }
            else if (spiritArrayManagerArray[i] == 2)
            {
                spiritArrayManager.DecrementSpiritCurrentAmount(2);
                castNumber += 10;
                CooldownSpirit(2);
            }
            else if (spiritArrayManagerArray[i] == 3)
            {
                spiritArrayManager.DecrementSpiritCurrentAmount(3);
                castNumber += 1;
                CooldownSpirit(3);
            }
        }

        //PrintCastNumber();
        Cast(castNumber);
        SpiritsHaveBeenCasted();
        castNumber = 0;
    }

    private void CooldownSpirit(int spiritNum)
    {
        if (spiritNum == 1)
        {
            StartCoroutine("SpiritCooldown", 1);
        }
        else if (spiritNum == 2)
        {
            StartCoroutine("SpiritCooldown", 2);
        }
        else if (spiritNum == 3)
        {
            StartCoroutine("SpiritCooldown", 3);
        }
    }

    private IEnumerator SpiritCooldown(int spirit)
    {
        yield return new WaitForSeconds(spiritCooldown);
        if (spirit == 1)
        {
            spiritArrayManager.IncrementSpiritCurrentAmount(1);
        }
        else if (spirit == 2)
        {
            spiritArrayManager.IncrementSpiritCurrentAmount(2);
        }
        else if (spirit == 3)
        {
            spiritArrayManager.IncrementSpiritCurrentAmount(3);
        }
    }

    private void Cast(int castNum)
    {
        //Debug.Log($"Casted {castNum}");
        switch (castNum)
        {
            case 100:
                S();
                break;

            case 10:
                L();
                break;

            case 1:
                G();
                break;

            case 200:
                SS();
                break;

            case 20:
                LL();
                break;

            case 2:
                GG();
                break;

            case 110:
                SL();
                break;

            case 101:
                SG();
                break;

            case 11:
                LG();
                break;

            case 300:
                SSS();
                break;

            case 30:
                LLL();
                break;

            case 3:
                GGG();
                break;

            case 210:
                SSL();
                break;

            case 201:
                SSG();
                break;

            case 120:
                SLL();
                break;

            case 102:
                SGG();
                break;

            case 21:
                LLG();
                break;

            case 12:
                LGG();
                break;

            case 111:
                SLG();
                break;

            default:
                Debug.Log("Nothing casted");
                break;
        }
    }

    private void S()
    {
        Instantiate(boulder, transform.position, player.transform.rotation);
    }

    private void L()
    {
        Instantiate(icicle, transform.position, player.transform.rotation);
    }

    private void G()
    {
        float yOffSet = .45f;
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 500f, LayerMask.GetMask("Ground"));
        Instantiate(lightning, hit.point + new Vector2(0, yOffSet), player.transform.rotation);
    }

    private void SS()
    {
        Instantiate(earthArmor, transform.position, player.transform.rotation);
    }

    private void LL()
    {
        Instantiate(slowHeal, transform.position, player.transform.rotation);
    }

    private void GG()
    {
        Instantiate(lightningDash, transform.position, player.transform.rotation);
    }

    private void SL()
    {
        Instantiate(mudGolem, transform.position, player.transform.rotation);
    }

    private void SG()
    {
        Instantiate(fireSpirit, transform.position, player.transform.rotation);
    }

    private void LG()
    {
        Instantiate(poisonExplosion, transform.position, player.transform.rotation);
    }

    private void SSS()
    {
        Instantiate(groundSlam, transform.position, player.transform.rotation);
    }

    private void LLL()
    {
        Instantiate(hibernate, transform.position, player.transform.rotation);
    }

    private void GGG()
    {
       Instantiate(tornado, transform.position, player.transform.rotation);
    }

    private void SSL()
    {
        Instantiate(lavaBurst, transform.position, player.transform.rotation);
    }

    private void SSG()
    {
        Instantiate(wisp, transform.position, player.transform.rotation);
    }

    private void SLL()
    {
        Instantiate(solarFlare, transform.position, player.transform.rotation);
    }

    private void SGG()
    {
    }

    private void LLG()
    {
    }

    private void LGG()
    {
    }

    private void SLG()
    {
    }

    private void PrintCastNumber()
    {
        Debug.LogFormat("Cast Number is {0}", castNumber);
    }

    private void PrintSpiritArray()
    {
        Debug.LogFormat("Current Array: [ {0}, {1}, {2} ]", spiritArrayManagerArray[0], spiritArrayManagerArray[1], spiritArrayManagerArray[2]);
    }
}