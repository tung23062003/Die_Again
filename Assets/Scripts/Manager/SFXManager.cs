using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    public List<SFXData> sfxList = new();
    private Dictionary<string, AudioClip> sfxDictionary = new();

    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        foreach (var sfx in sfxList)
        {
            sfxDictionary[sfx.key] = sfx.clip;
        }

    }

    private void OnDestroy()
    {
        
    }

    

    public void PlaySFX(string key, Vector3 position, float volume = 1.0f)
    {
        if (sfxDictionary.TryGetValue(key, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.transform.position = position;
            audioSource.Play();
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
