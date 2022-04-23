using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPowerups : MonoBehaviour
{
    public int listNumber;
    public string listElement;
    public GameObject powerUpParent;
    public Image image;
    public TextMeshProUGUI textObject;

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

    private Button[] modifierButtons;

    void Start()
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
        AddText();
    }

    void AddText()
    {

        modifierButtons = powerUpParent.GetComponent<LevelPowerupsSpellIdentifier>().modifierButtons;
        var newButton = Instantiate(modifierButtons[Random.Range(0, modifierButtons.Length)], transform.position, transform.rotation);
        newButton.transform.parent = gameObject.transform;
    }
}
