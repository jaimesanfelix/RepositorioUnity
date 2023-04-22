using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ControlJugador : MonoBehaviour {

    private float velocidad = 10;
    public Animator controlEstados;
    private Rigidbody2D fisica;
    public int impulso = 200;
    public int vidas = 3;

    // Start is called before the first frame update
    void Start() {
        controlEstados = GetComponent<Animator>();
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private bool mirandoDerecha = true;
    void Update() {

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Time.deltaTime * velocidad, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            controlEstados.SetBool("estaCorriendo", true);
            mirandoDerecha = true;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Time.deltaTime * -velocidad, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            controlEstados.SetBool("estaCorriendo", true);
            mirandoDerecha = false;
        } else {

            controlEstados.SetBool("estaCorriendo", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) /*&& !controlEstados.GetBool("estaSaltando")*/) {
            fisica.AddForce(new Vector2(0, impulso));
            controlEstados.SetBool("estaSaltando", true);
        }
    }



    public bool MirandoDerecha() {
        return mirandoDerecha;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Suelo") {
            controlEstados.SetBool("estaSaltando", false);
        } else if (collision.gameObject.tag == "Enemigo") {
            vidas--;
        }
    }



}
