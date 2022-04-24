using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public float spellDuration;
    private float size;
    private float startTime;
    private float spellTimer;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spellDuration = player.GetComponent<Shooting>().lightningDuration;
        startTime = Time.time;
        size = player.GetComponent<Shooting>().lightningSize;
        transform.localScale = new Vector3(size, size, size);
    }

    void Update()
    {
        spellTimer = Time.time - startTime;

        if (spellTimer >= spellDuration)
        {
            Destroy(gameObject);
        }
    }
}
