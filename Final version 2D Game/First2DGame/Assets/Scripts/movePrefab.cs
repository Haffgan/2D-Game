using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePrefab : MonoBehaviour
{
    public GameObject prefabToMove;
    public GameObject currentPrefab;
    public float incrementX;


    public GameObject fuelCan;
    public GameObject laser;
    public GameObject crate;
    public GameObject gun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            Vector3 temp = currentPrefab.transform.position;
            temp.x = temp.x + incrementX;
            prefabToMove.transform.position = temp;
        }
            Random random = new Random();
            int choice = Random.Range(0, 2);

            if (choice == 0)
            {
                fuelCan.SetActive(false);
                laser.SetActive(true);
                crate.SetActive(true);
                gun.SetActive(false);
            }
            else if (choice == 1)
            {
                fuelCan.SetActive(true);
                laser.SetActive(false);
                crate.SetActive(false);
                gun.SetActive(true);
            }
    }
}

