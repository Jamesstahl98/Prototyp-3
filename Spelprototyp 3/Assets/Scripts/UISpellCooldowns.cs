using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISpellCooldowns : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sr;

    [SerializeField]
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

        player = GameObject.Find("Player");
        sr = gameObject.GetComponent<SpriteRenderer>();

        if (spellType == "Fire")
        {
            cooldownTime = player.GetComponent<Shooting>().fireCD;
        }

        else if (spellType == "Earth")
        {
            cooldownTime = player.GetComponent<Shooting>().earthCD;
        }

        else if (spellType == "Water")
        {
            cooldownTime = player.GetComponent<Shooting>().waterCD;
        }

        else if (spellType == "Wind")
        {
            cooldownTime = player.GetComponent<Shooting>().windCD;
        }

        else if (spellType == "Lightning")
        {
            cooldownTime = player.GetComponent<Shooting>().lightningCD;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void UseSpell()
    {
        //ON CD
        if(isCooldown)
        {
            
        }
        
        //NOT ON CD
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        }
    }  

    public void Deactivate()
    {
        transform.position = new Vector2(transform.position.x, -400);
        player.GetComponent<Shooting>().DisableElement(spellType);
    }

    public void ActivateRight()
    {
        transform.position = new Vector2(315, 13);
        player.GetComponent<Shooting>().ChangeRightMouseButton(spellType);
    }

    public void ActivateLeft()
    {
        transform.position = new Vector2(35, 13);
        player.GetComponent<Shooting>().ChangeLeftMouseButton(spellType);
    }

    public void CooldownUpgraded()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

        GameObject player = GameObject.Find("Player");

        if(spellType == "Fire")
        {
            cooldownTime = player.GetComponent<Shooting>().fireCD;
        }

        else if (spellType == "Earth")
        {
            cooldownTime = player.GetComponent<Shooting>().earthCD;
        }

        else if (spellType == "Water")
        {
            cooldownTime = player.GetComponent<Shooting>().waterCD;
        }

        else if (spellType == "Wind")
        {
            cooldownTime = player.GetComponent<Shooting>().windCD;
        }

        else if (spellType == "Lightning")
        {
            cooldownTime = player.GetComponent<Shooting>().lightningCD;
        }
    }
}
