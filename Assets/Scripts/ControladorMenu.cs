using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void IniciarJuego()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Salir()
    {
        SceneManager.LoadScene("Inicio");
    }

}
