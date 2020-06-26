using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
    public GameObject fuelCan;
    public HeroScript hero;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            hero.ImproveHealth(10f);
            Debug.Log("Hero collected fuel can");
            SoundManager.PlaySound("fuelCan");
            FuelCanText.fuelCanAmount += 1;
            Destroy(gameObject);
        }
    }
}
