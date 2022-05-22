using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterDelay : MonoBehaviour
{
    private float timer = 0f;

    void FixedUpdate()
    {
        timer = timer + 1f;
        if(timer>150f)
        {
            Destroy(gameObject);
        }
    }
}
