using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISpellCooldowns : MonoBehaviour
{
    private GameObject player;

    private string spellType;

    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;

    private bool isCooldown = false;
    private float cooldownTime;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

        GameObject player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (spellType == "Fire" && player.GetComponent<Shooting>().fireTimer < player.GetComponent<Shooting>().fireCD)
        {

        }
    }

    public void UseSpell(string spellType)
    {
        Debug.Log("works");
        isCooldown = true;
        textCooldown.gameObject.SetActive(true);
        cooldownTimer = cooldownTime;
    }
}
