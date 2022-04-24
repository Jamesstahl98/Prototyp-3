using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPowerupsSpellIdentifier : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUpBackgrounds;
    private GameObject player;
    public List<string> spellList = new List<string>();

    public Button[] modifierButtons;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void GetPowerups()
    {
        foreach (GameObject background in powerUpBackgrounds)
        {
            background.SetActive(true);
        }
        if(player.GetComponent<Shooting>().fireEnabled == true)
        {
            spellList.Add("Fire");
        }
        if (player.GetComponent<Shooting>().earthEnabled == true)
        {
            spellList.Add("Earth");
        }
        if (player.GetComponent<Shooting>().waterEnabled == true)
        {
            spellList.Add("Water");
        }
        if (player.GetComponent<Shooting>().windEnabled == true)
        {
            spellList.Add("Wind");
        }
        if (player.GetComponent<Shooting>().lightningEnabled == true)
        {
            spellList.Add("Lightning");
        }
        if (player.GetComponent<Shooting>().arcaneEnabled == true)
        {
            spellList.Add("Arcane");
        }
    }

}
