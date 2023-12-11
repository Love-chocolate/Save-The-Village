using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSound : MonoBehaviour
{
    public static AudioSource _battleSound;

    private void Start()
    {
        _battleSound = GetComponent<AudioSource>();
    }
}
