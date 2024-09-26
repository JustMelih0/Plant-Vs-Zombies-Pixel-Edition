using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;
    public AudioSource musicSource, sfxSource;
    public Sound[] musicSounds, sfxSounds;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x=>x.name==name);
        if (s == null)
        {
            Debug.Log("müzik bulunamadı");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x=>x.name==name);
        if (s == null)
        {
            Debug.Log("Sfx bulunamadı");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }





}


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
