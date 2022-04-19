using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public float spellDuration;

    private float startTime;
    private float spellTimer;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        spellTimer = Time.time - startTime;

        if (spellTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }
}
