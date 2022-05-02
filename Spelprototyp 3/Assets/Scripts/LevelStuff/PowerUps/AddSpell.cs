using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpell : MonoBehaviour
{
    private GameObject player;
    private string spellType;
    private GameObject powerUpParent;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.transform.parent.gameObject;
        spellType = transform.parent.transform.parent.gameObject.GetComponent<LevelPowerups>().listElement;
    }

    public void UnlockAbility()
    {
        if (spellType == "Fire")
        {
            player.GetComponent<Shooting>().fireUnlocked = true;
        }
        if (spellType == "Earth")
        {
            player.GetComponent<Shooting>().earthUnlocked = true;
        }
        if (spellType == "Wind")
        {
            player.GetComponent<Shooting>().windUnlocked = true;
        }
        if (spellType == "Water")
        {
            player.GetComponent<Shooting>().waterUnlocked = true;
        }
        if (spellType == "Lightning")
        {
            player.GetComponent<Shooting>().lightningUnlocked = true;
        }
        if (spellType == "Arcane")
        {
            player.GetComponent<Shooting>().arcaneUnlocked = true;
        }
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();
    }
}
