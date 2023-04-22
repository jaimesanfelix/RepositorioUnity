using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPartida : MonoBehaviour
{
    // Start is called before the first frame update
    public ControlJugador jugador;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(jugador.vidas < 0)
        {
            SceneManager.LoadScene("FinalPartida");
        }
    }


    

}
