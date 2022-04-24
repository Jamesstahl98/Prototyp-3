using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float spellDuration;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        startTime = Time.time;
        player = GameObject.Find("Player");
        spellDuration = ((player.GetComponent<Shooting>().lightningDuration * 5) + (player.GetComponent<Shooting>().waterDuration * 5)) * 0.5f;
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
