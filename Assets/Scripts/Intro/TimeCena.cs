

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCena : MonoBehaviour
{
    [HideInInspector] public AnimationController ac;
    public string NomeDaCena = "cena";
    public float tempoParaCarregar = 188;

    public int cronometro;
    public bool lemb1 = false;


    void contagem()
    {
        cronometro++;
        if (cronometro >= 4)
        {
            // trovao_1.Play();
            ac.PlayAnimation(1);

            cronometro = 0;
        }
    }

        
        

void Update()
    {
    // cronometro += Time.deltaTime;
    //if (cronometro ==1.000)
    //{
    //  Debug.Log("aqui foi");
    // lemb1 = true;

    //gps.ac.PlayAnimation(1);

    // }

    contagem();

    }
}