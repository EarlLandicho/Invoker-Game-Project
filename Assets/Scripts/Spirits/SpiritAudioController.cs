using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] private float resetAudioCountTimer;
    private int audioClipCount;
    private AudioSource audioSource;
    private SpiritCast spiritCast;
    private float resetAudioCountTimerTemp;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();
        spiritCast.CastSuccessful += PlaySound;
    }

    private void Update()
    {
        if (resetAudioCountTimerTemp >= 0)
        {
            resetAudioCountTimerTemp -= Time.deltaTime;
        }
        else
        {
            audioClipCount = 0;
        }
    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(audioClips[audioClipCount]);
        audioClipCount++;
        if (audioClipCount >= audioClips.Length)
        {
            audioClipCount = 0;
        }
        resetAudioCountTimerTemp = resetAudioCountTimer;
    }
}
