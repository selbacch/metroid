using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torizo : MonoBehaviour
{
    [HideInInspector] public fogo fire;
    public GameObject fogo;
    public GameObject tiro2;
    public Transform point2;
    public Transform point;
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
    public Rigidbody2D rb;
    public Color Hcolor;
    public Color Hcolor2;
    void Start()
    {
        CAnimation = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        this.transform.Find("mao").GetComponent<EdgeCollider2D>().gameObject.SetActive(false); // desativa o colider



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
        death();
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
            GetComponent<Health>().hit = false;
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
    public void death()
    {

        if (GetComponent<Health>().curHealth <= 0) { 
        TEvi = false;

        CAnimation.SetBool("death", false);
            GameObject.FindGameObjectWithTag("portaboss").GetComponent<portasceres>().aciona = false;
            atack(4);
    }



    }
    





    void hunt()
    {
        

        direction = Target.position - transform.position;
         direction.y = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();

        if(direction.x < 0) { CAnimation.SetBool("walk", true); }
        if (distanceToTarget < TargetDistance)
        {
            direction = -direction;
        }




        if (cronometro1 >= 1)
        {
            System.Random r = new System.Random();
            int randomIndex = Random.Range(0,3);
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


        cronometro1= 0;


        switch (randomIndex)
        {


            case 1:


                CAnimation.SetBool("atack1", true);
                CAnimation.SetBool("shot", false);

                break;

            case 2:

                CAnimation.SetBool("shot", true);
                CAnimation.SetBool("atack1", false);



                break;




            case 4:
                volta();
                break;
        }
    }




   

    private void shot()
    {

        Speed = 5;
        dano = 0.02f;
        TargetDistance = 12;

        if (mySpriteRenderer.flipX == false) { GameObject CloneTiro1 = Instantiate(fogo, point.position, point.rotation); }

        if (mySpriteRenderer.flipX == true) { GameObject CloneTiro1 = Instantiate(tiro2, point2.position, point2.rotation); }




    }

    private void atack1()
    {

        Speed = 8;
        dano = 0.2f;
        TargetDistance = 1;

        this.transform.Find("mao").GetComponent<EdgeCollider2D>().gameObject.SetActive(true); // desativa o colider



    }


    private void tailStop()
    {

        this.transform.Find("mao").GetComponent<EdgeCollider2D>().gameObject.SetActive(false); // desativa o colider

        CAnimation.SetBool("atack1", false);
        volta2();

    }


    private void shotStop()
    {
        
        CAnimation.SetBool("shot", false);
        volta();

    }

   

    void volta()
    {


        cronometro= 0;
        Speed =3; TargetDistance = 5;
        float voltas = direction.magnitude;
        
        direction = -direction;
        





    }


    void volta2()
    {
        cronometro = 0;
        Speed = 15; TargetDistance = 9;
        float voltas = direction.magnitude;

        direction = -direction;
        Vector2 diagonal;
        diagonal.x = 1;
        diagonal.y = 1;
        rb.AddForce(diagonal * 100f * 2f);
        volta();
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




