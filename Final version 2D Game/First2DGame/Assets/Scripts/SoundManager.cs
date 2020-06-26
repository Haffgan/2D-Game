using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, hurt, collectFuel, gun, dead, secretKey;
    static AudioSource audioScr;

    void Start()
    {
        jump = Resources.Load<AudioClip>("Jump");
        hurt = Resources.Load<AudioClip>("Hurt");
        collectFuel = Resources.Load<AudioClip>("fuelCan");
        secretKey = Resources.Load<AudioClip>("LazerWall");
        dead = Resources.Load<AudioClip>("Dead");
        gun = Resources.Load<AudioClip>("Fire");
        audioScr = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioScr.PlayOneShot(jump);
                break;
            case "Hurt":
                audioScr.PlayOneShot(hurt);
                break;
            case "fuelCan":
                audioScr.PlayOneShot(collectFuel);
                break;
            case "LazerWall":
                audioScr.PlayOneShot(secretKey);
                break;
            case "Dead":
                audioScr.PlayOneShot(dead);
                break;
            case "Fire":
                audioScr.PlayOneShot(gun);
                break;
        }
    }
}
