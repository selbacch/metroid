using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geemer : MonoBehaviour
{
    private Animator CAnimation;
    public Collider2D collision;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pointB")
        {
            
            CAnimation.SetBool("virar", true);
            CAnimation.SetBool("virad", false);
            CAnimation.SetBool("viral", false);
           
            //transform.Translate(Vector2.up * 1 * Time.deltaTime);

        }
        if (collision.tag == "pointC")
        {
            CAnimation.SetBool("virar", false);
            CAnimation.SetBool("viral", false);
            
            CAnimation.SetBool("virad", true);

            //transform.Translate(Vector2.up * 1 * Time.deltaTime);

        }
        if (collision.tag == "pointD")
        {
            CAnimation.SetBool("virar", false);
            CAnimation.SetBool("virad", false);
            
            CAnimation.SetBool("viral", true);

            //transform.Translate(Vector2.up * 1 * Time.deltaTime);

        }

        if (collision.tag == "pointA")
        {
            CAnimation.SetBool("virar", false);
            CAnimation.SetBool("virad", false);
            
            CAnimation.SetBool("viral", false);

            //transform.Translate(Vector2.up * 1 * Time.deltaTime);

        }

        //transform.Translate(Vector2.right * 1 * Time.deltaTime);
    }


}
