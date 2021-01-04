using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class elevador : MonoBehaviour
{
    public KeyCode ActionKey = KeyCode.W;
    public Collider2D other;
    private Animator CAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("decendo", true);
    }



    void stopelevador()
    {
        CAnimation.SetBool("decendo", false);

    }
    // Update is called once per frame
    void Update()
    {
       

    }


   
 void OnTriggerEnter2D(Collider2D other)
    {

        if (GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver == true)
        {

            CAnimation.SetBool("subindo", true);
            Debug.Log("vvamos subir?");
        }


    }
    void encerra()
    {
        if(GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver == true)
        {
            SceneManager.LoadScene("fugaceres");
        }
    }


}
