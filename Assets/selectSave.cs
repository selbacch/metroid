using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectSave : MonoBehaviour
{
    private Animator CAnimation;
    public bool vira = false;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vira == true)
        {
            CAnimation.SetBool("vira", true);
        }
    }



    public void Troca() { SceneManager.LoadScene("intro"); }

}
