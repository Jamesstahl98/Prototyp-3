using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPowerupsIcon : MonoBehaviour
{
    public int listNumber;
    public string listElement;
    public GameObject powerUpParent;
    public Image image;

    [SerializeField]
    private Sprite fireIcon;
    [SerializeField]
    private Sprite earthIcon;
    [SerializeField]
    private Sprite windIcon;
    [SerializeField]
    private Sprite waterIcon;
    [SerializeField]
    private Sprite lightningIcon;
    [SerializeField]
    private Sprite arcaneIcon;

    private 

    void Start()
    {
        if (listNumber == 0)
        {
            listElement = powerUpParent.GetComponent<LevelPowerups>().spellList[0];
        }
        else if (listNumber == 1)
        {
            listElement = powerUpParent.GetComponent<LevelPowerups>().spellList[1];
        }
        else if (listNumber == 2)
        {
            listElement = powerUpParent.GetComponent<LevelPowerups>().spellList[2];
        }

        if (listElement == "Fire")
        {
            image.sprite = fireIcon;
        }
        if (listElement == "Earth")
        {
            image.sprite = earthIcon;
        }
        if (listElement == "Wind")
        {
            image.sprite = windIcon;
        }
        if (listElement == "Water")
        {
            image.sprite = waterIcon;
        }
        if (listElement == "Wind")
        {
            image.sprite = windIcon;
        }
        if (listElement == "Lightning")
        {
            image.sprite = lightningIcon;
        }
        if (listElement == "Arcane")
        {
            image.sprite = arcaneIcon;
        }
    }
}
