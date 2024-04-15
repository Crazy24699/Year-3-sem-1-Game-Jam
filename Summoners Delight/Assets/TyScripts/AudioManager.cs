using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();
    public AudioSource audioSource;
   Hashtable hashmap;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        hashmap = new Hashtable(clipList.Count);
        foreach (AudioClip clip in clipList)
        {
            hashmap.Add(clip.name, clip);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySound(string soundName)
    {
        AudioClip clip = (AudioClip)hashmap[soundName];
        if(clip == null)return;
        Debug.Log(clip.name);
        audioSource.PlayOneShot(clip);
    }
}
