using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCD20 : MonoBehaviour
{
    private Transform powerUpParent;
    private string element;
    private GameObject player;


    void Start()
    {
        player = GameObject.Find("Player");
        
        powerUpParent = transform.parent;
        element = powerUpParent.GetComponent<LevelPowerups>().listElement;
        Debug.Log(element);
    }

    public void CD20()
    {
        player.GetComponent<Shooting>().ReduceCD(element, 20f);
    }
}
