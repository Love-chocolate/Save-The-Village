using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSound : MonoBehaviour
{
    public static AudioSource _hireWarriorSound;

    private void Start()
    {
        _hireWarriorSound = GetComponent<AudioSource>();
    }
}

