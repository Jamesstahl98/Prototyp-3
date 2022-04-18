using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWindController : MonoBehaviour
{
    public float spellDuration;

    private float startTime;
    private float spellTimer;

    private GameObject player;

    void Start()
    {
        startTime = Time.time;
        player = GameObject.Find("Player");
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
