using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    public Rigidbody2D rb;
    HeroScript hero;

    private void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Prefab01" ||
            collision.gameObject.name == "Prefab02" ||
            collision.gameObject.name == "Prefab03" ||
            collision.gameObject.name == "Prefab04" ||
            collision.gameObject.name == "BackWall" ||
            collision.gameObject.name == "FrontWall"||
            collision.gameObject.name == "Hero")
        {
            Destroy(gameObject);
        }

    }
}


