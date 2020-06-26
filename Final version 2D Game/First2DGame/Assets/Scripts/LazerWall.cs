using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerWall : MonoBehaviour
{
    public GameObject lazerWall;
    public HeroScript hero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hero.LoseHealth(50f);
        SoundManager.PlaySound("Hurt");
        Debug.Log("Hero touched lazerWall");
    }
}
