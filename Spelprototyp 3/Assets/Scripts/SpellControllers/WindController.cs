using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
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
        spellTimer = Time.time - startTime;
        transform.position = player.transform.position;

        if(spellTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }
}
