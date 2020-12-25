using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portas : MonoBehaviour
{
    [HideInInspector] public AnimationController ac;
    public Animator anim;
    public Collider2D collider;
    void Start()
    {

    }








    void Update()
    {







        void OnTriguedEnter2D(Collider2D collider)
        {
            // If the player hits the trigger.
            if (collider.gameObject.tag == "tiro1")
            {
                ac.PlayAnimation(1);



                // More on game controller shortly.
                Debug.Log("foi");



                //accelerationSpeed = 0.1f;


            }
        }
    }


    //void OnCollisionExit2D(Collider2D collider)
  //  {
      //  // If the player hits the trigger.
        //if (collider.gameObject.tag == "tiro1")


//        {

  //          ac.PlayAnimation(2);
          
    //        // More on game controller shortly.
      //8      Debug.Log("foi");
            //this.transform.Find("Ridley").GetComponent<toca>().PararEfeito();


            //accelerationSpeed = 0.1f;


//        }
  //  }
}