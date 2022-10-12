using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }


    public void IniciarPartida()
    {
        PlayerPrefs.SetInt("Puntuacion", 0);
        SceneManager.LoadScene("Juego");
    }
    public void CambiarPantalla(int dato)
    {
        
        SceneManager.LoadScene(dato);
    }
}
