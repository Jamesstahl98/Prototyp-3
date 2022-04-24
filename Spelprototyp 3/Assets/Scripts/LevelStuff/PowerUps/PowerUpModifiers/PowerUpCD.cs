using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCD : MonoBehaviour
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

    public void CD20()
    {
        player.GetComponent<Shooting>().ReduceCD(element, 0.8f);
        powerUpParent.transform.parent.gameObject.GetComponent<LevelPowerupsSpellIdentifier>().RemovePowerups();
        Destroy(gameObject.transform.parent.gameObject);
    }
}
