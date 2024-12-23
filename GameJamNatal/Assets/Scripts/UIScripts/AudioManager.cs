using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public AudioClip sfxTakeDamage, sfxJump, sfxShoot, sfxConfirm, sfxCancel, sfxCollect, sfxNetxLevel;
    public AudioClip mscMenu, mscGame;

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


    //Sound Object
    //public GameObject soundObject;

    //public void PlaySFX(string sfxName)
    //{
    //    switch (sfxName)
    //    {
    //        case "walk":
    //            SoundObjectCreation(sfxTakeDamage);
    //            break;
    //        case "jump":
    //            SoundObjectCreation(sfxJump);
    //            break;
    //        case "confirm":
    //            SoundObjectCreation(sfxConfirm);
    //            break;
    //        case "cancel":
    //            SoundObjectCreation(sfxCancel);
    //            break;
    //        case "shoot":
    //            SoundObjectCreation(sfxShoot);
    //            break;
    //        case "collect":
    //            SoundObjectCreation(sfxCollect);
    //            break;
    //        case "nextlevel":
    //            SoundObjectCreation(sfxNetxLevel);
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public void PlayMusic(string mscName)
    //{
    //    switch (mscName)
    //    {
    //        case "menu":
    //            SoundObjectCreation(mscMenu);
    //            break;
    //        case "game":
    //            SoundObjectCreation(mscGame);
    //            break;            
    //        default:
    //            break;
    //    }
    //}
    //void SoundObjectCreation(AudioClip clip)
    //{
    //    GameObject newObject = Instantiate(soundObject, transform);
    //    newObject.GetComponent<AudioSource>().clip = clip;
    //    newObject.GetComponent<AudioSource>().Play();
    //}

    //void MusicObjectCreation(AudioClip clip)
    //{
    //    GameObject newObject = Instantiate(soundObject, transform);
    //    newObject.GetComponent<AudioSource>().clip = clip;
    //    newObject.GetComponent<AudioSource>().loop = true;
    //    newObject.GetComponent<AudioSource>().Play();
    //}
}
