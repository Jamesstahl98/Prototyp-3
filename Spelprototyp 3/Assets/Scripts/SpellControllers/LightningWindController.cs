using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWindController : MonoBehaviour
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
        spellDuration = (player.GetComponent<Shooting>().lightningDuration + player.GetComponent<Shooting>().windDuration) * 0.5f;
        size = (player.GetComponent<Shooting>().lightningSize + player.GetComponent<Shooting>().windSize);
        transform.localScale = new Vector3(size, size, size);
    }

    void Update()
    {
        spellTimer = Time.time - startTime;
        transform.position = player.transform.position;

        if (spellTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }
}
