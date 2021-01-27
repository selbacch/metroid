using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop: MonoBehaviour
{
    public GameObject trigger;
    public bool animatic = false;
    public float Ridley0;
    public Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // enquanto estiver em colisão com outro (plataforma)
   // void OnTriggerStay2D(Collider2D other)
    //{

     //   if (other.tag == "Plataforma")
      //  {
        //    Debug.Log("ai mulek");
        //GameObject.Find("Player").transform.parent = other.transform;
         //   animatic = true;

//        }


       
   // }
     


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Ridley")
        {

            playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            Debug.Log(Ridley0);
            Ridley0 = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Ridley>().dano;
            playerHealth.DamagePlayer(Ridley0);

        }

        if (other.tag == "destrocos")
        {
            
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            Debug.Log(Ridley0);
            Ridley0 = 0.3f;
            playerHealth.DamagePlayer(Ridley0);

        }
        if(other.tag == "enemyshot")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            Debug.Log(Ridley0);
            Ridley0 = 3f;
            playerHealth.DamagePlayer(Ridley0);
        }


        if (other.tag == "Plataforma1")
        {
            Debug.Log("ai mulek");
            GameObject.Find("Player").transform.parent = other.transform;
            animatic = true;

        }



        if (other.tag == "Plataforma")
        {
            Debug.Log("ai mulek");
            GameObject.Find("Player").transform.parent = other.transform;
            animatic = true;

        }
       // else { GameObject.Find("Player").transform.parent = GameObject.Find("Fullmap").transform; }
    }

   
    // quando sair da colisão com a plataforma
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Plataforma")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().plataforma();
            GameObject.Find("Player").transform.parent = null;
            animatic = false;
            GameObject.Find("Player").transform.parent = GameObject.Find("Fullmap").transform;
        }

        if (other.tag == "Plataforma1")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().plataforma();
            GameObject.Find("Player").transform.parent = null;
            animatic = false;
           
        }


    }


}
