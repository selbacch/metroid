using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alert : MonoBehaviour
{
    private Animator CAnimation;
    public bool ver = false;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }
    private void alertoff()
    {
        CAnimation.SetBool("alert", false);
        GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver = true;
        ver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ver == true)
        {

            CAnimation.SetBool("alert", true);
        }
    }

    


}




