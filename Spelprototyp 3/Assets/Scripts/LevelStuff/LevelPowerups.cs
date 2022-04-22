using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPowerups : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUpBackgrounds;

    public void GetPowerups()
    {
        foreach (GameObject background in powerUpBackgrounds)
        {
            background.SetActive(true);
        }

    }

}
