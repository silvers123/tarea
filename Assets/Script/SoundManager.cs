using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Sonido0;
    public AudioClip Sonido1;
    public AudioClip Sonido2;
    public AudioSource Reproductor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReproducirAudioLevel() {
        Reproductor.Stop();
        Reproductor.clip = Sonido1;
        Reproductor.Play();
    }
    public void ReproducirAudioLevelIntro() {
        Reproductor.Stop();
        Reproductor.clip = Sonido2;
        Reproductor.Play();
    }
}
