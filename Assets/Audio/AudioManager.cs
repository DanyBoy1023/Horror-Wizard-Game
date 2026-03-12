using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management operations

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Static instance to ensure only one exists

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // If an instance already exists, destroy the new one
            return;
        }

        instance = this; // Set the current object as the instance
        DontDestroyOnLoad(this.gameObject); // Prevent the object from being destroyed on scene load
    }

    // You can add methods here to play/stop different audio clips as needed
    public void PlayMusicClip(AudioClip clip)
    {
        // Reference the AudioSource component and play the clip
        AudioSource source = GetComponent<AudioSource>();
        if (source != null && source.clip != clip)
        {
            source.clip = clip;
            source.Play();
        }
    }

    public void StopMusic()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source != null)
        {
            source.Stop();
        }
    }
}
