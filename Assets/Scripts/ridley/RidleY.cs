using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridley : MonoBehaviour
{
    [HideInInspector] public fogo fire;
    public GameObject fogo;
    private Animator CAnimation;
    public float Speed = 1;
    public Transform Target;
    public Transform Target2;
    public bool TEvi = false;
    public float TargetDistance = 5;
    public Collider2D collider;
    public bool dis = false;
    public float cronometro;
    public float cronometro1;
    
    public Vector3 direction;
    


    void Start() { CAnimation = GetComponent <Animator> (); }
    void Update()
    { 
        
        if (TEvi != false)
        {


            hunt();
          
    
            cronometro += Time.deltaTime;
        cronometro1 += Time.deltaTime;
        }
        

    }


    void hunt()
    {
       
        // Padrão: ir na direção do alvo
        direction = Target.position - transform.position;
               
                float distanceToTarget = direction.magnitude;

                direction.Normalize();

                // Mas se ja estiver perto demais, na verdade quero fugir.
                // Inverte a direção anterior.
                if (distanceToTarget < TargetDistance)
                {
                    direction = -direction;
            
                  }
        



        if ( cronometro1 >= 3)
        {
            System.Random r = new System.Random();
            int randomIndex = r.Next(3);
            atack(randomIndex);
            Debug.Log(randomIndex);
        }
        
            
        

        

        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
                float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

                MoveCharacter(actualMovementThisFrame * direction);
            }
        

        void MoveCharacter(Vector3 frameMovement)
        {
            transform.position += frameMovement;
        }






    void atack(int randomIndex)
    {


        cronometro = 0;


        switch (randomIndex) {


         case 1:
              

                CAnimation.SetBool("investida", true);


                break;

            case 2:
                
                CAnimation.SetBool("atack1",true);
              
               
                
        
       break;
        }
    }           




    private void investida()
    {
        TargetDistance = 0;
        Speed = 45;

    }

    private void Labareda()
    {

        Speed = 5;

        TargetDistance = 5;
        Debug.Log("labareda");
        GameObject.Find("Labareda").GetComponent<ParticleSystem>().Play(true);



    }




    private void LabaredaStop()
    {
        GameObject.Find("Labareda").GetComponent<ParticleSystem>().Stop();

        CAnimation.SetBool("atack1", false);
            volta();
            
    }

    private void InvestidaStop()
    {
        GameObject.Find("Labareda").GetComponent<ParticleSystem>().Stop();

        CAnimation.SetBool("investida", false);
        volta();

    }

    void volta()
    {
        
        Debug.Log("quase");
        cronometro1 = 0;
                Speed = 3; TargetDistance = 9;
        float voltas = direction.magnitude; 
          direction = -direction;


       


    }








    



void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")
        {

            TEvi = true;
            // More on game controller shortly.
            Debug.Log("foi");
          
        }

        



    }
}

   // void OnTriggerExit2D(Collider2D collider)
    //{
        // If the player hits the trigger.
      //  if (collider.gameObject.tag == "Player")


        //{


           
            // More on game controller shortly.
          //  Debug.Log("foi");
            //this.transform.Find("Ridley").GetComponent<toca>().PararEfeito();


            //accelerationSpeed = 0.1f;


  //      }
    //}




