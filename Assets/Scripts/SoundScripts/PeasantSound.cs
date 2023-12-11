using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantSound : MonoBehaviour
{
    public static AudioSource _hirePeasantSound;

    private void Start()
    {
        _hirePeasantSound = GetComponent<AudioSource>();
    }
}

