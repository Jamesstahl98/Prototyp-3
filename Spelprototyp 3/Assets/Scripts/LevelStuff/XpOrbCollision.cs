using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpOrbCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpObject;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            levelUpObject.GetComponent<LevelWork>().AddExperience(50);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "XpOrb")
        {
            Destroy(coll.gameObject);
            levelUpObject.GetComponent<LevelWork>().AddExperience(coll.GetComponent<XpOrb>().xpGain);
        }
    }
}
