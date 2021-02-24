using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtons : MonoBehaviour
{

    public AudioSource SBSource;
    public AudioClip zero;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    public AudioClip seven;
    public AudioClip eight;
    public AudioClip nine;

    // Start is called before the first frame update
    void Start()
    {
        SBSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        NumPadSounds();
    }

     public void NumPadSounds()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SBSource.PlayOneShot(zero);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SBSource.PlayOneShot(one);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SBSource.PlayOneShot(two);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SBSource.PlayOneShot(three);
        }
    }
}
