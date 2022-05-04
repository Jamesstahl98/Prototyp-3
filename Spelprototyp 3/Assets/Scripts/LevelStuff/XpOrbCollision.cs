using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpOrbCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpObject;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "XpOrb50")
        {
            Destroy(coll.gameObject);
            levelUpObject.GetComponent<LevelWork>().AddExperience(50);
        }
    }
}
