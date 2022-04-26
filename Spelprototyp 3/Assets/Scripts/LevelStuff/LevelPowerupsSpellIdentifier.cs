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

    public List<GameObject> prefabList = new List<GameObject>();

    public Button[] modifierButtons;

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
        }
        if (player.GetComponent<Shooting>().earthUnlocked == true)
        {
            spellList.Add("Earth");
        }
        if (player.GetComponent<Shooting>().waterUnlocked == true)
        {
            spellList.Add("Water");
        }
        if (player.GetComponent<Shooting>().windUnlocked == true)
        {
            spellList.Add("Wind");
        }
        if (player.GetComponent<Shooting>().lightningUnlocked == true)
        {
            spellList.Add("Lightning");
        }

        for (int i = 0; i < spellList.Count; i++)
        {
            string temp = spellList[i];
            int randomIndex = Random.Range(i, spellList.Count);
            spellList[i] = spellList[randomIndex];
            spellList[randomIndex] = temp;
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

}
