using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilhomusica2 : MonoBehaviour
{
    // Start is called before the first frame update
  
    void OnTriggerEnter2D(Collider2D collider)
    {
      

        if (collider.tag=="Player") {
           GetComponent<tocacena>().PararMusica();
           GetComponent<tocacena>().TocaMusica2();
            GetComponent<EdgeCollider2D>().gameObject.SetActive(false);
        }

    }
   
}
