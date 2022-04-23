using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage30 : MonoBehaviour
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

    public void Damage30()
    {
        player.GetComponent<Shooting>().IncreaseDamage(element, 1.3f);
    }
}
