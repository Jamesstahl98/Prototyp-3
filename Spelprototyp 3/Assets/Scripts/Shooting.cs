using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject FireCooldownUI;
    [SerializeField]
    private GameObject EarthCooldownUI;
    [SerializeField]
    private GameObject WaterCooldownUI;
    [SerializeField]
    private GameObject WindCooldownUI;
    [SerializeField]
    private GameObject LightningCooldownUI;

    public KeyCode fireButton;
    public KeyCode earthButton;
    public KeyCode lightningButton;
    public KeyCode waterButton;
    public KeyCode windButton;

    public Transform firePoint;
    public GameObject firePrefab;
    public GameObject earthPrefab;
    public GameObject lightningPrefab;
    public GameObject waterPrefab;
    public GameObject windPrefab;
    public GameObject arcanePrefab;

    public float fireForce = 20f;
    public float earthForce = 10f;
    
    public float fireCD;
    public float earthCD;
    public float lightningCD;
    public float waterCD;
    public float windCD;
    
    public float fireTimer = 100f;
    public float earthTimer = 100f;
    public float lightningTimer = 100f;
    public float waterTimer = 100f;
    public float windTimer = 100f;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        earthTimer += Time.deltaTime;
        lightningTimer += Time.deltaTime;
        waterTimer += Time.deltaTime;
        windTimer += Time.deltaTime;

        if (Input.GetKeyDown(fireButton) && fireTimer > fireCD)
        {
            ShootFire();
            FireCooldownUI.GetComponent<UISpellCooldowns>().UseSpell("Fire");
        }

        if (Input.GetKeyDown(earthButton) && earthTimer > earthCD)
        {
            ShootEarth();
        }

        if (Input.GetKeyDown(lightningButton) && lightningTimer > lightningCD)
        {
            ShootLightning();
        }

        if (Input.GetKeyDown(waterButton) && waterTimer > waterCD)
        {
            ShootWater();
        }

        if (Input.GetKeyDown(windButton) && windTimer > windCD)
        {
            ShootWind();
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
}
