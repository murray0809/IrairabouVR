using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] AudioClip BGM1;
    [SerializeField] AudioClip BGM2;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartBGM1()
    {
        audioSource.PlayOneShot(BGM1);
    }

    public void StartBGM2()
    {
        audioSource.PlayOneShot(BGM2);
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
