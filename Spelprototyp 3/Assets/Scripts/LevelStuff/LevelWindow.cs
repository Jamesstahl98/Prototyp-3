using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelWindow : MonoBehaviour
{
    private Text levelText;
    //private Image experienceBarImage;
    private LevelSystem levelSystem;

    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        //experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();

    }
    
   // private void SetExperienceBarSize(float experienceNormalized)
    //{
   //     experienceBarImage.fillAmount = experienceNormalized;
   // }
    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "Level\n" + (levelNumber + 1);
    }

    public void SetlevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;
        
        SetLevelNumber(levelSystem.GetLevelNumber());
        //setExperienceBarSize(levelSystem.GetExperienceNormalized());

     //   levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;

    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        // Level changed, update text
        SetLevelNumber(levelSystem.GetLevelNumber());

    }

    //private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
   // {
   //     SetExperienceBarSize(LevelSystem.GetExperienceNormalized());
    //}
}
