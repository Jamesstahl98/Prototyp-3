using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private float spellDuration;
    private float size;
    private float startTime;
    private float spellTimer;
    private GameObject player;
    private AudioSource audio;

    void Awake()
    {
        audio = GameObject.Find("EarthSound").GetComponent<AudioSource>();
        audio.Play();
    }


    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = player.GetComponent<Shooting>().earthDuration;
        startTime = Time.time;
        size = player.GetComponent<Shooting>().earthSize;
        transform.localScale = new Vector3(size, size, size);
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
