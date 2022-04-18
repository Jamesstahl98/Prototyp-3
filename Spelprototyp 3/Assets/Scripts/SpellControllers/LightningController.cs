using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public float spellDuration;
    //public GameObject firePoint;

    private float startTime;
    private float spellTimer;

    void Start()
    {
        startTime = Time.time;
        //transform.rotation.z = firePoint.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        spellTimer = Time.time - startTime;

        if (spellTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }
}
