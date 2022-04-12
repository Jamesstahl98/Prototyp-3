using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(fireButton))
        {
            ShootFire();
        }

        if(Input.GetKeyDown(earthButton))
        {
            ShootEarth();
        }

        if (Input.GetKeyDown(lightningButton))
        {
            ShootLightning();
        }

        if (Input.GetKeyDown(waterButton))
        {
            ShootWater();
        }

        if (Input.GetKeyDown(windButton))
        {
            ShootWind();
        }
    }

    void ShootFire()
    {
        GameObject fireProjectile = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    void ShootEarth()
    {
        GameObject earthProjectile = Instantiate(earthPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = earthProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * earthForce, ForceMode2D.Impulse);
    }

    void ShootLightning()
    {
        GameObject lightningCone = Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootWater()
    {
        GameObject waterCone = Instantiate(waterPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootWind()
    {
        GameObject windCircle = Instantiate(windPrefab, firePoint.position, firePoint.rotation);
    }
}
