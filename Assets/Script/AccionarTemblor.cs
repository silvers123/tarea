using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionarTemblor : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Camara;
    public float Magnitud;


   /* private void OnEnable()
    {
        MovePlayer.PlayTemblor += HacerTemnblor; 
    }

    private void OnDisable()
    {
        MovePlayer.PlayTemblor -= HacerTemnblor;
    }*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HacerTemnblor() {

        Debug.Log("Tamblando");
        float posX = Random.Range(-1.0f, 1.0f) * Magnitud;
        float posY = Random.Range(-1.0f, 1.0f) * Magnitud;

        Camara.position = new Vector3(posX, posY, -10.0f);
    }
}
