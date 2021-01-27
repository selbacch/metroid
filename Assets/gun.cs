using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.LeftArrow,
       rightKey = KeyCode.RightArrow,
      Upkey = KeyCode.UpArrow,
       DownKey = KeyCode.DownArrow,
       UlKey = KeyCode.Q,
       UrKey = KeyCode.E,
       jumpKey = KeyCode.S,
       ActionKey = KeyCode.W,
       ShoKey = KeyCode.D,
        Dlkey = KeyCode.A,
        Drkey = KeyCode.F;
        private Animator CAnimation;
    public GameObject alvo;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

       // if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().estado == false) { CAnimation.SetBool("direita", true); } else { CAnimation.SetBool("direita", false); }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().estado != false) { CAnimation.SetBool("esquerda", true); } else { CAnimation.SetBool("esquerda", false); }
        if (Input.GetKey(Upkey)) { CAnimation.SetBool("up", true); } else { CAnimation.SetBool("up", false); }
        if (Input.GetKey(DownKey)) { CAnimation.SetBool("down", true); } else { CAnimation.SetBool("down", false); }
        if (Input.GetKey(UlKey) ) { CAnimation.SetBool("ul", true); } else { CAnimation.SetBool("ul", false); }
        if (Input.GetKey(UrKey) ) { CAnimation.SetBool("ur", true); } else { CAnimation.SetBool("ur", false); }
        if (Input.GetKey(Dlkey) ) { CAnimation.SetBool("dl", true); } else { CAnimation.SetBool("dl", false); }
        if (Input.GetKey(Drkey) ) { CAnimation.SetBool("dr", true); } else { CAnimation.SetBool("dr", false); }
    }

   
}