using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colide : MonoBehaviour
{
    public bool mus = false;

    public Collider2D target1;
    void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")


        {


            mus = true;
                // More on game controller shortly.
                Debug.Log("foi");
               


                //accelerationSpeed = 0.1f;

            
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")


        {


            mus = false;
            // More on game controller shortly.
            Debug.Log("foi");
            //this.transform.Find("Ridley").GetComponent<toca>().PararEfeito();


            //accelerationSpeed = 0.1f;


        }
    }



}