using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singletonPlayer;
    Rigidbody2D rb2d;    
    public GameObject cannon;
    int delayBala = 0;
    public float velocidad;
    int vidas = 3;
    int cargas = 3;

    public delegate void Bomb();
    public event Bomb BombRelease;

    //poolObject
    public int poolSize = 20;
    public GameObject bala;
    GameObject[] bullets;
    public int index = -1;


    void Awake()
    {
        singletonPlayer = this;
        rb2d = GetComponent<Rigidbody2D>();
        cannon = transform.Find("Cannon").gameObject;
    }

    private void Start()
    {
        bullets = new GameObject[poolSize];
        for(int i= 0; i < poolSize; i++)
        {
            bullets[i] = Instantiate(bala, new Vector3(10, 10, 0), Quaternion.identity);
            bullets[i].SetActive(false);
        }
        PlayerPrefs.SetInt("Cargas", cargas);
    }
    void Update()
    {
        //Controles basicos Movimiento
        rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * velocidad, 0));
        rb2d.AddForce(new Vector2(0,Input.GetAxis("Vertical") * velocidad));

        if (Input.GetKey(KeyCode.Space)&&delayBala>10)
        {
            index++;
            if (index > poolSize-1)
            {
                index = 0;
            }
            bullets[index].transform.position = transform.position;
            bullets[index].SetActive(true);
            //Disparar(1);
        } else if(Input.GetKeyDown(KeyCode.Q)&&delayBala>10 && cargas > 0)
        {
            BombRelease?.Invoke();
            cargas--;
            PlayerPrefs.SetInt("Cargas", cargas);
            //Disparar(2);
        }
        delayBala++;        
    }


    void Disparar(int num)
    {
        if (num == 1)
        {
            delayBala = 0;
            Instantiate(bala, cannon.transform.position, Quaternion.identity);
        }else if(num == 2 && cargas>0)
        {            
            ////GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            ////for(int i = 0; i < enemigos.Length; i++)
            ////{
            ////    enemigos[i].GetComponent<IA_EnemigoBasico>().DestruirEnemigo(0);
            ////}
            //cargas--;
            //PlayerPrefs.SetInt("Cargas", cargas);
        }
    }

    public void DanioAJugador()
    {
        vidas--;
        PlayerPrefs.SetInt("Cargas", cargas);
        if (vidas == 0)
        {

            Destroy(gameObject);
        }
    }

    public void AgregarCarga()
    {
        cargas++;
        PlayerPrefs.SetInt("Cargas", cargas);
    }
}
