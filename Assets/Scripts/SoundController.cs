using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Button button;

    [SerializeField] AudioClip buttonSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
