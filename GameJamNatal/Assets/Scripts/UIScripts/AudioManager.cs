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

    public AudioClip sfxWalk, sfxJump, sfxShoot, sfxConfirm, sfxCancel;
    public AudioClip mscMenu, mscGame;

    //Sound Object
    public GameObject soundObject;

    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "walk":
                SoundObjectCreation(sfxWalk);
                break;
            case "jump":
                SoundObjectCreation(sfxJump);
                break;
            case "confirm":
                SoundObjectCreation(sfxConfirm);
                break;
            case "cancel":
                SoundObjectCreation(sfxCancel);
                break;
            case "shoot":
                SoundObjectCreation(sfxShoot);
                break;
            default:
                break;
        }
    }

    public void PlayMusic(string mscName)
    {
        switch (mscName)
        {
            case "menu":
                SoundObjectCreation(mscMenu);
                break;
            case "game":
                SoundObjectCreation(mscGame);
                break;            
            default:
                break;
        }
    }
    void SoundObjectCreation(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().Play();
    }

    void MusicObjectCreation(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().loop = true;
        newObject.GetComponent<AudioSource>().Play();
    }
}
