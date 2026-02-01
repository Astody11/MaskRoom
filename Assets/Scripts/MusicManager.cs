using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    //[Header("Audio")]
    [SerializeField] private AudioSource musicSource;

    [Header("Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float volume = 0.5f;

    private AudioClip currentClip;

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.volume = volume;
    }

    // ▶️ Reproduce una música
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        // Evita reiniciar la misma música
        if (currentClip == clip && musicSource.isPlaying)
            return;

        currentClip = clip;
        musicSource.clip = clip;
        musicSource.Play();
    }

    // ⏸ Pausar
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // ▶️ Reanudar
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    // ⏹ Detener
    public void StopMusic()
    {
        musicSource.Stop();
        currentClip = null;
    }

    // 🎚 Cambiar volumen
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        musicSource.volume = volume;
    }

    // 🔊 Getter opcional
    public float GetVolume()
    {
        return volume;
    }
}
