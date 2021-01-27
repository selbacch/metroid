using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunhud : MonoBehaviour
{
    private Animator CAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        int count = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().tradGun;
        bool missil = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ms.misseis;
        bool bomb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ms.bombs;
        if (count==0)
        {
            CAnimation.SetBool("padrao", true);
            CAnimation.SetBool("missel", false);
            CAnimation.SetBool("bomb", false);
        }
        if (count == 1 && missil == true)
        {
            CAnimation.SetBool("missel", true);
            CAnimation.SetBool("padrao", false);
            CAnimation.SetBool("bomb", false);
        }
        if (count == 2 && bomb == true)
        {
            CAnimation.SetBool("bomb", true);
            CAnimation.SetBool("missel", false);
            CAnimation.SetBool("padrao", false);
        }
    }
}
