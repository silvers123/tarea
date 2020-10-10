using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    /*public LineRenderer Laser;
    public float laser_leng;

    public Transform camara;
    public float magnitude;
    Vector3 originalpos;
    public LayerMask objetos_chocar;*/

    public LineRenderer Laser;

    public Transform Camara;
    public float Magnitud;

    //creacion del delegado
    delegate void AccionesPuertas();
    AccionesPuertas MiDelegado;
    //---------------------------
    delegate void AccionesDamage();
    AccionesDamage MiDelegado2;

    //va a almacenar con lo que esta chocando el laser
    GameObject objeto_hit;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {

        //Presionado
        if (Input.GetMouseButton(0))
        {
             float posX = Random.Range(-1.0f, 1.0f) * Magnitud;
             float posY = Random.Range(-1.0f, 1.0f) * Magnitud;

             Camara.position = new Vector3(posX, posY, -10.0f);

            //PlayTemblor();



            //la posicion del Player(issac) = transform.position

            //como la coloco en el laser?
            Laser.enabled = true;
            Laser.SetPosition(0, transform.position);


            //necesito obtener la posicion del mouse
            Vector3 MousePosition = Input.mousePosition;
            //procesos de conversion de posiciones, de la pantalla al mundo
            Vector3 NewMousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            //Vector3 direction = point_B - point_A;

            Vector3 direction = NewMousePosition - transform.position;

            //Vector3 point_C = point_A + (direction.normalized * distance);

            Vector3 point_C = transform.position + (direction.normalized * 200);

            Debug.DrawLine(transform.position, point_C);


            RaycastHit2D hit = Physics2D.Raycast(transform.position, point_C);

            //si estoy chocanco con algo
            if (hit.collider != null)
            {
                Debug.Log("Estas chocando con: " + hit.collider.name);

                //asignacion
                Laser.SetPosition(1, hit.point);
                //ASIGNANDO EL OBJETO CON EL QUE CHOCO
                objeto_hit = hit.collider.gameObject;
               

                switch (objeto_hit.tag) {

                    case "door_0":
                        //ASIGNACION DEL DELEGADO
                        MiDelegado = PintarPuertaAzul;
                        MiDelegado2 = Damage;
                        break;

                    case "door_1":
                        //ASIGNACION DEL DELEGADO
                        MiDelegado = PintarPuertaRoja;
                        break;
                    case "door_2":
                        MiDelegado = PintarAleatorio;
                        break;

                }

                
                //EJECUCION
                MiDelegado();
                MiDelegado2();

            }
            //no estoy chocando con nada
            else {
                Debug.Log("No estas chocando");

                //asignacion
                Laser.SetPosition(1, point_C);
            }



           
        }
        else {

            Laser.enabled = false;
        }


        //Presiono una vez
        if (Input.GetMouseButtonDown(0)) {
            //activando el laser
            
        }

        //Dejo de Presionar
        if (Input.GetMouseButtonUp(0))
        {
            //Desactivando
           
        }





        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        /*


        if (Input.GetMouseButtonDown(0)) {
            originalpos = camara.position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            camara.position = originalpos;
        }


        if (Input.GetMouseButton(0))
        {
            Laser.enabled = true;
            Vector3 mousePos = Input.mousePosition;

            Vector3 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
            Vector3 point_C = transform.position + (direction.normalized * laser_leng);

            Laser.SetPosition(0, transform.position);

            RaycastHit2D hit = Physics2D.Raycast(transform.position,point_C,100, objetos_chocar);

            Debug.DrawRay(transform.position, point_C,Color.green);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Laser.SetPosition(1, hit.point);

            }
            else {
                Laser.SetPosition(1, point_C);
            }
        

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camara.position = new Vector3(x, y, -10f);
        }
        else {
            Laser.enabled = false;
        }


        */

    }
    //-------------
    //FUNCION PARA CAMBIAR EL COLOR
    void PintarPuertaRoja() {
        Debug.Log("SE PINTA DE ROJO");
        //hacer el cambio de color
        objeto_hit.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void PintarPuertaAzul() {

        Debug.Log("SE PINTA DE AZUL");
        objeto_hit.GetComponent<SpriteRenderer>().color = Color.blue;

    }

    //------------




    public void PaintRed(SpriteRenderer door_sprite) {
        door_sprite.color = Color.red;

    }

    public void PaintBlue(SpriteRenderer door_sprite)
    {
        door_sprite.color = Color.blue;

    }
    public void Damage() {
        Debug.Log("HACIENDO DAÑO");
    }

    public void PintarAleatorio() {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        Color RandomColor = new Color(r, g, b);
        objeto_hit.GetComponent<SpriteRenderer>().color = RandomColor;
           

    }


}
