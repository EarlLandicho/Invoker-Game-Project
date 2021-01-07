using System;
using System.Collections;
using UnityEngine;

//S = earth spirit
//L = water spirit
//G = air spirit

[RequireComponent(typeof(SpiritInput))]
public class SpiritCast : MonoBehaviour
{
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
        solarFlare,
        wings,
        bubble,
        trampoline,
        reseter;

    [SerializeField]
    private float boulderCd,
        icicleCd,
        lightningCd,
        earthArmorCd,
        slowHealCd,
        lightningDashCd,
        mudGolemCd,
        fireSpiritCd,
        poisonExplosionCd,
        groundSlamCd,
        hibernateCd,
        tornadoCd,
        lavaBurstCd,
        wispCd,
        solarFlareCd,
        wingsCd,
        bubbleCd,
        trampolineCd,
        reseterCd;

    private float boulderTimer,
        icicleTimer,
        lightningTimer,
        earthArmorTimer,
        slowHealTimer,
        lightningDashTimer,
        mudGolemTimer,
        fireSpiritTimer,
        poisonExplosionTimer,
        groundSlamTimer,
        hibernateTimer,
        tornadoTimer,
        lavaBurstTimer,
        wispTimer,
        solarFlareTimer,
        wingsTimer,
        bubbleTimer,
        trampolineTimer,
        reseterTimer;

    private bool boulderIsOffCd = true,
        icicleIsOffCd = true,
        lightningIsOffCd = true,
        earthArmorIsOffCd = true,
        slowHealIsOffCd = true,
        lightningDashIsOffCd = true,
        mudGolemIsOffCd = true,
        fireSpiritIsOffCd = true,
        poisonExplosionIsOffCd = true,
        groundSlamIsOffCd = true,
        hibernateIsOffCd = true,
        tornadoIsOffCd = true,
        lavaBurstIsOffCd = true,
        wispIsOffCd = true,
        solarFlareIsOffCd = true,
        wingsIsOffCd = true,
        bubbleIsOffCd = true,
        trampolineIsOffCd = true,
        reseterIsOffCd = true;

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

