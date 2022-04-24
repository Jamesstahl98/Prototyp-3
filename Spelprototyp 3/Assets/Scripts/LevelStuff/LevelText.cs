using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private Text levelText;
   
    void Start()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        levelText.text = "LEVEL\n" + 1;
    }

   
    public void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL\n" + (levelNumber + 1);
    }
}
