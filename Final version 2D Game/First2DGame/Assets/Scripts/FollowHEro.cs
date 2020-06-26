using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHEro : MonoBehaviour
{
    public GameObject heroCopy;

void Update()
    {
        if (heroCopy.transform.position.x > transform.position.x)
        {
            transform.position = new Vector2(heroCopy.transform.position.x, 2.29f);
        }
    }
}
