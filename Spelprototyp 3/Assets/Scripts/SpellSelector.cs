using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    public List<GameObject> spells = new List<GameObject>();
    public List<GameObject> spellsUnlocked = new List<GameObject>();
    private int activeSpellZero = 0;
    private int activeSpellOne = 1;

    public int maxSpells;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            activeSpellZero++;
            activeSpellOne++;
            if (activeSpellZero == spellsUnlocked.Count+1)
            {
                activeSpellZero = 1;
            }
            if (activeSpellOne == spellsUnlocked.Count+1)
            {
                activeSpellOne = 1;
            }

            var deactivate = activeSpellZero - 1;
            if(deactivate == 0)
            {
                deactivate = spellsUnlocked.Count;
            }
            if (spellsUnlocked.Count > 2)
            {
                spells[deactivate].GetComponent<UISpellCooldowns>().Deactivate();
                spells[activeSpellZero].GetComponent<UISpellCooldowns>().ActivateLeft();
                spells[activeSpellOne].GetComponent<UISpellCooldowns>().ActivateRight();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            activeSpellZero--;
            activeSpellOne--;

            if (activeSpellZero == 0)
            {
                activeSpellZero = spellsUnlocked.Count;
            }
            if (activeSpellOne == 0)
            {
                activeSpellOne = spellsUnlocked.Count;
            }

            var deactivate = activeSpellOne + 1;
            if (deactivate == spellsUnlocked.Count+1)
            {
                deactivate = 1;
            }
            if (spellsUnlocked.Count > 2)
            {
                Debug.Log("deactivate" + deactivate);
                spells[deactivate].GetComponent<UISpellCooldowns>().Deactivate();
                Debug.Log("activeSpellZero" + spells[activeSpellZero].name);
                spells[activeSpellZero].GetComponent<UISpellCooldowns>().ActivateLeft();
                Debug.Log("activeSpellOne" + spells[activeSpellOne].name);
                spells[activeSpellOne].GetComponent<UISpellCooldowns>().ActivateRight();
            }
        }
    }
    public void UpdateAbilities(GameObject spell)
    {
        spellsUnlocked.Add(spell);
        Debug.Log(spellsUnlocked[0].name);
    }

}
