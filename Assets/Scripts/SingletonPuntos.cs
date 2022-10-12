using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPuntos : MonoBehaviour
{
    public static SingletonPuntos singleton;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);

        }
        //DontDestroyOnLoad(gameObject);
    }
}
