using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ControlEnemigo: MonoBehaviour
{
    public float velocidad = 1;
    public float distanciaAtaque = 3;
    private Animator controlEstados;
    private Rigidbody2D fisica;
    public GameObject jugador;
    private new SpriteRenderer renderer;
    private bool alBordeDerecho = false;
    private bool alBordeIzquierdo = false;

    public enum Direccion { DERECHA, IZQUIERDA }

    public Direccion dirActual {
        get {
            return !renderer.flipX ? Direccion.DERECHA : Direccion.IZQUIERDA;
        }
    }

    public bool alBorde {
        get { return dirActual == Direccion.DERECHA && alBordeDerecho 
                || dirActual == Direccion.IZQUIERDA && alBordeIzquierdo; }
    }

    public void Flip() {
        renderer.flipX = !renderer.flipX;
        velocidad *= -1;
        Debug.Log("Cambiando de direccion...");
        Debug.Log("Direccion actual: " + dirActual);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        controlEstados = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        fisica = GetComponent<Rigidbody2D>();
        if(GetComponent<SpriteRenderer>().flipX ) { velocidad *= -1; }        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "LimitePlataforma") {
            Debug.Log("Entrando en colision con un limite de plataforma" + collider.gameObject.name);

            switch (dirActual) {
                case Direccion.DERECHA: alBordeDerecho = true; break;
                case Direccion.IZQUIERDA: alBordeIzquierdo = true; break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "LimitePlataforma") {
            Debug.Log("Saliendo de la colision por direccion " + dirActual);

            switch (dirActual) {
                case Direccion.DERECHA: alBordeIzquierdo = false; break;
                case Direccion.IZQUIERDA: alBordeDerecho = false; break;
            }
        }
    }

    public bool jugadorAtacable() {       

        Vector3 pos = transform.position;
        Vector3 posJugador = jugador.transform.position;

        float distancia = Vector2.Distance(pos, posJugador);       

        bool jugadorALaDerecha = pos.x < posJugador.x;
        bool jugadorALaIzquierda = !jugadorALaDerecha;

        bool peligroAtaque = jugadorALaDerecha && alBordeDerecho || jugadorALaIzquierda && alBordeIzquierdo;       

        //Debug.Log(distancia < distanciaAtaque && !peligroAtaque ? "Jugador Atacable" : "NO atacable");

        return distancia < distanciaAtaque && !peligroAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
