using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPowerups : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUpBackgrounds;
    private GameObject player;
    public List<string> spellList = new List<string>();

    public string listZeroElement;
    public string listOneElement;
    public string listTwoElement;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
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

        listZeroElement = spellList[0];
        listOneElement = spellList[1];
        listTwoElement = spellList[2];

    }

}
