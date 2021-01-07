using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellCooldownDisplay : MonoBehaviour
{

    private SpiritCast spiritCast;

    private TextMeshProUGUI boulderCd,
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

    void Awake()
    {
        spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();


        boulderCd = GameObject.Find("S").GetComponent<TextMeshProUGUI>();
        icicleCd = GameObject.Find("L").GetComponent<TextMeshProUGUI>();
        lightningCd = GameObject.Find("G").GetComponent<TextMeshProUGUI>();
        earthArmorCd = GameObject.Find("SS").GetComponent<TextMeshProUGUI>();
        slowHealCd = GameObject.Find("LL").GetComponent<TextMeshProUGUI>();
        lightningDashCd = GameObject.Find("GG").GetComponent<TextMeshProUGUI>();
        mudGolemCd = GameObject.Find("SL").GetComponent<TextMeshProUGUI>();
        fireSpiritCd = GameObject.Find("SG").GetComponent<TextMeshProUGUI>();
        poisonExplosionCd = GameObject.Find("LG").GetComponent<TextMeshProUGUI>();
        groundSlamCd = GameObject.Find("SSS").GetComponent<TextMeshProUGUI>();
        hibernateCd = GameObject.Find("LLL").GetComponent<TextMeshProUGUI>();
        tornadoCd = GameObject.Find("GGG").GetComponent<TextMeshProUGUI>();
        lavaBurstCd = GameObject.Find("SSL").GetComponent<TextMeshProUGUI>();
        wispCd = GameObject.Find("SSG").GetComponent<TextMeshProUGUI>();
        solarFlareCd = GameObject.Find("SLL").GetComponent<TextMeshProUGUI>();
        wingsCd = GameObject.Find("SGG").GetComponent<TextMeshProUGUI>();
        bubbleCd = GameObject.Find("LLG").GetComponent<TextMeshProUGUI>();
        trampolineCd = GameObject.Find("LGG").GetComponent<TextMeshProUGUI>();
        reseterCd = GameObject.Find("SLG").GetComponent<TextMeshProUGUI>();

        Debug.Log(spiritCast);
        Debug.Log(boulderCd);

    }

    void LateUpdate()
    {
        UpdateCooldownsUI();
    }

    private void UpdateCooldownsUI()
    {
        if (spiritCast.GetBoulderIsOffCd())
        {
            boulderCd.text = "S\tBoulder Throw";
        }
        else
        {
            boulderCd.text = "";
        }

        if (spiritCast.GetIcicleIsOffCd())
        {
            icicleCd.text = "L\tIcicle";
        }
        else
        {
            icicleCd.text = "";
        }

        if (spiritCast.GetLightningIsOffCd())
        {
            lightningCd.text = "G\tLightning";
        }
        else
        {
            lightningCd.text = "";
        }

        if (spiritCast.GetEarthArmorIsOffCd())
        {
            earthArmorCd.text = "SS\tEarth Armor";
        }
        else
        {
            earthArmorCd.text = "";
        }

        if (spiritCast.GetSlowHealIsOffCd())
        {
            slowHealCd.text = "LL\tSlow Heal";
        }
        else
        {
            slowHealCd.text = "";
        }

        if (spiritCast.GetLightningDashIsOffCd())
        {
            lightningDashCd.text = "GG\tLightning Dash";
        }
        else
        {
            lightningDashCd.text = "";
        }

        if (spiritCast.GetMudGolemIsOffCd())
        {
            mudGolemCd.text = "SL\tMud Golem";
        }
        else
        {
            mudGolemCd.text = "";
        }

        if (spiritCast.GetFireSpiritIsOffCd())
        {
            fireSpiritCd.text = "SG\tFireSpirit";
        }
        else
        {
            fireSpiritCd.text = "";
        }

        if (spiritCast.GetPoisonExplosionIsOffCd())
        {
            poisonExplosionCd.text = "LG\tPoisonExplosion";
        }
        else
        {
            poisonExplosionCd.text = "";
        }

        if (spiritCast.GetGroundSlamIsOffCd())
        {
            groundSlamCd.text = "SSS\tGroundSlam";
        }
        else
        {
            groundSlamCd.text = "";
        }

        if (spiritCast.GetHibernateIsOffCd())
        {
            hibernateCd.text = "LLL\tHibernate";
        }
        else
        {
            hibernateCd.text = "";
        }

        if (spiritCast.GetTornadoIsOffCd())
        {
            tornadoCd.text = "GGG\tTornado";
        }
        else
        {
            tornadoCd.text = "";
        }

        if (spiritCast.GetLavaBurstIsOffCd())
        {
            lavaBurstCd.text = "SSL\tLavaBurst";
        }
        else
        {
            lavaBurstCd.text = "";
        }

        if (spiritCast.GetWispIsOffCd())
        {
            wispCd.text = "SSG\tWisp";
        }
        else
        {
            wispCd.text = "";
        }

        if (spiritCast.GetSolarFlareisOffCd())
        {
            solarFlareCd.text = "SLL\tSolar Flare";
        }
        else
        {
            solarFlareCd.text = "";
        }

        if (spiritCast.GetWingsIsOffCd())
        {
            wingsCd.text = "SGG\tWings";
        }
        else
        {
            wingsCd.text = "";
        }

        if (spiritCast.GetBubbleIsOffCd())
        {
            bubbleCd.text = "LLG\tBubble";
        }
        else
        {
            bubbleCd.text = "";
        }

        if (spiritCast.GetTrampolineIsOffCd())
        {
            trampolineCd.text = "LGG\tTrampoline";
        }
        else
        {
            trampolineCd.text = "";
        }

        if (spiritCast.GetReseterIsOfCd())
        {
            reseterCd.text = "SLG\tReseter";
        }
        else
        {
            reseterCd.text = "";
        }
    }

}
