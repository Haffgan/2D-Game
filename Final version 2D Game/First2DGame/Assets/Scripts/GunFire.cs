using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    private Rigidbody2D rb;
    HeroScript hero;
    Vector2 direction;
    public GameObject bulletprefab;
    public Transform firePoint;
    public Animator anim;
    public float shootTimer = 20f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hero = GameObject.FindObjectOfType<HeroScript>();
        
    }

    void Update()
    {
        shootTimer -= 10f;

        direction = (hero.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (shootTimer <= 0)
        {
            shootTimer = 1800f;
            if (hero.life > 0 && hero.currentHealth > 0)
            {
                Shoot();
                SoundManager.PlaySound("Fire");
                anim.SetTrigger("isFire");
            }
            
        }
    }

    void Shoot()
    {
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
    }
}

