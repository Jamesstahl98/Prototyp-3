using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantProjectileController : MonoBehaviour
{
    private float spellDuration;
    private float size;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = (player.GetComponent<Shooting>().earthDuration + player.GetComponent<Shooting>().waterDuration) / 2f;
        startTime = Time.time;
        size = (player.GetComponent<Shooting>().earthSize + player.GetComponent<Shooting>().waterSize) / 2f;
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
