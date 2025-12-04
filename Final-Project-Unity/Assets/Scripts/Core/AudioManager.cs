using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /* Singleton Audio Manager to handle music and sound effects */
    
    public static AudioManager Instance { get; private set; }

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public AudioClip endLevelMusic;

    [Header("SFX")]
    public AudioClip clockTick;
    public AudioClip clueFoundSound;
    public AudioClip cluePickupSound;
    public AudioClip carEngineSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    // need two sources for engine sound to get increased volume
    private AudioSource engineSource;
    private AudioSource engineSource2;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxSource = gameObject.AddComponent<AudioSource>();

        engineSource = gameObject.AddComponent<AudioSource>();
        engineSource.loop = true;
        engineSource.volume = 1f;

        engineSource2 = gameObject.AddComponent<AudioSource>();
        engineSource2.loop = true;
        engineSource2.volume = 1f;

        // game starts in menu
        PlayMusic(menuMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        /* Play background music */

        if (clip == null) return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        /* Stop background music */

        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        /* Play sound effect */

        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    public void PlayEngine(AudioClip clip)
    {
        /* Play car engine sound */

        if (clip == null) return;

        if (engineSource.clip == clip && engineSource.isPlaying)
            return;

        engineSource.clip = clip;
        engineSource2.clip = clip;
        engineSource.Play();
        engineSource2.Play();
    }

    public void StopEngine()
    {
        /* Stop car engine sound */

        engineSource.Stop();
        engineSource2.Stop();
    }
}