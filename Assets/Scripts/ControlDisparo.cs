using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject disparoPrefab;

    public Transform puntoSalidaBala;

    private ControlJugador controlJugador;

    private void Awake()
    {
        controlJugador = GetComponent<ControlJugador>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bala = Instantiate(disparoPrefab);
            bala.transform.position = puntoSalidaBala.position;
            if (!controlJugador.MirandoDerecha())
            {
                bala.GetComponent<Disparo>().SetDireccion(controlJugador.MirandoDerecha()); // bala.GetComponent<Disparo>().velocidad * -1;
                bala.GetComponent<SpriteRenderer>().flipX = true;
                Vector3 v = new Vector3(bala.transform.position.x * -1, bala.transform.position.y, bala.transform.position.z);
                bala.transform.position = v;
            }
            
            bala.SetActive(true);
        }

    }
}
