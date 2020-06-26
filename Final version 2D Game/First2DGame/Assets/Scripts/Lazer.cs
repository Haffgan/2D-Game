using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject lazer;
    public HeroScript hero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hero.LoseHealth(20f);
        Debug.Log("Hero touched lazers");
        SoundManager.PlaySound("Hurt");
    }
}
