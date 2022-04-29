using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaController : MonoBehaviour
{
    public float spellDuration;
    private float size;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = (player.GetComponent<Shooting>().fireDuration + player.GetComponent<Shooting>().earthDuration) * 0.5f;
        startTime = Time.time;
        size = ((player.GetComponent<Shooting>().fireSize / 2) + (player.GetComponent<Shooting>().earthSize / 1.5f)) / 2;
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
