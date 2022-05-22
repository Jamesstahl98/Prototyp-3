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
    public List<Button> baseSpellButtons = new List<Button>();

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.gameObject;

        if (powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList.Count >= 4)
        {
            if (listNumber == 0)
            {
                listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList[0];
            }
            else if (listNumber == 1)
            {
                listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList[1];
            }
            else if (listNumber == 2)
            {
                listElement = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().spellList[2];
            }
            AddModifierButtons();
        }
        else
        {
            AddSpellUnlockButton();
        }

        if (listElement == "Fire" && player.GetComponent<Shooting>().fireUnlocked == true)
        {
            image.enabled = true;
            image.sprite = fireIcon;
            spellUnlocked = true;
        }
        if (listElement == "Earth" && player.GetComponent<Shooting>().earthUnlocked == true)
        {
            image.enabled = true;
            image.sprite = earthIcon;
            spellUnlocked = true;
        }
        if (listElement == "Wind" && player.GetComponent<Shooting>().windUnlocked == true)
        {
            image.enabled = true;
            spellUnlocked = true;
            image.sprite = windIcon;
        }
        if (listElement == "Water" && player.GetComponent<Shooting>().waterUnlocked == true)
        {
            image.enabled = true;
            image.sprite = waterIcon;
            spellUnlocked = true;
        }
        if (listElement == "Lightning" && player.GetComponent<Shooting>().lightningUnlocked == true)
        {
            image.enabled = true;
            image.sprite = lightningIcon;
            spellUnlocked = true;
        }
        if (listElement == "Arcane" && player.GetComponent<Shooting>().arcaneUnlocked == true)
        {
            image.sprite = arcaneIcon;
            spellUnlocked = true;
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
        baseSpellButtons = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().availableBaseSpellButtons;
        Debug.Log(baseSpellButtons[0]);
        var newButton = Instantiate(baseSpellButtons[Random.Range(0, baseSpellButtons.Count)], transform.position, transform.rotation);
        newButton.transform.parent = gameObject.transform;
    }
}
