using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vapor : MonoBehaviour
{
    private Animator CAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        this.transform.Find("dano").GetComponent<BoxCollider2D>().gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver == true)
        {
           
            CAnimation.SetBool("vapo", true);

        }
    }

    void ativa()
    {
        this.transform.Find("dano").GetComponent<BoxCollider2D>().gameObject.SetActive(true);
    }
    void desativa()
    {
        this.transform.Find("dano").GetComponent<BoxCollider2D>().gameObject.SetActive(false);
    }


}
