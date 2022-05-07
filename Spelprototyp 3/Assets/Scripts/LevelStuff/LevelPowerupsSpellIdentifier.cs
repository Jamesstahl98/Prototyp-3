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
    public List<string> totalSpellList = new List<string>();
    public List<Button> availableBaseSpellButtons = new List<Button>();
    public List<Button> baseSpellButtons = new List<Button>();

    public List<GameObject> prefabList = new List<GameObject>();

    public Button[] modifierButtons;
    //public Button[] baseSpellButtons;
    public string[] unlockedSpellStrings;

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
        if(player.GetComponent<Shooting>().fireUnlocked == true && !spellList.Contains("Fire"))
        {
            spellList.Add("Fire");
        }
        if (player.GetComponent<Shooting>().earthUnlocked == true && !spellList.Contains("Earth"))
        {
            spellList.Add("Earth");
        }
        if (player.GetComponent<Shooting>().waterUnlocked == true && !spellList.Contains("Water"))
        {
            spellList.Add("Water");
        }
        if (player.GetComponent<Shooting>().windUnlocked == true && !spellList.Contains("Wind"))
        {
            spellList.Add("Wind");
        }
        if (player.GetComponent<Shooting>().lightningUnlocked == true && !spellList.Contains("Lightning"))
        {
            spellList.Add("Lightning");
        }
        //if (player.GetComponent<Shooting>().arcaneUnlocked == true)
        //{
        //    spellList.Add("Arcane");
        //}
        if (spellList.Count >= 4)
        {
            for (int i = 0; i < spellList.Count; i++)
            {
                string temp = spellList[i];
                int randomIndex = Random.Range(i, spellList.Count);
                spellList[i] = spellList[randomIndex];
                spellList[randomIndex] = temp;
                Debug.Log(temp);
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
        player.GetComponent<SpellSelector>().SortAbilities();
        Time.timeScale = 1;
    }

    public void RemoveFromTotalSpellList()
    {
        availableBaseSpellButtons.Clear();
        if (player.GetComponent<Shooting>().fireUnlocked == false)
        {
            availableBaseSpellButtons.Add(baseSpellButtons[0]);
        }
        if (player.GetComponent<Shooting>().earthUnlocked == false)
        {
            availableBaseSpellButtons.Add(baseSpellButtons[1]);
        }
        if (player.GetComponent<Shooting>().waterUnlocked == false)
        {
            availableBaseSpellButtons.Add(baseSpellButtons[2]);
        }
        if (player.GetComponent<Shooting>().windUnlocked == false)
        {
            availableBaseSpellButtons.Add(baseSpellButtons[3]);
        }
        if (player.GetComponent<Shooting>().lightningUnlocked == false)
        {
            availableBaseSpellButtons.Add(baseSpellButtons[4]);
        }
        //if (player.GetComponent<Shooting>().arcaneUnlocked == false)
        //{
        //    availableBaseSpellButtons.Add(baseSpellButtons[5]);
        //}
    }

}
