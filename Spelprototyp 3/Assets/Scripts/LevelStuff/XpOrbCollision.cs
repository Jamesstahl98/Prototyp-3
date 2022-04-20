using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpOrbCollision : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "XpOrb")
        {
            Destroy(coll.gameObject);
            this.GetComponent<LevelSystem>().AddExperience(1);
        }
    }
}
