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
        if(Input.GetKeyDown(KeyCode.E))
        {
            var temp0 = spells[0];
            var temp1 = spells[1];
            var temp2 = spells[2];
            var temp3 = spells[3];
            var temp4 = spells[4];

            //spells[0] = temp4;
            //spells[1] = temp0;
            //spells[2] = temp1;
            //spells[3] = temp2;
            //spells[4] = temp3;
            activeSpellZero++;
            activeSpellOne++;
            Debug.Log(activeSpellZero);
            if (activeSpellZero == 4)
            {
                activeSpellZero = 0;
            }
            var deactivate = activeSpellZero - 1;

            spells[deactivate].GetComponent<UISpellCooldowns>().Deactivate();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            var temp0 = spells[0];
            var temp1 = spells[1];
            var temp2 = spells[2];
            var temp3 = spells[3];
            var temp4 = spells[4];

            spells[4] = temp0;
            spells[0] = temp1;
            spells[1] = temp2;
            spells[2] = temp3;
            spells[3] = temp4;

            activeSpellZero -= activeSpellZero;
            activeSpellOne -= activeSpellOne;
        }
    }
}
