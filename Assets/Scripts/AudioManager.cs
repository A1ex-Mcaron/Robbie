using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;





public class AudioManager : MonoBehaviour
{
    static AudioManager current;


    [Header("��������")]
    public AudioClip ambientClip;
    public AudioClip musicClip;

    [Header("FX��Ч")]
    public AudioClip deathFXClip;
    public AudioClip orbFXClip;


    [Header("Robbie��Ч")]
    public AudioClip[] walkStepClips;
    public AudioClip[] CrouchStepClips;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    public AudioClip jumpVoiceClip;
    public AudioClip deathVoiceClip;
    public AudioClip orbVoiceClip;


    AudioSource ambientSource;
    AudioSource musicSource;
    AudioSource fxSource;
    AudioSource playerSource;
    AudioSource voiceSource;

    private void Awake()
    {
        current = this; 

        DontDestroyOnLoad(gameObject);

        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();


        StartLevelAudio();
    }

    void StartLevelAudio()
    {
        current.ambientSource.clip = current.ambientClip;
        current.ambientSource.loop = true;
        current.ambientSource.Play();

        current.musicSource.clip = current.musicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();


    }
    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0, current.walkStepClips.Length);

        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }

    public static void PlayCrouchFootstepAudio()
    {
        int index = Random.Range(0, current.CrouchStepClips.Length);

        current.playerSource.clip = current.CrouchStepClips[index];
        current.playerSource.Play();
    }

    public static void PlayJumpAudio()
    {
        current.playerSource.clip = current.jumpClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.jumpVoiceClip;
        current.voiceSource.Play();
    }

    public static void PlayDeathAudio()
    {
        current.playerSource.clip = current.deathFXClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.deathVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.deathFXClip;
        current.fxSource.Play();
    }

    public static void PlayOrbAudio()
    {
        current.fxSource.clip = current.orbFXClip;
        current.fxSource.Play();

        current.voiceSource.clip = current.orbVoiceClip;
        current.voiceSource.Play();
    }

}