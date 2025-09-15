using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, healSound, walkSound, deathSound;
    static AudioSource audioSrc;

    void Start()
    {
        // Load audio clips from Resources folder
        playerHitSound = Resources.Load<AudioClip>("plaayerHit");
        healSound = Resources.Load<AudioClip>("heal");
        walkSound = Resources.Load<AudioClip>("walk");
        deathSound = Resources.Load<AudioClip>("death");

        // Get AudioSource component
        audioSrc = GetComponent<AudioSource>();

        if (audioSrc == null)
        {
            Debug.LogError("AudioSource component is missing from the GameObject.");
        }
    }

    public static void PlaySound(string clip)
    {
        if (audioSrc == null)
        {
            Debug.LogError("AudioSource is not initialized.");
            return;
        }

        switch (clip)
        {
            case "heal":
                audioSrc.PlayOneShot(healSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "walk":
                audioSrc.PlayOneShot(walkSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            default:
                Debug.LogWarning($"No matching sound found for clip: {clip}");
                break;
        }
    }
}
