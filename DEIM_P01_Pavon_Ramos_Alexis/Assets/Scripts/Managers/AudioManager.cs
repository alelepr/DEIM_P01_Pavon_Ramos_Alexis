using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //refactorizar

    //Patrón Singleton
    public static AudioManager instance;


    [SerializeField] public AudioSource audioSourceBGM;

    //Audio personaje
    [Tooltip("Referencia al Audio Source de los pasos")]
    [SerializeField] private AudioSource footstepsAudioSource;

    [Tooltip("Referencia al Audio Source del daño")]
    [SerializeField] private AudioSource hurtAudioSource;

    [Tooltip("Referencia al Audio Source del salto")]
    [SerializeField] private AudioSource jumpAudioSource;

    [Tooltip("Referencia al Audio Source del hechizo")]
    [SerializeField] private AudioSource spellAudioSource;


    //Audio Objetos
    [Tooltip("Referencia al Audio Source de las pociones")]
    [SerializeField] private AudioSource potionsAudioSource;

    [Tooltip("Referencia al Audio Source de las gemas y llave")]
    [SerializeField] private AudioSource gemsAudioSource;

    [Tooltip("Referencia al Audio Source de las puertas")]
    [SerializeField] private AudioSource doorsAudioSource;


    //Audio música
    [Tooltip("Referencia al Audio Source de la capilla")]
    [SerializeField] private AudioSource capillaAudioSource;

    [Tooltip("Referencia al Audio Source del main menu")]
    [SerializeField] private AudioSource mainMenuAudioSource;

    [Tooltip("Referencia al Audio Source del game over")]
    [SerializeField] private AudioSource gameOverAudioSource;

    [Tooltip("Referencia al Audio Source de la victoria")]
    [SerializeField] private AudioSource winAudioSource;

    [Tooltip("Referencia al Audio Source del click")]
    [SerializeField] private AudioSource clickAudioSource;





    //----------------------------------------------
    //AUDIOCLIPS

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

    [Tooltip("Referencia al Audio Clip de la victoria")]
    [SerializeField] private AudioClip winAudioClip;

    [Tooltip("Referencia al Audio Clip del click")]
    [SerializeField] private AudioClip clickAudioClip;

    [Tooltip("Referencia al Audio Clip del altar al curar")]
    [SerializeField] private AudioClip altarAudioClip;

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
             instance.footstepsAudioSource.pitch = Random.Range(0.9f,1.2f);
             instance.footstepsAudioSource.Play();

         }
        
    }

    public static void PlayGemSound()
    {

        if (!instance.gemsAudioSource.isPlaying)
        {
            instance.gemsAudioSource.clip = instance.gemsAudioClip;
            instance.gemsAudioSource.Play();
        }
    }

    public static void PlayWinSound()
    {

        if (!instance.winAudioSource.isPlaying)
        {
            instance.winAudioSource.clip = instance.winAudioClip;
            instance.winAudioSource.Play();
        }
    }

    public static void PlayClickSound()
    {

        if (!instance.clickAudioSource.isPlaying)
        {
            instance.clickAudioSource.clip = instance.clickAudioClip;
            instance.clickAudioSource.Play();
        }
    }

    public static void PlayHurtSound()
    {

        if (!instance.hurtAudioSource.isPlaying)
        {
            instance.hurtAudioSource.clip = instance.hurtAudioClip;
            instance.hurtAudioSource.Play();
        }
    }

    public static void PlayJumpSound()
    {

        if (!instance.jumpAudioSource.isPlaying)
        {
            instance.jumpAudioSource.clip = instance.jumpAudioClip;
            instance.jumpAudioSource.Play();
        }
    }

    public static void PlayDoorSound()
    {

        if (!instance.doorsAudioSource.isPlaying)
        {
            instance.doorsAudioSource.clip = instance.doorAudioClip;
            instance.doorsAudioSource.Play();
        }
    }

    public static void PlayKeySound()
    {

        if (!instance.gemsAudioSource.isPlaying)
        {
            instance.gemsAudioSource.clip = instance.keysAudioClip;
            instance.gemsAudioSource.Play();
        }
    }

    public static void PlayAltarSound()
    {

        if (!instance.gemsAudioSource.isPlaying)
        {
            instance.gemsAudioSource.clip = instance.altarAudioClip;
            instance.gemsAudioSource.Play();
        }
    }

    public static void PlayPotionSound()
    {

        if (!instance.potionsAudioSource.isPlaying)
        {
            instance.potionsAudioSource.clip = instance.potionAudioClip;
            instance.potionsAudioSource.Play();
        }

    }

    public static void PlaySpellSound()
    {

        if (!instance.spellAudioSource.isPlaying)
        {
            instance.spellAudioSource.clip = instance.spellAudioClip;
            instance.spellAudioSource.Play();
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
