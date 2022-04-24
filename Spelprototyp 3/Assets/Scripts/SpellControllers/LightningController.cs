using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public float spellDuration;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = player.GetComponent<Shooting>().lightningDuration;
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
