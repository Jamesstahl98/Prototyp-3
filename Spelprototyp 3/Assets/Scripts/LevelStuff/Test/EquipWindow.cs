/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EquipWindow : MonoBehaviour {

  //  [SerializeField] private Player player;
    [SerializeField] private Sprite headSprite;
    [SerializeField] private Sprite helmet1Sprite;
    [SerializeField] private Sprite helmet2Sprite;

    private LevelSystem levelSystem;

   
    public void SetLevelSystem(LevelSystem levelSystem) {
        this.levelSystem = levelSystem;
    }

}
