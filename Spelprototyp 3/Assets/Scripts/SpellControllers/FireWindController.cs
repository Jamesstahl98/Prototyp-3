using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWindController : MonoBehaviour
{
    private float spellDuration;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        startTime = Time.time;
        player = GameObject.Find("Player");
        spellDuration = (player.GetComponent<Shooting>().fireDuration + player.GetComponent<Shooting>().windDuration) * 0.5f;
    }

    void Update()
    {
        transform.position = player.transform.position;
        spellTimer = Time.time - startTime;

        if (spellTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }
}
