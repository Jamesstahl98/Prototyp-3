using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject fireCooldownUI;
    [SerializeField]
    private GameObject earthCooldownUI;
    [SerializeField]
    private GameObject waterCooldownUI;
    [SerializeField]
    private GameObject windCooldownUI;
    [SerializeField]
    private GameObject lightningCooldownUI;

    private KeyCode fireButton = KeyCode.Mouse1;
    private KeyCode earthButton = KeyCode.Mouse0;
    private KeyCode lightningButton;
    private KeyCode waterButton;
    private KeyCode windButton;

    public Transform firePoint;
    public GameObject firePrefab;
    public GameObject earthPrefab;
    public GameObject lightningPrefab;
    public GameObject waterPrefab;
    public GameObject windPrefab;
    public GameObject arcanePrefab;

    public float fireForce = 20f;
    public float earthForce = 10f;
    public float windForce = 10f;
    public float waterForce = 10f;
    public float lightningForce = 10f;
    public float arcaneForce = 10f;

    public float fireCD;
    public float earthCD;
    public float lightningCD;
    public float waterCD;
    public float windCD;
    public float arcaneCD;

    public float fireDamage;
    public float earthDamage;
    public float lightningDamage;
    public float waterDamage;
    public float windDamage;
    public float arcaneDamage;

    public float fireSize;
    public float earthSize;
    public float lightningSize;
    public float waterSize;
    public float windSize;
    public float arcaneSize;

    public int fireHP;
    public int earthHP;
    public int lightningHP;
    public int waterHP;
    public int windHP;
    public int arcaneHP;

    public float fireDuration;
    public float earthDuration;
    public float windDuration;
    public float waterDuration;
    public float lightningDuration;
    public float arcaneDuration;

    public float fireTimer = 100f;
    public float earthTimer = 100f;
    public float lightningTimer = 100f;
    public float waterTimer = 100f;
    public float windTimer = 100f;

    public bool fireEnabled = true;
    public bool earthEnabled = true;
    public bool waterEnabled = false;
    public bool windEnabled = false;
    public bool lightningEnabled = false;
    public bool arcaneEnabled = false;

    public bool fireUnlocked = false;
    public bool earthUnlocked = false;
    public bool waterUnlocked = false;
    public bool windUnlocked = false;
    public bool lightningUnlocked = false;
    public bool arcaneUnlocked = false;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        earthTimer += Time.deltaTime;
        lightningTimer += Time.deltaTime;
        waterTimer += Time.deltaTime;
        windTimer += Time.deltaTime;

        if (Input.GetKeyDown(fireButton) && fireTimer > fireCD && fireEnabled == true)
        {
            ShootFire();
            fireCooldownUI.GetComponent<UISpellCooldowns>().UseSpell();
        }

        if (Input.GetKeyDown(earthButton) && earthTimer > earthCD && earthEnabled == true)
        {
            ShootEarth();
            earthCooldownUI.GetComponent<UISpellCooldowns>().UseSpell();
        }

        if (Input.GetKeyDown(lightningButton) && lightningTimer > lightningCD && lightningEnabled == true)
        {
            ShootLightning();
            lightningCooldownUI.GetComponent<UISpellCooldowns>().UseSpell();
        }

        if (Input.GetKeyDown(waterButton) && waterTimer > waterCD && waterEnabled == true)
        {
            ShootWater();
            waterCooldownUI.GetComponent<UISpellCooldowns>().UseSpell();
        }

        if (Input.GetKeyDown(windButton) && windTimer > windCD && windEnabled == true)
        {
            ShootWind();
            windCooldownUI.GetComponent<UISpellCooldowns>().UseSpell();
        }
    }

    void ShootFire()
    {
        GameObject fireProjectile = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        fireTimer = 0;
    }

    void ShootEarth()
    {
        GameObject earthProjectile = Instantiate(earthPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = earthProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * earthForce, ForceMode2D.Impulse);
        earthTimer = 0;
    }

    void ShootLightning()
    {
        GameObject lightningCone = Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
        lightningTimer = 0;
    }

    void ShootWater()
    {
        GameObject waterCone = Instantiate(waterPrefab, firePoint.position, firePoint.rotation);
        waterTimer = 0;
    }

    void ShootWind()
    {
        GameObject windCircle = Instantiate(windPrefab, firePoint.position, firePoint.rotation);
        windTimer = 0;
    }
    public void ReduceCD(string element, float amount)
    {
        if (element == "Fire")
        {
            fireCD = fireCD * amount;
        }
        else if (element == "Earth")
        {
            earthCD = earthCD * amount;
        }
        else if (element == "Wind")
        {
            windCD = windCD * amount;
        }
        else if (element == "Water")
        {
            waterCD = waterCD * amount;
        }
        else if (element == "Lightning")
        {
            lightningCD = lightningCD * amount;
        }
        else if (element == "Arcane")
        {
            arcaneCD = arcaneCD * amount;
        }
    }

    public void IncreaseDamage(string element, float amount)
    {
        if (element == "Fire")
        {
            fireDamage = fireDamage * amount;
        }
        else if (element == "Earth")
        {
            earthDamage = earthDamage * amount;
        }
        else if (element == "Wind")
        {
            windDamage = windDamage * amount;
        }
        else if (element == "Water")
        {
            waterDamage = waterDamage * amount;
        }
        else if (element == "Lightning")
        {
            lightningDamage = lightningDamage * amount;
        }
        else if (element == "Arcane")
        {
            arcaneDamage = arcaneDamage * amount;
        }
    }

    public void IncreaseSpeed(string element, float amount)
    {
        if (element == "Fire")
        {
            fireForce = fireForce * amount;
        }
        else if (element == "Earth")
        {
            earthForce = earthForce * amount;
        }
        else if (element == "Wind")
        {
            windForce = windForce * amount;
        }
        else if (element == "Water")
        {
            waterForce = waterForce * amount;
        }
        else if (element == "Lightning")
        {
            lightningForce = lightningForce * amount;
        }
        else if (element == "Arcane")
        {
            arcaneForce = arcaneForce * amount;
        }
    }

    public void IncreaseSize(string element, float amount)
    {
        if (element == "Fire")
        {
            fireSize = fireSize * amount;
        }
        else if (element == "Earth")
        {
            earthSize = earthSize * amount;
        }
        else if (element == "Wind")
        {
            windSize = windSize * amount;
        }
        else if (element == "Water")
        {
            waterSize = waterSize * amount;
        }
        else if (element == "Lightning")
        {
            lightningSize = lightningSize * amount;
        }
        else if (element == "Arcane")
        {
            arcaneSize = arcaneSize * amount;
        }
    }

    public void IncreaseDuration(string element, float amount)
    {
        if (element == "Fire")
        {
            fireDuration = fireDuration * amount;
        }
        else if (element == "Earth")
        {
            earthDuration = earthDuration * amount;
        }
        else if (element == "Wind")
        {
            windDuration = windDuration * amount;
        }
        else if (element == "Water")
        {
            waterDuration = waterDuration * amount;
        }
        else if (element == "Lightning")
        {
            lightningDuration = lightningDuration * amount;
        }
        else if (element == "Arcane")
        {
            arcaneDuration = arcaneDuration * amount;
        }
    }

    public void IncreasePierce(string element, int amount)
    {
        if (element == "Fire")
        {
            fireHP = fireHP + amount;
        }
        else if (element == "Earth")
        {
            earthHP = earthHP + amount;
        }
        else if (element == "Wind")
        {
            windHP = windHP + amount;
        }
        else if (element == "Water")
        {
            waterHP = waterHP + amount;
        }
        else if (element == "Lightning")
        {
            lightningHP = lightningHP + amount;
        }
        else if (element == "Arcane")
        {
            arcaneHP = arcaneHP + amount;
        }
    }

    public void ChangeLeftMouseButton(string element)
    {
        if (element == "Earth")
        {
            earthButton = KeyCode.Mouse0;
            earthEnabled = true;
        }
        else if (element == "Fire")
        {
            fireButton = KeyCode.Mouse0;
            fireEnabled = true;
        }
        else if (element == "Wind")
        {
            windButton = KeyCode.Mouse0;
            windEnabled = true;
        }
        else if (element == "Water")
        {
            waterButton = KeyCode.Mouse0;
            waterEnabled = true;
        }
        else if (element == "Lightning")
        {
            lightningButton = KeyCode.Mouse0;
            lightningEnabled = true;
        }
    }

    public void ChangeRightMouseButton(string element)
    {
        if (element == "Earth")
        {
            earthButton = KeyCode.Mouse1;
            earthEnabled = true;
        }
        else if (element == "Fire")
        {
            fireButton = KeyCode.Mouse1;
            fireEnabled = true;
        }
        else if (element == "Wind")
        {
            windButton = KeyCode.Mouse1;
            windEnabled = true;
        }
        else if (element == "Water")
        {
            waterButton = KeyCode.Mouse1;
            waterEnabled = true;
        }
        else if (element == "Lightning")
        {
            lightningButton = KeyCode.Mouse1;
            lightningEnabled = true;
        }
    }
    public void DisableElement(string element)
    {
        if (element == "Earth")
        {
            earthEnabled = false;
        }
        else if (element == "Fire")
        {
            fireEnabled = false;
        }
        else if (element == "Wind")
        {
            windEnabled = false;
        }
        else if (element == "Water")
        {
            waterEnabled = false;
        }
        else if (element == "Lightning")
        {
            lightningEnabled = false;
        }
    }
}
