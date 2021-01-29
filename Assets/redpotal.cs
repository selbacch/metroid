using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redpotal : MonoBehaviour
{
    private Animator CAnimation;
    public int ver = 2;
    public string trava;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();


      
    }

    void Update()
    {
        if (ver <= 0)
        {
            CAnimation.SetBool("abre", true);
            this.transform.Find(trava).GetComponent<BoxCollider2D>().gameObject.SetActive(false);
            CAnimation.SetBool("fecha", false);
        }
    }

   
    void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "missil")
        {
            ver = ver -1;



            
           

            

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

            ver = 2;
            // More on game controller shortly.
            Debug.Log("saindo");

            this.transform.Find(trava).GetComponent<BoxCollider2D>().gameObject.SetActive(true);


            //accelerationSpeed = 0.1f;


        }
    }


}