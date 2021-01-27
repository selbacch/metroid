using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float tiro;
    public GameObject item;
    public GameObject item2;
    public bool hit = false;
    public GameObject inimigo;
    private Animator CAnimation;
    public float dano;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void loot()
    {
        Transform point = inimigo.transform;
        System.Random r = new System.Random();
        int randomIndex = r.Next(2);
        switch (randomIndex)
        {


            case 0:


                GameObject CloneTiro1 = Instantiate(item, point.position, point.rotation);


                break;

            case 1:

                GameObject CloneTiro = Instantiate(item2, point.position, point.rotation);




                break;





        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().DamagePlayer(dano);

          

        }


        if (other.tag == "tiro1")
        {
            CAnimation.SetBool("explosion", true);
            inimigo.GetComponent<deathen>().ativa = true;
            loot();
        }

        if (other.tag == "missil")
        {
            CAnimation.SetBool("explosion", true);
           inimigo.GetComponent<deathen>().ativa = true;
            loot();

        }


        






    }


    void morreu() {
        inimigo.SetActive(false);
        loot();
    }
}
