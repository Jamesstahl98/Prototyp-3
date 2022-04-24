using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaController : MonoBehaviour
{
    public float spellDuration;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = (player.GetComponent<Shooting>().fireDuration + player.GetComponent<Shooting>().earthDuration) * 0.5f;
        startTime = Time.time;
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
