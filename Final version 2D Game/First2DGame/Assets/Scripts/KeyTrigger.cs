using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject secretKey;
    public GameObject laserWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        secretKey.SetActive(true);
        laserWall.SetActive(true);
    }
}
