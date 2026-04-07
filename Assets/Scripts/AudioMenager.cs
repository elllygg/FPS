using UnityEngine;
using UnityEngine.UI;  // Importa UI per lo slider

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // AudioManager

    [Header("Audio Sources")]
    public AudioSource sfxSource;  // fonte principale per effetti sonori

    [Header("Audio Clips")]
    
    public AudioClip gameOverClip;
    public AudioClip victoryClip;
    public AudioClip shootClip;

    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float soundVolume = 1f;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // non distruggere tra le scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // imposta il volume dal valore dello slider
    public void SetVolume(float volume)
    {
        soundVolume = volume;

        // se il gioco è in pausa controlla il volume separatamente
        if (sfxSource != null)
        {
            sfxSource.volume = soundVolume;  
        }
    }
    // funzioni per i suoni principali

    public void PlayGameOver() => PlaySFX(gameOverClip);
    public void PlayVictory() => PlaySFX(victoryClip);
    public void PlayShoot() => PlaySFX(shootClip);

   
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, soundVolume);
    }
}