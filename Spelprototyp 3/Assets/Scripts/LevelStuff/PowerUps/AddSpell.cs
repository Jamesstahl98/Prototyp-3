using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpell : MonoBehaviour
{
    private GameObject player;
    public string spellType;
    private GameObject powerUpParent;
    private GameObject spellCooldownUI;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.transform.parent.gameObject;
    }

    public void UnlockAbility()
    {
        if (spellType == "Fire")
        {
            spellCooldownUI = GameObject.Find("Fire Cooldown");
            player.GetComponent<Shooting>().fireUnlocked = true;
            powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemoveFromTotalSpellList("Fire");
        }
        if (spellType == "Earth")
        {
            spellCooldownUI = GameObject.Find("Earth Cooldown");
            player.GetComponent<Shooting>().earthUnlocked = true;
            powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemoveFromTotalSpellList("Earth");
        }
        if (spellType == "Wind")
        {
            spellCooldownUI = GameObject.Find("Wind Cooldown");
            player.GetComponent<Shooting>().windUnlocked = true;
            powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemoveFromTotalSpellList("Wind");
        }
        if (spellType == "Water")
        {
            spellCooldownUI = GameObject.Find("Water Cooldown");
            player.GetComponent<Shooting>().waterUnlocked = true;
            powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemoveFromTotalSpellList("Water");
        }
        if (spellType == "Lightning")
        {
            spellCooldownUI = GameObject.Find("Lightning Cooldown");
            player.GetComponent<Shooting>().lightningUnlocked = true;
            powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemoveFromTotalSpellList("Lightning");
        }
        if (spellType == "Arcane")
        {
            spellCooldownUI = GameObject.Find("Arcane Cooldown");
            player.GetComponent<Shooting>().arcaneUnlocked = true;
        }
        player.GetComponent<SpellSelector>().UpdateAbilities(spellCooldownUI);
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();
    }
}
