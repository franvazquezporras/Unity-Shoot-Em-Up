using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_EnemigoBasico : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject Bala,Explosion,cargaExplosiva;
    public bool disparoDisponible;
    public float vida;
    public float disparoRango;

    public float velocidadX;
    public float velocidadY;
    public int puntos;

    private void OnEnable()
    {
        PlayerController.singletonPlayer.BombRelease += BombaJugador;
    }
    private void OnDisable()
    {
        PlayerController.singletonPlayer.BombRelease -= BombaJugador;
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
 
    void Start()
    {
        
        if (!disparoDisponible) return;
        disparoRango = disparoRango + (Random.Range(disparoRango / -2, disparoRango / -2));
        InvokeRepeating("Disparar", disparoRango, disparoRango);
        
    }

    void Update()
    {
        rb2d.velocity = new Vector2(velocidadX,velocidadY*-1);

     
    }
    void Disparar()
    {
        GameObject temporal = (GameObject) Instantiate(Bala, transform.position, Quaternion.identity);
        temporal.GetComponent<BalaController>().CambiarDireccion();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Boss")
            {
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().DanioAJugador();
                Destroy(gameObject);
            }
            
        }   
    }


    public void BombaJugador()
    {
        vida -= 50;
        if (vida <= 0)
        {
            DestruirEnemigo(0);
        }
    }
    public void DanioEnemigo()
    {
        
        vida--;
        if (vida <= 0)
        {
            DestruirEnemigo(0);
        }
    }
    public void DestruirEnemigo(int colisionconJugador)
    {
        if(colisionconJugador != 1) {
            if (Random.Range(0, 3) == 0)
            {
                Instantiate(cargaExplosiva, transform.position, Quaternion.identity);
            }
            PlayerPrefs.SetInt("Puntuacion", PlayerPrefs.GetInt("Puntuacion") + puntos);            
        }
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
