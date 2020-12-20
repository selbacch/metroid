using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portas : MonoBehaviour
{
    [HideInInspector] public AnimationController ac;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }














    void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "tiro1")

            ac.PlayAnimation(1);
        {


              // More on game controller shortly.
            Debug.Log("foi");



            //accelerationSpeed = 0.1f;


        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "tiro1")


        {

            ac.PlayAnimation(2);
          
            // More on game controller shortly.
            Debug.Log("foi");
            //this.transform.Find("Ridley").GetComponent<toca>().PararEfeito();


            //accelerationSpeed = 0.1f;


        }
    }
}