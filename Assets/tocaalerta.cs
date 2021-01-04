using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocaalerta : MonoBehaviour
{
    public bool ver= false;

    void Update()
    {
        
        if (ver == true) { 
            GetComponent<tocacena>().PararMusica();
            Debug.Log("corre nagada!!!");

            GetComponent<tocacena>().TocaMusica1();
        }
    }
       
}
