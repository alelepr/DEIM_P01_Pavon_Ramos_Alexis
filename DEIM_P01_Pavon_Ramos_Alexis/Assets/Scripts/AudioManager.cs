using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //refactorizar

    //Patrón Singleton
    public static AudioManager instance;

    //Audio
    [Tooltip("Referencia al Audio Source de los pasos")]
    [SerializeField] private AudioSource footstepsAudioSource;

    [Tooltip("Referencia al Audio Source de los objetos recogibles")]
    [SerializeField] private AudioSource objectsAudioSource;

    [Tooltip("Referencia al Audio Clip de las gemas")]
    [SerializeField] private AudioClip gemsAudioClip;

    [Tooltip("Referencia al Audio Clip de las llaves")]
    [SerializeField] private AudioClip keysAudioClip; 
    
    [Tooltip("Referencia al Audio Clip de las pociones de curacion")]
    [SerializeField] private AudioClip healthAudioClip;

    [Tooltip("Referencia al Audio Clip de las pociones de cargas")]
    [SerializeField] private AudioClip chargesAudioClip;

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

    public static void PlayGemsSound() {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.gemsAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayKeysSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.keysAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayHealthPotionSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.healthAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayChargesPotionSound()
    {

        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.chargesAudioClip;
            instance.objectsAudioSource.Play();
        }
    }



}
