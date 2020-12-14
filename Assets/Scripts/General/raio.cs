using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class raio : MonoBehaviour
{
    Light myLight;

    //public float tempoParaCarregar = 150;
    public float cronometro;



  
    void Start()
    {
     
        //myLight.intensity = 0.5;

        myLight = GetComponent<Light>();
    }


    
    void cronos()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= 4.629f)
        {


            myLight.intensity = 10;

        }
        if (cronometro >= 4.639f)
        {


            myLight.intensity = 0.5f;

        }

        if (cronometro >= 23.533f)
        {


            myLight.intensity = 10;

        }
        if (cronometro >= 23.543f)
        {


            myLight.intensity = 0.5f;

        }


        if (cronometro >= 53.814f)
        {


            myLight.intensity = 10;

        }

        if (cronometro >= 53.824f)
        {


            myLight.intensity = 0.5f;

        }
        if (cronometro >= 71.637f)
        {


            myLight.intensity = 10;

        }
        if (cronometro >= 71.647f)
        {


            myLight.intensity = 0.5f;

        }


        if (cronometro >= 73.000f)
        {


            myLight.intensity = 10;

        }
        if (cronometro >= 71.0010f)
        {


            myLight.intensity = 0.5f;

        }


        if (cronometro >= 99.475f)
        {


            myLight.intensity = 10;

        }
        if (cronometro >= 99.485f)
        {


            myLight.intensity = 0.5f;

        }

        if (cronometro >= 114.549f)
        {


            myLight.intensity = 10;


        }
        if (cronometro >= 114.559f)
        {


            myLight.intensity = 0.5f;

        }

        if (cronometro >= 128.998f)
        {


            myLight.intensity = 10;

        }
        if (cronometro >= 128.108f)
        {


            myLight.intensity = 0.5f;

        }


        if (cronometro >= 151f)
        {


            cronometro = 0;
        }
    }

    
    void Update()
    {
        cronos();
       
    }
}

