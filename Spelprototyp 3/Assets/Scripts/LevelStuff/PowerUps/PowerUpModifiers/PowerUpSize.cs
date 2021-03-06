using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSize : MonoBehaviour
{
    private GameObject powerUpParent;
    private string element;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        powerUpParent = transform.parent.transform.parent.gameObject;
        element = powerUpParent.GetComponent<LevelPowerups>().listElement;
    }

    public void Size30()
    {
        player.GetComponent<Shooting>().IncreaseSize(element, 1.3f);
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();
        Destroy(gameObject.transform.parent.parent.gameObject);
    }
}

