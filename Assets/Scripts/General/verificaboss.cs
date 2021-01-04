using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verificaboss : MonoBehaviour
{
    public GameObject other;
    
    
    
    void OnDestroy() {

       
        GameObject.FindGameObjectWithTag("alert").GetComponent<alert>().ver=true;
        GameObject.FindGameObjectWithTag("portaboss").GetComponent<portasceres>().aciona = false;
        GameObject.Find("Fullmap").GetComponent<giramapa>().roda = false;
        GameObject.FindGameObjectWithTag("destrocos").GetComponent<ParticleSystem>().Play(true);
        
    }
}
