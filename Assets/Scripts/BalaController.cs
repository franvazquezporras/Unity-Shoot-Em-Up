using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{

    Rigidbody2D rb2d;
    int direccion = 1;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
  

    public void CambiarDireccion()
    {
        direccion *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(direccion == 1)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
            {
                collision.gameObject.GetComponent<IA_EnemigoBasico>().DanioEnemigo();
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().DanioAJugador();
                Destroy(gameObject);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0,20 * direccion);
    }
}
