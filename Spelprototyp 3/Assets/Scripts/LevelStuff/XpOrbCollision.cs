using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpOrbCollision : MonoBehaviour
{
   

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "XpOrb50")
        {
            Destroy(coll.gameObject);
            gameObject.GetComponent<LevelWork>().AddExperience(50);
        }
    }
}
