using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public float[] spectrumWidth;
    public CalibrationTimer calibrationTimer;
    public PlayerUIController myUIController;

    //AudioSource
    // [Header("---------- Audi Source ----------")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource audioSource;

    // Audio Clip
    public AudioClip bombe;
    public AudioClip gameOver;
    public AudioClip juicySound;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void Awake()
    {
        spectrumWidth = new float[64];
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false; 
        instance = this;

    }

    void FixedUpdate()
    {
        if (calibrationTimer != null && calibrationTimer.aktivPlayerModus && myUIController.isOnGame && isActiveAndEnabled)
        {
            audioSource.GetSpectrumData(spectrumWidth, 0, FFTWindow.Blackman);
            audioSource.enabled = true;
        }
      
    }
    public float getFrequenciesDiapason(int start, int end, int mult)
    {
        return spectrumWidth.ToList().GetRange(start, end).Average() * mult;
    }

}
