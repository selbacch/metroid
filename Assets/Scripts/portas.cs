using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portas : MonoBehaviour
{
    private Animator CAnimation;
    public bool ver = false;
    public GameObject trava;
    public GameObject joga;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }







    void OnTriggerEnter2D(Collider2D collider)
        {
            // If the player hits the trigger.
            if (collider.gameObject.tag == "tiro1")
            {
            CAnimation.SetBool("abre", true);



            // More on game controller shortly.
            

            trava.SetActive(false);
            CAnimation.SetBool("fecha", false);

            //accelerationSpeed = 0.1f;
            

        }
        }

    void OnTriggerExit2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")
        {
            CAnimation.SetBool("fecha", true);
            CAnimation.SetBool("abre", false);

           
            // More on game controller shortly.


            trava.SetActive(true);


            //accelerationSpeed = 0.1f;


        }
    }


}


 
