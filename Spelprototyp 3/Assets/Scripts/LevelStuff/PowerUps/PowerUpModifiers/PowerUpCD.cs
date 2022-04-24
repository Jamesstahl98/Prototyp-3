using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCD : MonoBehaviour
{
    private GameObject powerUpParent;
    private string element;
    private GameObject player;
    private GameObject cooldownUI;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.transform.parent.gameObject;
        element = powerUpParent.GetComponent<LevelPowerups>().listElement;
    }

    public void CD20()
    {
        player.GetComponent<Shooting>().ReduceCD(element, 0.8f);
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();

        if (element == "Fire")
        {
            cooldownUI = GameObject.Find("Fire Cooldown");
        }
        else if (element == "Earth")
        {
            cooldownUI = GameObject.Find("Earth Cooldown");
        }
        else if (element == "Wind")
        {
            cooldownUI = GameObject.Find("Wind Cooldown");
        }
        else if (element == "Water")
        {
            cooldownUI = GameObject.Find("Water Cooldown");
        }
        else if (element == "Lightning")
        {
            cooldownUI = GameObject.Find("Lightning Cooldown");
        }
        cooldownUI.GetComponent<UISpellCooldowns>().CooldownUpgraded();


        Destroy(gameObject.transform.parent.parent.gameObject);
    }
}
