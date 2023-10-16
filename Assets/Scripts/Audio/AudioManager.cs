using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Audio Mixer
    [SerializeField]
    private AudioMixer audioMixer;

    // Audio Sources
    [SerializeField]
    private AudioSource[] musicAudioSources = new AudioSource[2];   // music played from this audio source
    [SerializeField]
    private AudioSource[] sfxAudioSources = new AudioSource[4];     // ui sounds played from this audio source, Using only a single source, if clip changes instantly, has a clicking sound(sharp disconnect of waveform)

    // Sounds
    [SerializeField]
    private AudioClip[] musicAudioClips = new AudioClip[1];
    [SerializeField]
    private AudioClip[] sfxAudioClips = new AudioClip[3];

    private int MUSIC_AUDIO_SOURCE_COUNT = 2; // how many Music channels we have to fade beteween music selections
    private int SFX_AUDIO_SOURCE_COUNT = 4; // how many SFX channels can we have playing

    private int MUSIC_AUDIO_CLIP_COUNT = 2; // the Music audio we can choose from
    private int SFX_AUDIO_CLIP_COUNT = 3; // the SFX audio clips we can chose from

    // Variables
    private float overallVolumeDB = 0.0f; // should range from ~0 dB for normal volume and to ~-60 to ~-80 to be near zero volume
    private float musicVolumeDB = 0.0f;
    private float sfxVolumeDB = 0.0f;

    // Tracking current sources
    private int currentMusicSource = 0;
    private int currentSFXSource = 0;

    public enum SFXAudioType
    {
        ResponsePositive,
        ResponseNegative,
        Hover, // scroll ?
    }

    #region Singleton and Awake initialization
    public static AudioManager manager;
    void Awake()
    {
        if (manager != null)
        {
            Debug.LogWarning("Calling extra AudioManager creation script!!!");
            return;
        }
        manager = this;

        // Awake Initialization
        // Music and SFX Clip Count (may need to move to Start, dependeing on initialization)
        MUSIC_AUDIO_SOURCE_COUNT = musicAudioSources.Length;
        SFX_AUDIO_SOURCE_COUNT = sfxAudioSources.Length;
        MUSIC_AUDIO_CLIP_COUNT = musicAudioClips.Length;
        SFX_AUDIO_CLIP_COUNT = sfxAudioClips.Length;
    }
    #endregion

    void Start()
    {
        // Start Initialization (move most stuff to Awake)

        // Startup Music Test Play
        //PlayMusic(0);
    }

    // TODO: Music Channel Swapping, Fading
    #region MusicPlays
    public void PlayMusic()
    {
        musicAudioSources[currentMusicSource].Play();
    }
    public void PlayMusic(int musicClipIndex)
    {
        if (musicClipIndex < MUSIC_AUDIO_CLIP_COUNT)
        {
            musicAudioSources[currentMusicSource].clip = musicAudioClips[musicClipIndex];
            musicAudioSources[currentMusicSource].Play();
        }
        else
        {
            Debug.LogError("Invalid Music Index Given!");
        }
    }

    public void PauseMusic()
    {
        musicAudioSources[currentMusicSource].Pause();
    }
    #endregion

    #region SFX Plays
    public void PlaySFX(int sfxClipIndex)
    {
        if (sfxClipIndex < SFX_AUDIO_CLIP_COUNT)
        {
            sfxAudioSources[currentSFXSource].clip = sfxAudioClips[sfxClipIndex];
            sfxAudioSources[currentSFXSource].Play();
            if (currentSFXSource < SFX_AUDIO_SOURCE_COUNT - 1)
            {
                // increment for next audio source to play from
                currentSFXSource++;
            }
            else
            {
                // reset to zero for next audio source to play from
                currentSFXSource = 0;
            }
        }
        else
        {
            Debug.LogError("Invalid Music Index Given!");
        }
    }
    public void PlaySFX(SFXAudioType sfxClipIndex)
    {
        if ((int)sfxClipIndex < SFX_AUDIO_CLIP_COUNT)
        {
            sfxAudioSources[currentSFXSource].clip = sfxAudioClips[(int)sfxClipIndex];
            sfxAudioSources[currentSFXSource].Play();
            if (currentSFXSource < SFX_AUDIO_SOURCE_COUNT - 1)
            {
                // increment for next audio source to play from
                currentSFXSource++;
            }
            else
            {
                // reset to zero for next audio source to play from
                currentSFXSource = 0;
            }
        }
        else
        {
            Debug.LogError("Invalid Music Index Given!");
        }
    }

    public void PlayHover()
    {
        sfxAudioSources[currentSFXSource].clip = sfxAudioClips[(int)SFXAudioType.Hover];
        sfxAudioSources[currentSFXSource].Play();
        if (currentSFXSource < SFX_AUDIO_SOURCE_COUNT - 1)
        {
            // increment for next audio source to play from
            currentSFXSource++;
        }
        else
        {
            // reset to zero for next audio source to play from
            currentSFXSource = 0;
        }
    }

    public void PlayResponseNegative()
    {
        sfxAudioSources[currentSFXSource].clip = sfxAudioClips[(int)SFXAudioType.ResponseNegative];
        sfxAudioSources[currentSFXSource].Play();
        if (currentSFXSource < SFX_AUDIO_SOURCE_COUNT - 1)
        {
            // increment for next audio source to play from
            currentSFXSource++;
        }
        else
        {
            // reset to zero for next audio source to play from
            currentSFXSource = 0;
        }
    }

    public void PlayResponsePositive()
    {
        sfxAudioSources[currentSFXSource].clip = sfxAudioClips[(int)SFXAudioType.ResponsePositive];
        sfxAudioSources[currentSFXSource].Play();
        if (currentSFXSource < SFX_AUDIO_SOURCE_COUNT - 1)
        {
            // increment for next audio source to play from
            currentSFXSource++;
        }
        else
        {
            // reset to zero for next audio source to play from
            currentSFXSource = 0;
        }
    }
    #endregion

    #region Volume Setting
    /// <summary>
    /// Input a volume from ~0 (0.0005) to 1, will convert it to DBs and set Audio Mixer
    /// </summary>
    /// <param name="volume"></param>
    public void SetOverallVolume(float volume)
    {
        //overallVolumeDB = volume; // Raw 1 to 1 value from slider is not how audio is perceived, is logarthimic
        overallVolumeDB = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Master", overallVolumeDB);
    }
    public void SetMusicVolume(float volume)
    {
        musicVolumeDB = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Music", musicVolumeDB);
    }
    public void SetSFXVolume(float volume)
    {
        sfxVolumeDB = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("SFX", sfxVolumeDB);
    }

    /// <summary>
    /// If already converted to DB, pass in volume here
    /// </summary>
    /// <param name="volumeDB"></param>
    public void SetOverallVolumeDB(float volumeDB)
    {
        //overallVolumeDB = Mathf.Log10(volume) * 20;
        overallVolumeDB = volumeDB;
        audioMixer.SetFloat("Master", overallVolumeDB);
    }
    public void SetMusicVolumeDB(float volumeDB)
    {
        musicVolumeDB = volumeDB;
        audioMixer.SetFloat("Music", musicVolumeDB);
    }
    public void SetSFXVolumeDB(float volumeDB)
    {
        sfxVolumeDB = volumeDB;
        audioMixer.SetFloat("SFX", sfxVolumeDB);
    }
    #endregion
}
