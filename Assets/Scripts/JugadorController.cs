using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
    private CharacterController controlador;
    private Vector3 direccion;
    public static float velocidadAvance=10;
    private int carrilElegido = 1; //El 0 es izq, el 1 es centro, el 2 es der
    public float distCarriles = 2.5f; // distancia entre los carriles
    public float fuerzaSalto;
    public float gravedad = -20;
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion.z = velocidadAvance;

        //Ver si vamos a saltar
        if (controlador.isGrounded)
        {
            //direccion.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Saltar();
            }
        }
        else {
            direccion.y += gravedad * Time.deltaTime;
        }


        //ver en que carril estamos
        if (Input.GetKeyDown(KeyCode.RightArrow) && carrilElegido != 2) { 
            carrilElegido++;    
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && carrilElegido != 0)
        {
            carrilElegido--;
        }
        Vector3 posicionObjetivo = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (carrilElegido == 0) {
            posicionObjetivo += Vector3.left * distCarriles;
        }
        else if (carrilElegido == 2) {
            posicionObjetivo += Vector3.right * distCarriles;
        }
        controlador.enabled = false;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, 80 * Time.deltaTime);
        controlador.enabled = true;
    }
    private void FixedUpdate()
    {
        controlador.Move(direccion * Time.fixedDeltaTime);
    }

    private void Saltar() {
        direccion.y = fuerzaSalto;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstaculo") { 
            JugadorManager.gameOver = true; 
        }
    }

}
