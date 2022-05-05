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
        }
        if (spellType == "Earth")
        {
            spellCooldownUI = GameObject.Find("Earth Cooldown");
            player.GetComponent<Shooting>().earthUnlocked = true;
        }
        if (spellType == "Wind")
        {
            spellCooldownUI = GameObject.Find("Wind Cooldown");
            player.GetComponent<Shooting>().windUnlocked = true;
        }
        if (spellType == "Water")
        {
            spellCooldownUI = GameObject.Find("Water Cooldown");
            player.GetComponent<Shooting>().waterUnlocked = true;
        }
        if (spellType == "Lightning")
        {
            spellCooldownUI = GameObject.Find("Lightning Cooldown");
            player.GetComponent<Shooting>().lightningUnlocked = true;
        }
        if (spellType == "Arcane")
        {
            spellCooldownUI = GameObject.Find("Arcane Cooldown");
            player.GetComponent<Shooting>().arcaneUnlocked = true;
        }
        player.GetComponent<SpellSelector>().UpdateAbilities(spellCooldownUI);
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemoveFromTotalSpellList();
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();
    }
}
