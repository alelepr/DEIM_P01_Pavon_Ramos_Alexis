using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //refactorizar

    //Patrón Singleton
    public static AudioManager instance;


    [SerializeField] public AudioSource audioSourceBGM;

    //Audio
    [Tooltip("Referencia al Audio Source de los pasos")]
    [SerializeField] private AudioSource footstepsAudioSource;

    [Tooltip("Referencia al Audio Source de los objetos recogibles")]
    [SerializeField] private AudioSource objectsAudioSource;

    [Tooltip("Referencia al Audio Source de la capilla")]
    [SerializeField] private AudioSource capillaAudioSource;

    [Tooltip("Referencia al Audio Source del main menu")]
    [SerializeField] private AudioSource mainMenuAudioSource;

    [Tooltip("Referencia al Audio Source del game over")]
    [SerializeField] private AudioSource gameOverAudioSource;

    [Tooltip("Referencia al Audio Clip del salto")]
    [SerializeField] private AudioClip jumpAudioClip;

    [Tooltip("Referencia al Audio Clip de las gemas")]
    [SerializeField] private AudioClip gemsAudioClip;

    [Tooltip("Referencia al Audio Clip de las llaves")]
    [SerializeField] private AudioClip keysAudioClip; 
    
    [Tooltip("Referencia al Audio Clip de las pociones")]
    [SerializeField] private AudioClip potionAudioClip;

    [Tooltip("Referencia al Audio Clip de os hechizos")]
    [SerializeField] private AudioClip spellAudioClip;

    [Tooltip("Referencia al Audio Clip de la puerta")]
    [SerializeField] private AudioClip doorAudioClip;

    [Tooltip("Referencia al Audio Clip de la capilla")]
    [SerializeField] private AudioClip capillaAudioClip;

    [Tooltip("Referencia al Audio Clip del daño")]
    [SerializeField] private AudioClip hurtAudioClip;


    private void Awake()
    {
        if (instance == null)
        {
            //guardamos el audio manager en esta misma variable para su uso global

            instance = this;
            //cuando haya cambio de escenas que no se destruya
            //los audiosources tienen que ser hijos de audiomanager para no ser destruidos
            DontDestroyOnLoad(gameObject);
        }
        else if(instance !=this) 
        {
            Destroy(gameObject);
        }
        
    }
    public static void PlayFootStepSound()
    {
        
         //Efecto de sonido para los pasos
         //Si el audio no se esta reproduciendo que lo haga
         if (!instance.footstepsAudioSource.isPlaying)
         {
            //Cambiamos el 
             instance.footstepsAudioSource.pitch = Random.Range(0.5f,1.5f);
             instance.footstepsAudioSource.Play();

         }
        
    }

    public static void PlayGemSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.gemsAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlaySound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.gemsAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayHurtSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.hurtAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayJumpSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.jumpAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayDoorSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.doorAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayKeySound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.keysAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayPotionSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.potionAudioClip;
            instance.objectsAudioSource.Play();
        }

    }
    public static void PlayPotion2Sound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.potionAudioClip;
            instance.objectsAudioSource.Play();
        }

    }

    public static void PlaySpellSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.spellAudioClip;
            instance.objectsAudioSource.Play();
        }

    }

    public static void PlayCapillaMusic()
    {

        if (!instance.capillaAudioSource.isPlaying)
        {
            instance.capillaAudioSource.clip = instance.capillaAudioClip;
            instance.audioSourceBGM.Stop();
            instance.capillaAudioSource.Play();
            instance.mainMenuAudioSource.Stop();
            instance.gameOverAudioSource.Stop();

        }

    }
    public static void PlayBGMMusic()
    {

        if (!instance.audioSourceBGM.isPlaying)
        {
            instance.audioSourceBGM.Play();
            instance.capillaAudioSource.Stop();
            instance.mainMenuAudioSource.Stop();
            instance.gameOverAudioSource.Stop();
            
        }

    }

    public static void PlayMainMenuMusic()
    {

        if (!instance.mainMenuAudioSource.isPlaying)
        {

            instance.mainMenuAudioSource.Play();
            instance.audioSourceBGM.Stop();
            instance.gameOverAudioSource.Stop();
            instance.capillaAudioSource.Stop();


        }

    }

    public static void PlayGameOverMusic()
    {

        if (!instance.gameOverAudioSource.isPlaying)
        {
          instance.gameOverAudioSource.Play();
          instance.audioSourceBGM.Stop();
          instance.mainMenuAudioSource.Stop();
          instance.capillaAudioSource.Stop();
          
        }

    }






}
