using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDuration30 : MonoBehaviour
{
    private Transform powerUpParent;
    private string element;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent;
        element = powerUpParent.GetComponent<LevelPowerups>().listElement;
    }

    public void Duration30()
    {
        player.GetComponent<Shooting>().IncreaseDuration(element, 1.3f);
    }
}
