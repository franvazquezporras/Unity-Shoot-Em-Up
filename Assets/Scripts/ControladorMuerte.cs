using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMuerte : MonoBehaviour
{
    GameObject jugador;
    bool muerte = false;
    
    

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(jugador == null && !muerte)
        {
            FinJuego();
        }
    }

    void FinJuego()
    {
        muerte = true;
        comprobarRecord();        
        StartCoroutine(CargarPantallaGameOver());
    }
     
    void comprobarRecord()
    {
        int puntuacion = PlayerPrefs.GetInt("Puntuacion");
        int aux;
        for (int i = 0; i <= 10; i++)
        {
            if (puntuacion> PlayerPrefs.GetInt("Puntuacion"+i))
            {
                aux = PlayerPrefs.GetInt("Puntuacion" + i);
                PlayerPrefs.SetInt("Puntuacion" + i,puntuacion);
                puntuacion =  aux;
            }
        }
        
    }

    IEnumerator CargarPantallaGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
