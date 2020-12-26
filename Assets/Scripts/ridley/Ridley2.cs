using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridley2 : MonoBehaviour
{
    public Collider2D colisor;
  

























    void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")

        {

            TEvi = true;
            // More on game controller shortly.
            Debug.Log("foi");

        }

        //accelerationSpeed = 0.1f;



    }


}
