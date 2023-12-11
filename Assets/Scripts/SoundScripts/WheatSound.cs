using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSound : MonoBehaviour
{
    public static AudioSource _collectWheatSound;

    private void Start()
    {
        _collectWheatSound = GetComponent<AudioSource>();
    }
}

