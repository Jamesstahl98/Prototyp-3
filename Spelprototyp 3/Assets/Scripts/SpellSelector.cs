using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    public List<GameObject> spells = new List<GameObject>();

    private int activeSpellZero = 0;
    private int activeSpellOne = 1;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            var temp0 = spells[0];
            var temp1 = spells[1];
            var temp2 = spells[2];
            var temp3 = spells[3];
            var temp4 = spells[4];

            activeSpellZero++;
            activeSpellOne++;
            Debug.Log(activeSpellZero);
            if (activeSpellZero == 5)
            {
                activeSpellZero = 0;
            }
            if (activeSpellOne == 5)
            {
                activeSpellOne = 0;
            }

            var deactivate = activeSpellZero - 1;
            if(deactivate == -1)
            {
                deactivate = 4;
            }

            spells[deactivate].GetComponent<UISpellCooldowns>().Deactivate();
            spells[activeSpellZero].GetComponent<UISpellCooldowns>().ActivateLeft();
            spells[activeSpellOne].GetComponent<UISpellCooldowns>().ActivateRight();
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            var temp0 = spells[0];
            var temp1 = spells[1];
            var temp2 = spells[2];
            var temp3 = spells[3];
            var temp4 = spells[4];

            activeSpellZero--;
            activeSpellOne--;

            if (activeSpellZero == -1)
            {
                activeSpellZero = 4;
            }
            if (activeSpellOne == -1)
            {
                activeSpellOne = 4;
            }

            var deactivate = activeSpellOne + 1;
            if (deactivate == 5)
            {
                deactivate = 0;
            }

            spells[deactivate].GetComponent<UISpellCooldowns>().Deactivate();
            spells[activeSpellZero].GetComponent<UISpellCooldowns>().ActivateLeft();
            spells[activeSpellOne].GetComponent<UISpellCooldowns>().ActivateRight();
        }
    }
}
