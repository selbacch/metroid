using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luzelevador : MonoBehaviour
{

    public float cronometro;
    public Light myLight;
    public bool ver;
    public Color target;
    public Color target2;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }
        


    void cronos()
    {



        if (cronometro >= 1)
        {

            myLight.intensity = 1.5f;

            myLight.color = target;
        }


        if (cronometro <= 3)
        {

            myLight.intensity = 1.5f;

            myLight.color = target2;
        }


        if (cronometro >= 5)
        {
            cronometro = 0;
        }

    }
        void Update()
        {
            ver = GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver;
        
        if (ver == true)
            {
                cronometro += Time.deltaTime;
                cronos();
            }

        }
    

}