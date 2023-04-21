using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private float velocidad = 30;

    public void SetDireccion(bool derecha)
    {
        if((!derecha))
        {
            velocidad *= -1;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }


    }

}