        boulderTimer = boulderCd;
        icicleTimer = icicleCd;
        lightningTimer = lightningCd;
        earthArmorTimer = earthArmorCd;
        slowHealTimer = slowHealCd;
        lightningDashTimer = lightningCd;
        mudGolemTimer = mudGolemCd;
        fireSpiritTimer = fireSpiritCd;
        poisonExplosionTimer = poisonExplosionCd;
        groundSlamTimer = groundSlamCd;
        hibernateTimer = hibernateCd;
        tornadoTimer = tornadoCd;
        lavaBurstTimer = lavaBurstCd;
        wispTimer = wispCd;
        solarFlareTimer = solarFlareCd;
        wingsTimer = wingsCd;
        bubbleTimer = bubbleCd;
        trampolineTimer = trampolineCd;
        reseterTimer = reseterCd;


    }

    void Update()
    {
        CheckSpellCooldowns();
    }

    public bool GetBoulderIsOffCd()
    {
        return boulderIsOffCd;
    }

    public bool GetIcicleIsOffCd()
    {
        return icicleIsOffCd;
    }

    public bool GetLightningIsOffCd()
    {
        return lightningIsOffCd;
    }

    public bool GetEarthArmorIsOffCd()
    {
        return earthArmorIsOffCd;
    }

    public bool GetSlowHealIsOffCd()
    {
        return slowHealIsOffCd;
    }

    public bool GetLightningDashIsOffCd()
    {
        return lightningDashIsOffCd;
    }

    public bool GetMudGolemIsOffCd()
    {
        return mudGolemIsOffCd;
    }

    public bool GetFireSpiritIsOffCd()
    {
        return fireSpiritIsOffCd;
    }

    public bool GetPoisonExplosionIsOffCd()
    {
        return poisonExplosionIsOffCd;
    }

    public bool GetGroundSlamIsOffCd()
    {
        return groundSlamIsOffCd;
    }

    public bool GetHibernateIsOffCd()
    {
        return hibernateIsOffCd;
    }

    public bool GetTornadoIsOffCd()
    {
        return tornadoIsOffCd;
    }

    public bool GetLavaBurstIsOffCd()
    {
        return lavaBurstIsOffCd;
    }

    public bool GetWispIsOffCd()
    {
        return wispIsOffCd;
    }

    public bool GetSolarFlareisOffCd()
    {
        return solarFlareIsOffCd;
    }

    public bool GetWingsIsOffCd()
    {
        return wingsIsOffCd;
    }

    public bool GetBubbleIsOffCd()
    {
        return bubbleIsOffCd;
    }

    public bool GetTrampolineIsOffCd()
    {
        return trampolineIsOffCd;
    }

    public bool GetReseterIsOfCd()
    {
        return reseterIsOffCd;
    }

    public void ResetAllCooldowns()
    {
        boulderTimer = boulderCd;
        icicleTimer = icicleCd;
        lightningTimer = lightningCd;
        earthArmorTimer = earthArmorCd;
        slowHealTimer = slowHealCd;
        lightningDashTimer = lightningCd;
        mudGolemTimer = mudGolemCd;
        fireSpiritTimer = fireSpiritCd;
        poisonExplosionTimer = poisonExplosionCd;
        groundSlamTimer = groundSlamCd;
        hibernateTimer = hibernateCd;
        tornadoTimer = tornadoCd;
        lavaBurstTimer = lavaBurstCd;
        wispTimer = wispCd;
        solarFlareTimer = solarFlareCd;
        wingsTimer = wingsCd;
        bubbleTimer = bubbleCd;
        trampolineTimer = trampolineCd;
        reseterTimer = reseterCd;

        boulderIsOffCd = true;
        icicleIsOffCd = true;
        lightningIsOffCd = true;
        earthArmorIsOffCd = true;
        slowHealIsOffCd = true;
        lightningDashIsOffCd = true;
        mudGolemIsOffCd = true;
        fireSpiritIsOffCd = true;
        poisonExplosionIsOffCd = true;
        groundSlamIsOffCd = true;
        hibernateIsOffCd = true;
        tornadoIsOffCd = true;
        lavaBurstIsOffCd = true;
        wispIsOffCd = true;
        solarFlareIsOffCd = true;
        wingsIsOffCd = true;
        bubbleIsOffCd = true;
        trampolineIsOffCd = true;
        reseterIsOffCd = true;
    }

    private void CheckSpellCooldowns()
    {
        if (!boulderIsOffCd)
        {
            if (boulderTimer > 0)
            {
                boulderTimer -= Time.deltaTime;
            }
            else
            {
                boulderIsOffCd = true;
            }
        }

        if (!icicleIsOffCd)
        {
            if (icicleTimer > 0)
            {
                icicleTimer -= Time.deltaTime;
            }
            else
            {
                icicleIsOffCd = true;
            }
        }

        if (!lightningIsOffCd)
        {
            if (lightningTimer > 0)
            {
                lightningTimer -= Time.deltaTime;
            }
            else
            {
                lightningIsOffCd = true;
            }
        }

        if (!earthArmorIsOffCd)
        {
            if (earthArmorTimer > 0)
            {
                earthArmorTimer -= Time.deltaTime;
            }
            else
            {
                earthArmorIsOffCd = true;
            }
        }

        if (!slowHealIsOffCd)
        {
            if (slowHealTimer > 0)
            {
                slowHealTimer -= Time.deltaTime;
            }
            else
            {
                slowHealIsOffCd = true;
            }
        }

        if (!lightningDashIsOffCd)
        {
            if (lightningDashTimer > 0)
            {
                lightningDashTimer -= Time.deltaTime;
            }
            else
            {
                lightningDashIsOffCd = true;
            }
        }

        if (!mudGolemIsOffCd)
        {
            if (mudGolemTimer > 0)
            {
                mudGolemTimer -= Time.deltaTime;
            }
            else
            {
                mudGolemIsOffCd = true;
            }
        }

        if (!fireSpiritIsOffCd)
        {
            if (fireSpiritTimer > 0)
            {
                fireSpiritTimer -= Time.deltaTime;
            }
            else
            {
                fireSpiritIsOffCd = true;
            }
        }

        if (!poisonExplosionIsOffCd)
        {
            if (poisonExplosionTimer > 0)
            {
                poisonExplosionTimer -= Time.deltaTime;
            }
            else
            {
                poisonExplosionIsOffCd = true;
            }
        }

        if (!groundSlamIsOffCd)
        {
            if (groundSlamTimer > 0)
            {
                groundSlamTimer -= Time.deltaTime;
            }
            else
            {
                groundSlamIsOffCd = true;
            }
        }

        if (!hibernateIsOffCd)
        {
            if (hibernateTimer > 0)
            {
                hibernateTimer -= Time.deltaTime;
            }
            else
            {
                hibernateIsOffCd = true;
            }
        }

        if (!tornadoIsOffCd)
        {
            if (tornadoTimer > 0)
            {
                tornadoTimer -= Time.deltaTime;
            }
            else
            {
                tornadoIsOffCd = true;
            }
        }

        if (!lavaBurstIsOffCd)
        {
            if (lavaBurstTimer > 0)
            {
                lavaBurstTimer -= Time.deltaTime;
            }
            else
            {
                lavaBurstIsOffCd = true;
            }
        }

        if (!wispIsOffCd)
        {
            if (wispTimer > 0)
            {
                wispTimer -= Time.deltaTime;
            }
            else
            {
                wispIsOffCd = true;
            }
        }

        if (!solarFlareIsOffCd)
        {
            if (solarFlareTimer > 0)
            {
                solarFlareTimer -= Time.deltaTime;
            }
            else
            {
                solarFlareIsOffCd = true;
            }
        }

        if (!wingsIsOffCd)
        {
            if (wingsTimer > 0)
            {
                wingsTimer -= Time.deltaTime;
            }
            else
            {
                wingsIsOffCd = true;
            }
        }

        if (!bubbleIsOffCd)
        {
            if (bubbleTimer > 0)
            {
                bubbleTimer -= Time.deltaTime;
            }
            else
            {
                bubbleIsOffCd = true;
            }
        }

        if (!trampolineIsOffCd)
        {
            if (trampolineTimer > 0)
            {
                trampolineTimer -= Time.deltaTime;
            }
            else
            {
                trampolineIsOffCd = true;
            }
        }

        if (!reseterIsOffCd)
        {
            if (reseterTimer > 0)
            {
                reseterTimer -= Time.deltaTime;
            }
            else
            {
                reseterIsOffCd = true;
            }
        }
    }

    private void InvokeSpirits()
    {
        for (int i = 0; i < spiritArrayManagerArray.Length; i++)
        {
            if (spiritArrayManagerArray[i] == 1)
            {
                castNumber += 100;
            }
            else if (spiritArrayManagerArray[i] == 2)
            {
                castNumber += 10;
            }
            else if (spiritArrayManagerArray[i] == 3)
            {
                castNumber += 1;
            }
        }

        //PrintCastNumber();
        Cast(castNumber);
        
        castNumber = 0;
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
        if(boulderIsOffCd)
        {
            Instantiate(boulder, transform.position, player.transform.rotation);
            boulderTimer = boulderCd;
            boulderIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
    }

    private void L()
    {
        if (icicleIsOffCd)
        {
            Instantiate(icicle, transform.position, player.transform.rotation);
            icicleTimer = icicleCd;
            icicleIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
    }

    private void G()
    {
        if (lightningIsOffCd)
        {
            float yOffSet = .45f;
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 500f, LayerMask.GetMask("Ground"));
            Instantiate(lightning, hit.point + new Vector2(0, yOffSet), player.transform.rotation);

            lightningTimer = lightningCd;
            lightningIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
    }

    private void SS()
    {
        if (icicleIsOffCd)
        {
            Instantiate(earthArmor, transform.position, player.transform.rotation);
            earthArmorTimer = earthArmorCd;
            earthArmorIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }

        
    }

    private void LL()
    {
        if (slowHealIsOffCd)
        {
            Instantiate(slowHeal, transform.position, player.transform.rotation);
            slowHealTimer = slowHealCd;
            slowHealIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void GG()
    {
        if (lightningDashIsOffCd)
        {
            Instantiate(lightningDash, transform.position, player.transform.rotation);
            lightningDashTimer = lightningDashCd;
            lightningDashIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SL()
    {
        if (mudGolemIsOffCd)
        {
            Instantiate(mudGolem, transform.position, player.transform.rotation);
            mudGolemTimer = mudGolemCd;
            mudGolemIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SG()
    {
        if (fireSpiritIsOffCd)
        {
            Instantiate(fireSpirit, transform.position, player.transform.rotation);
            fireSpiritTimer = fireSpiritCd;
            fireSpiritIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void LG()
    {
        if (poisonExplosionIsOffCd)
        {
            Instantiate(poisonExplosion, transform.position, player.transform.rotation);
            poisonExplosionTimer = poisonExplosionCd;
            poisonExplosionIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SSS()
    {
        if (groundSlamIsOffCd)
        {
            Instantiate(groundSlam, transform.position, player.transform.rotation);
            groundSlamTimer = groundSlamCd;
            groundSlamIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void LLL()
    {
        if (hibernateIsOffCd)
        {
            Instantiate(hibernate, transform.position, player.transform.rotation);
            hibernateTimer = hibernateCd;
            hibernateIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void GGG()
    {
        if (tornadoIsOffCd)
        {
            Instantiate(tornado, transform.position, player.transform.rotation);
            tornadoTimer = tornadoCd;
            tornadoIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SSL()
    {
        if (lavaBurstIsOffCd)
        {
            Instantiate(lavaBurst, transform.position, player.transform.rotation);
            lavaBurstTimer = lavaBurstCd;
            lavaBurstIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SSG()
    {
        if (wispIsOffCd)
        {
            Instantiate(wisp, transform.position, player.transform.rotation);
            wispTimer = wispCd;
            wispIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SLL()
    {
        if (solarFlareIsOffCd)
        {
            Instantiate(solarFlare, transform.position, player.transform.rotation);
            solarFlareTimer = solarFlareCd;
            solarFlareIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SGG()
    {
        if (wingsIsOffCd)
        {
            Instantiate(wings, transform.position, player.transform.rotation);
            wingsTimer = wingsCd;
            wingsIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void LLG()
    {
        if (bubbleIsOffCd)
        {
            Instantiate(bubble, transform.position, player.transform.rotation);
            bubbleTimer = bubbleCd;
            bubbleIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void LGG()
    {
        if (trampolineIsOffCd)
        {
            Instantiate(trampoline, transform.position, player.transform.rotation);
            trampolineTimer = trampolineCd;
            trampolineIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
    }

    private void SLG()
    {
        if (reseterIsOffCd)
        {
            Instantiate(reseter, transform.position, player.transform.rotation);
            reseterTimer = reseterCd;
            reseterIsOffCd = false;
            spiritArrayManager.ClearSpirits();
        }
        else
        {
            Debug.Log("Still cooling down");
        }
        
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