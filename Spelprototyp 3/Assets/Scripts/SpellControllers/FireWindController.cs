using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWindController : MonoBehaviour
{
    private float spellDuration;
    private float size;
    private float startTime;
    private float spellTimer;
    private GameObject player;
    private AudioSource audio;

    void Awake()
    {
        audio = GameObject.Find("WindSound").GetComponent<AudioSource>();
        audio.Play();
    }

    void Start()
    {
        startTime = Time.time;
        player = GameObject.Find("Player");
        spellDuration = (player.GetComponent<Shooting>().fireDuration + player.GetComponent<Shooting>().windDuration) * 0.5f;
        size = (player.GetComponent<Shooting>().fireSize / 6) + player.GetComponent<Shooting>().windSize;
        transform.localScale = new Vector3(size, size, size);
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
