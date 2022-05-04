using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    public List<GameObject> spells = new List<GameObject>();
    public List<GameObject> spellsUnlocked = new List<GameObject>();
    private int activeSpellZero = 1;
    private int activeSpellOne = 2;

    public int maxSpells;

    void Update() 
    {
        if (spellsUnlocked.Count > 2)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Debug.Log("Count: " + spellsUnlocked.Count);
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
                Debug.Log("zero: " + activeSpellZero);
                Debug.Log("one: " + activeSpellOne);
                spellsUnlocked[deactivate - 1].GetComponent<UISpellCooldowns>().Deactivate();
                spellsUnlocked[activeSpellZero - 1].GetComponent<UISpellCooldowns>().ActivateLeft();
                spellsUnlocked[activeSpellOne - 1].GetComponent<UISpellCooldowns>().ActivateRight();
        }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                activeSpellZero--;
                activeSpellOne--;
                Debug.Log(activeSpellZero);

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
                Debug.Log("zero: " + activeSpellZero);
                Debug.Log("one: " + activeSpellOne);
                spellsUnlocked[deactivate - 1].GetComponent<UISpellCooldowns>().Deactivate();
                spellsUnlocked[activeSpellZero - 1].GetComponent<UISpellCooldowns>().ActivateLeft();
                spellsUnlocked[activeSpellOne - 1].GetComponent<UISpellCooldowns>().ActivateRight();
            }
        }
    }
    public void UpdateAbilities(GameObject spell)
    {
        spellsUnlocked.Add(spell);
    }

}
