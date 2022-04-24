using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPierce : MonoBehaviour
{
    private GameObject powerUpParent;
    private string element;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.transform.parent.gameObject;
        Debug.Log(powerUpParent);
        element = powerUpParent.GetComponent<LevelPowerups>().listElement;
    }

    public void Pierce1()
    {
        player.GetComponent<Shooting>().IncreasePierce(element, 1);
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();
    }
}

