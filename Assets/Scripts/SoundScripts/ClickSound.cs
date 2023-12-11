using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public static AudioSource click;

    private void Start()
    {
        click = GetComponent<AudioSource>();
    }

    public void StartClickSound()
    {
        click.Play();
    }
}
