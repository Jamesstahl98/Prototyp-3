using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    public List<GameObject> spells = new List<GameObject>();
    public List<GameObject> spellsUnlocked = new List<GameObject>();
    private int activeSpellZero = 1;
    private int activeSpellOne = 2;

    private bool stopSort = false;

    public int maxSpells;

    public GameObject earthObject;
    public GameObject fireObject;
    public GameObject windObject;
    public GameObject lightningObject;
    public GameObject waterObject;

    void Update() 
    {
        if (spellsUnlocked.Count > 2)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                activeSpellZero++;
                activeSpellOne++;
                if (activeSpellZero >= spellsUnlocked.Count + 1)
                {
                    activeSpellZero = 1;
                }
                if (activeSpellOne >= spellsUnlocked.Count + 1)
                {
                    activeSpellOne = 1;
                }

                var deactivate = activeSpellZero - 1;
                if (deactivate <= 0)
                {
                    deactivate = spellsUnlocked.Count;
                }
                spellsUnlocked[deactivate - 1].GetComponent<UISpellCooldowns>().Deactivate();
                spellsUnlocked[activeSpellZero - 1].GetComponent<UISpellCooldowns>().ActivateLeft();
                spellsUnlocked[activeSpellOne - 1].GetComponent<UISpellCooldowns>().ActivateRight();
        }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                activeSpellZero--;
                activeSpellOne--;

                if (activeSpellZero <= 0)
                {
                    activeSpellZero = spellsUnlocked.Count;
                }
                if (activeSpellOne <= 0)
                {
                    activeSpellOne = spellsUnlocked.Count;
                }

                var deactivate = activeSpellOne + 1;
                if (deactivate >= spellsUnlocked.Count + 1)
                {
                    deactivate = 1;
                }
                spellsUnlocked[deactivate - 1].GetComponent<UISpellCooldowns>().Deactivate();
                spellsUnlocked[activeSpellZero - 1].GetComponent<UISpellCooldowns>().ActivateLeft();
                spellsUnlocked[activeSpellOne - 1].GetComponent<UISpellCooldowns>().ActivateRight();
            }
        }
    }
    public void UpdateAbilities(GameObject spell)
    {
        spellsUnlocked.Add(spell);
        if (spellsUnlocked.Count == 1)
        {
            spell.GetComponent<UISpellCooldowns>().ActivateLeft();
        }
        if (spellsUnlocked.Count == 2)
        {
            spell.GetComponent<UISpellCooldowns>().ActivateRight();
        }
    }

    public void SortAbilities()
    {
        if (stopSort == false)
        {
            spellsUnlocked.Clear();
            if (gameObject.GetComponent<Shooting>().earthUnlocked == true)
            {
                spellsUnlocked.Add(earthObject);
            }
            if (gameObject.GetComponent<Shooting>().fireUnlocked == true)
            {
                spellsUnlocked.Add(fireObject);
            }
            if (gameObject.GetComponent<Shooting>().windUnlocked == true)
            {
                spellsUnlocked.Add(windObject);
            }
            if (gameObject.GetComponent<Shooting>().lightningUnlocked == true)
            {
                spellsUnlocked.Add(lightningObject);
            }
            if (gameObject.GetComponent<Shooting>().waterUnlocked == true)
            {
                spellsUnlocked.Add(waterObject);
            }
            for (int i = 0; i < spellsUnlocked.Count; i++)
            {
                spellsUnlocked[i].GetComponent<UISpellCooldowns>().Deactivate();
            }
            activeSpellZero = 1;
            activeSpellOne = 2;
            spellsUnlocked[activeSpellZero - 1].GetComponent<UISpellCooldowns>().ActivateLeft();
            if (spellsUnlocked.Count > 1)
            {
                spellsUnlocked[activeSpellOne - 1].GetComponent<UISpellCooldowns>().ActivateRight();
            }
        }
        if (spellsUnlocked.Count == 4)
        {
            stopSort = true;
        }
    }
}
