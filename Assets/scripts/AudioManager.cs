using UnityEngine;
using Yarn.Unity;

public class AudioManager : MonoBehaviour
{
    // List of audio clips
    public AudioClip[] audioClips;

    // Reference to a single AudioSource
    private AudioSource audioSource;

    private void Start()
    {
        // Add an AudioSource component if it doesn't exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    [YarnCommand("play_audio")]
    public void PlayAudio(string clipName)
    {
        // Find the audio clip by name
        foreach (var clip in audioClips)
        {
            if (clip.name == clipName)
            {
                audioSource.clip = clip;
                audioSource.Play();
                Debug.Log($"Playing audio: {clipName}");
                return;
            }
        }

        Debug.LogError($"Audio clip '{clipName}' not found in the audioClips array.");
    }

    [YarnCommand("stop_audio")]
    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Audio stopped.");
        }
        else
        {
            Debug.Log("No audio is currently playing.");
        }
    }
}