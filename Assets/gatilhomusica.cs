using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilhomusica : MonoBehaviour
{
    public Collider2D other;
    public Collider2D collider;
    public bool ver=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (ver = GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver==true)
        {

            GetComponent<tocacena>().TocaMusica3();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.tag == "Player")
        {
            
           GetComponent<tocacena>().TocaMusica1();
            GetComponent<EdgeCollider2D>().gameObject.SetActive(false);
        }

     }

 




}
