using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonClickSound;

    public void PlaySound()
    {
        buttonClickSound.Play();
    }
}
