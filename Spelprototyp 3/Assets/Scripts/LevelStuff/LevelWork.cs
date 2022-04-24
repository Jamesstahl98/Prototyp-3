using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWork : MonoBehaviour
{
    public int Level = 0;
    public int Xp = 0;
    public int XpToNextLevel = 100;
        
    // Update is called once per frame
    public void AddExperience(int amount)
    {
        Xp += amount;
        if(Xp >= XpToNextLevel)
        {
            Xp = 0;
            XpToNextLevel += 20;
            Level += 1;
            Debug.Log(Level);
            //levelText.GetComponent<LevelText>().SetLevelNumber(Level);
            gameObject.GetComponent<LevelPowerupsSpellIdentifier>().GetPowerups();
        }

    }
}
