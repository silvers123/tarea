using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum ESTADOS_JUEGO { 
    INICIO,
    TRANSICION_JUEGO,
    TRANSICION_END,
    CAMBIO_NIVEL
}




public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image FadeImage;
    public float duracion_efect;
    public SoundManager Reproductor_Musica;

    public ESTADOS_JUEGO estado_actual;

    public GameObject Gordito;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //VOY A CREAR LA TRANSICION
    void transition(ESTADOS_JUEGO nuevo_estado) {
        //actualizando el estado
        estado_actual = nuevo_estado;

        switch (estado_actual) {

            case ESTADOS_JUEGO.INICIO:

                Debug.Log("ESTOY EN EL ESTADO INICIO");

                break;

            case ESTADOS_JUEGO.TRANSICION_JUEGO:

                Debug.Log("ESTOY EN EL ESTADO TRANSICION");

                Debug.Log("Cargar el Nivel: " + 1);
                //reproduciendo musica
                Reproductor_Musica.ReproducirAudioLevel();
                //haciendo un efecto de fadeout(DESVANECIMIENTO)
                StartCoroutine(FadeOut(1));



                break;

            case ESTADOS_JUEGO.TRANSICION_END:
                Debug.Log("Mostrar la animacion");
                Gordito.SetActive(true);

                Invoke("CambiarEscena",2.0f);
                

                break;

            case ESTADOS_JUEGO.CAMBIO_NIVEL:
                SceneManager.LoadScene(1);
                break;



        }

    }


    public void CambiarEscena() {
        transition(ESTADOS_JUEGO.CAMBIO_NIVEL);
    }


    //presiono un boton
    public void LevelButtonPress(int level) {

        //CUANDO PRESIONO EL BOTON PASO AL NUEVO ESTADO
        transition(ESTADOS_JUEGO.TRANSICION_JUEGO);

       
    }

    public void SetFadeInEffect() {
        StartCoroutine(FadeIn());
    }

    //PRENDIDO
    IEnumerator FadeIn() {

        float t = 0;
        Color color_actual = FadeImage.color;

        if (FadeImage.gameObject.activeSelf == false) {
            FadeImage.gameObject.SetActive(true);
        }

        while (t < duracion_efect) {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / duracion_efect);
            //Debug.Log(alpha);

            FadeImage.color = new Color(color_actual.r, color_actual.g, color_actual.b, alpha);

            yield return null;
        }

    }

    //APAGADO
    IEnumerator FadeOut(int level_index)
    {
        //reproduciendo Musica;

        float t = 0;
        Color color_actual = FadeImage.color;

        if (FadeImage.gameObject.activeSelf == false)
        {
            FadeImage.gameObject.SetActive(true);
        }

        while (t < duracion_efect)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / duracion_efect);
            Debug.Log(alpha);

            FadeImage.color = new Color(color_actual.r, color_actual.g, color_actual.b, alpha);

            yield return null;
        }

        //cambio de escena
        //SceneManager.LoadScene(level_index);
        transition(ESTADOS_JUEGO.TRANSICION_END);
    }
}
