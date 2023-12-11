using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSound : MonoBehaviour
{
    public static AudioSource _eatFoodSound;

    private void Start()
    {
        _eatFoodSound = GetComponent<AudioSource>();
    }
}

