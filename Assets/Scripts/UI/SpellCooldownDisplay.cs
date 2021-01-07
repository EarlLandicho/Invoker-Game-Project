using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellCooldownDisplay : MonoBehaviour
{

    private SpiritCast spiritCast;

    [SerializeField] private TextMeshProUGUI boulderCd,
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

    //[SerializeField] private TextMeshProUGUI icicleCd,  boulderCd;

    void Start()
    {
        spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();


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
