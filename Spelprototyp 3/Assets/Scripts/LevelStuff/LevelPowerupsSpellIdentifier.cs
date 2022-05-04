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
    private int spellNumber = 0;

    public List<string> spellList = new List<string>();
    public List<string> totalSpellList = new List<string>();

    public List<GameObject> prefabList = new List<GameObject>();

    public Button[] modifierButtons;
    public Button[] baseSpellButtons;

    void Start()
    {
        player = GameObject.Find("Player");
        GetPowerups();
    }

    public void GetPowerups()
    {
        Time.timeScale = 0;
        foreach (GameObject background in powerUpBackgrounds)
        {
            var tempObject = Instantiate(background, this.transform, false);
            tempObject.transform.parent = transform;
            prefabList.Add(tempObject);
        }
        if(player.GetComponent<Shooting>().fireUnlocked == true)
        {
            spellList.Add("Fire");
            spellNumber++;
        }
        if (player.GetComponent<Shooting>().earthUnlocked == true)
        {
            spellList.Add("Earth");
            spellNumber++;
        }
        if (player.GetComponent<Shooting>().waterUnlocked == true)
        {
            spellList.Add("Water");
            spellNumber++;
        }
        if (player.GetComponent<Shooting>().windUnlocked == true)
        {
            spellList.Add("Wind");
            spellNumber++;
        }
        if (player.GetComponent<Shooting>().lightningUnlocked == true)
        {
            spellList.Add("Lightning");
            spellNumber++;
        }
        if (player.GetComponent<Shooting>().arcaneUnlocked == true)
        {
            spellList.Add("Arcane");
            spellNumber++;
        }
        if (spellNumber >= 3)
        {
            for (int i = 0; i < spellList.Count; i++)
            {
                string temp = spellList[i];
                int randomIndex = Random.Range(i, spellList.Count);
                spellList[i] = spellList[randomIndex];
                spellList[randomIndex] = temp;
            }
        }
        else
        {
            for (int i = 0; i < totalSpellList.Count; i++)
            {
                string temp = totalSpellList[i];
                int randomIndex = Random.Range(i, totalSpellList.Count);
                totalSpellList[i] = totalSpellList[randomIndex];
                totalSpellList[randomIndex] = temp;
                Debug.Log(temp);
            }
        }
    }

    public void RemovePowerups()
    {
        foreach (GameObject background in prefabList)
        {
            Destroy(background);
        }
        Time.timeScale = 1;
    }

    public void RemoveFromTotalSpellList(string element)
    {
        for (int i = 0; i < totalSpellList.Count; i++)
        {
            if(totalSpellList[i] == element)
            {
                totalSpellList.RemoveAt(i);
            }
        }
        //totalSpellList.RemoveAll()
    }

}
