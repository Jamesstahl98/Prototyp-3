using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private float spellDuration;
    private float size;
    private float startTime;
    private float spellTimer;
    private GameObject player;
    private AudioSource audio;

    void Awake()
    {
        audio = GameObject.Find("FireSound").GetComponent<AudioSource>();
        audio.Play();
    }

    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = player.GetComponent<Shooting>().fireDuration;
        startTime = Time.time;
        size = player.GetComponent<Shooting>().fireSize;
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
