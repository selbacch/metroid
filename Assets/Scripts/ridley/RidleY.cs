using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridley : MonoBehaviour
{
    [HideInInspector] public fogo fire;
    public GameObject fogo;
    public Transform point;
    public float Speed = 1;
    public Transform Target;
    public Transform Target2;
    public bool TEvi = false;
    public float TargetDistance = 5;
    public Collider2D target1;
    public bool dis = false;
    public float cronometro;
    private Vector3 posicaoinicial;
    public Vector3 direction;



    void Start() { posicaoinicial = Target2.position - transform.position; }
    void Update()
    {
        if (TEvi != false)
        {


            hunt();
            

        }
    }


    void hunt()
    {
        cronometro += Time.deltaTime;
        // Padrão: ir na direção do alvo
        direction = Target.position - transform.position;
               // direction.y = 0;
                float distanceToTarget = direction.magnitude;

                direction.Normalize();

                // Mas se ja estiver perto demais, na verdade quero fugir.
                // Inverte a direção anterior.
                if (distanceToTarget < TargetDistance)
                {
                    direction = -direction;
            
                  }
                
                
            
        
        if (distanceToTarget == TargetDistance)
        {
            System.Random r = new System.Random();
            int randomIndex = r.Next(3);
            atack(randomIndex);
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

        

        Debug.Log(randomIndex);
    
       switch (randomIndex) {


         case 1:
                cronometro = 0;
                TargetDistance = 0;
              Speed = 25;
            if (cronometro >= 4) volta();
                break;

            case 2:
                cronometro = 0;
                TargetDistance = 5;
               Debug.Log("labareda");
                GameObject.Find("Labareda").GetComponent<ParticleSystem>().Play();
                
               
                if (cronometro >= 6) Debug.Log("labareda fim "); volta(); GameObject.Find("Labareda").GetComponent<ParticleSystem>().Stop();
        
       break;
        }
    }           

    void volta()
    {
        Debug.Log("quase");
      
        Speed = 3; TargetDistance = 10;
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

        //accelerationSpeed = 0.1f;



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




