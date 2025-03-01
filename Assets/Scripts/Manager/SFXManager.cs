using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : PersistantSingleton<SFXManager>
{
    public List<SFXData> sfxList = new();
    private Dictionary<string, AudioClip> sfxDictionary = new();

    [SerializeField] AudioSource audioSource_music;
    [SerializeField] AudioSource audioSource_sound;

    protected override void Awake()
    {
        base.Awake();
        foreach (var sfx in sfxList)
        {
            sfxDictionary[sfx.key] = sfx.clip;
        }

        PlayMusic();
    }

    private void OnDestroy()
    {
        
    }
    
    public void PlayMusic(float volume = 1.0f)
    {
        if (sfxDictionary.TryGetValue("Music", out AudioClip clip))
        {
            audioSource_music.clip = clip;
            audioSource_music.volume = volume;
            audioSource_music.Play();
        }
        else
        {
            Debug.LogWarning("Music is not founded!");
        }
    }
    

    public void PlaySFX(string key, float volume = 1.0f)
    {
        if (sfxDictionary.TryGetValue(key, out AudioClip clip))
        {
            audioSource_sound.clip = clip;
            audioSource_sound.volume = volume;
            audioSource_sound.Play();
        }
        else
        {
            Debug.LogWarning("SFX is not founded: " + key);
        }
    }

}

[System.Serializable]
public class SFXData
{
    public string key;
    public AudioClip clip;
}
