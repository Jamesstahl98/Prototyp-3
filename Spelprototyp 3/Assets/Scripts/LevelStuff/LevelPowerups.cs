using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPowerups : MonoBehaviour
{
    public int listNumber;
    public string listElement;
    public Image image;

    private bool spellUnlocked = false;
    private GameObject powerUpParent;
    private GameObject player;
    //Icons
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

    private Button[] buttons;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.gameObject;
        
        if (listElement == "Fire" && player.GetComponent<Shooting>().fireUnlocked == true)
        {
            image.sprite = fireIcon;
            spellUnlocked = true;
        }
        if (listElement == "Earth" && player.GetComponent<Shooting>().earthUnlocked == true)
        {
            image.sprite = earthIcon;
            spellUnlocked = true;
        }
        if (listElement == "Wind" && player.GetComponent<Shooting>().windUnlocked == true)
        {
            spellUnlocked = true;
            image.sprite = windIcon;
        }
        if (listElement == "Water" && player.GetComponent<Shooting>().waterUnlocked == true)
        {
            image.sprite = waterIcon;
            spellUnlocked = true;
        }
        if (listElement == "Lightning" && player.GetComponent<Shooting>().lightningUnlocked == true)
        {
            image.sprite = lightningIcon;
            spellUnlocked = true;
        }
        if (listElement == "Arcane" && player.GetComponent<Shooting>().arcaneUnlocked == true)
        {
            image.sprite = arcaneIcon;
            spellUnlocked = true;
        }
        
        if (listNumber == 0 && spellUnlocked == true)
        {
            listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList[0];
        }
        else if (listNumber == 1 && spellUnlocked == true)
        {
            listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList[1];
        }
        else if (listNumber == 2 && spellUnlocked == true)
        {
            listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList[2];
        }

        if (listNumber == 0 && spellUnlocked == false)
        {
            listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().totalSpellList[0];
        }
        else if (listNumber == 1 && spellUnlocked == false)
        {
            listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().totalSpellList[1];
        }
        else if (listNumber == 2 && spellUnlocked == false)
        {
            listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().totalSpellList[2];
        }

        if (spellUnlocked == true)
        {
            AddModifierButtons();
        }
        else
        {
            AddSpellUnlockButton();
        }
    }

    void AddModifierButtons()
    {
        buttons = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().modifierButtons;
        var newButton = Instantiate(buttons[Random.Range(0, buttons.Length)], transform.position, transform.rotation);
        newButton.transform.parent = gameObject.transform;
    }

    void AddSpellUnlockButton()
    {
        buttons = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().baseSpellButtons;
        var newButton = Instantiate(buttons[Random.Range(0, buttons.Length)], transform.position, transform.rotation);
        newButton.transform.parent = gameObject.transform;
    }
}
