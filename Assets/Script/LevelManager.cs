using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public UIManager ui_manager;
    public SoundManager sonido_manager;

    void Start()
    {
        ui_manager.SetFadeInEffect();
        sonido_manager.ReproducirAudioLevelIntro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
