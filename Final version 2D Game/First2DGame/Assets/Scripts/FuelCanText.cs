using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelCanText : MonoBehaviour
{
    Text fuelCanCollected;
    public static int fuelCanAmount;

    void Start()
    {
        fuelCanCollected = GetComponent<Text>();
    }

    void Update()
    {
        fuelCanCollected.text = fuelCanAmount.ToString();
    }
}
