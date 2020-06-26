using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretKey : MonoBehaviour
{
    public GameObject secretKey;
    public GameObject laserWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        secretKey.SetActive(false);
        laserWall.SetActive(false);
        FuelCanText.fuelCanAmount += 5;
        SoundManager.PlaySound("LazerWall");
        Debug.Log("Hero collected secret key!");
    }
}
