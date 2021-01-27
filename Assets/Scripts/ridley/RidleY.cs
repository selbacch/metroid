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
    private float timeDestroy;
    public bool TEvi = false;
    public float TargetDistance = 5;
    public Collider2D collider;
    public bool dis = false;
    public float cronometro;
    public float cronometro1;
    public float dano;
    public bool flip = false;
    public Vector3 direction;
    public bool hito = false;
    private SpriteRenderer mySpriteRenderer;
    public Color Hcolor;
    void Start() {
        CAnimation = GetComponent<Animator>();


        this.transform.Find("tail").GetComponent<EdgeCollider2D>().gameObject.SetActive(false); // desativa o colider

        mySpriteRenderer = GetComponent<SpriteRenderer>();




    }
    void Update()
    {

        if (TEvi != false)
        {
            hunt();

            cronometro += Time.deltaTime;
            cronometro1 += Time.deltaTime;

        }
        damage();
    }
    void portaboss()
    {

        GameObject.FindGameObjectWithTag("portaboss").GetComponent<portasceres>().aciona = true;
    }
    public void damage()
    {
        if (GetComponent<Health>().hit != false)
        {
            mySpriteRenderer.color = Hcolor;
            CAnimation.SetBool("hit", true);
            Invoke("NormalizaCor", 0.5f); //tempo para voltar a cor normal
        }
    }
    void NormalizaCor()
    {
        mySpriteRenderer.color = Color.white;
    }

    public void damageoff()
    {
        CAnimation.SetBool("hit", false);
    }
 public  void death()
    {
       

        cronometro1 = 60f;
        CAnimation.SetBool("fuga", true);
        atack(4);



    }
   void fuga()
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }





    void hunt()
    {
        
        this.transform.Find("segura").GetComponent<EdgeCollider2D>().gameObject.SetActive(false); // desativa o colider

        direction = Target.position - transform.position;
        // direction.y = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();


        if (distanceToTarget < TargetDistance)
        {
            direction = -direction;
        }
      
        
    

        if (cronometro1 >= 3)
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


        switch (randomIndex)
        {


            case 1:


                CAnimation.SetBool("investida", true);


                break;

            case 2:

                CAnimation.SetBool("atack1", true);




                break;

            case 0:
                CAnimation.SetBool("tail", true);
                break;



            case 4:
                volta();
                break;
        }
    }           




    private void investida()
    {
        TargetDistance = 0;
        Speed = 45;
        dano = 0.5f;
    }

    private void Labareda()
    {

        Speed = 5;
        dano = 0.02f;
        TargetDistance = 5;
       
        GameObject.Find("Labareda").GetComponent<ParticleSystem>().Play(true);



    }

    private void tail()
    {

        Speed = 5;
        dano = 0.2f;
        TargetDistance = 5;
        
        this.transform.Find("tail").GetComponent<EdgeCollider2D>().gameObject.SetActive(true); // desativa o colider



    }


    private void tailStop()
    {

        this.transform.Find("tail").GetComponent<EdgeCollider2D>().gameObject.SetActive(false); // desativa o colider

        CAnimation.SetBool("tail", false);
        volta();

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
        
        
        cronometro1 = 0;
                Speed = 3; TargetDistance = 9;
        float voltas = direction.magnitude; 
          direction = -direction;


       


    }












    void OnTriggerEnter2D(Collider2D collider)
    {




        if (collider.gameObject.tag == "Player")
        {



            CAnimation.SetBool("entrada", true);

        }

    }
        void hunter()
        {
            CAnimation.SetBool("entrada", false);
            TEvi = true;

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




