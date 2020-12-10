using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using System;


public class Lemb : MonoBehaviour
{
    private Collider[] Colisores;

    public float TempoDaImagem = 0;

    public Image _Imagem;
    void Start()
    {
        _Imagem.enabled = false;

        Colisores = transform.GetComponentsInChildren<Collider>();
    }

    void OnTriggerEnter()
    {
        StartCoroutine(EsperarTempo(TempoDaImagem));
    }

    IEnumerator EsperarTempo(float tempo)
    {
        _Imagem.enabled = true;

        foreach (Collider coll in Colisores)
        {
            coll.enabled = false;
        }
        yield return new WaitForSeconds(tempo);
        _Imagem.enabled = false;

    }



    void Update()
    {
        Debug.Log("talvez aqui ");
        GameObject scripts = GameObject.Find("Scripts");
        TimeCena controle = (TimeCena)scripts.GetComponent(typeof(TimeCena));
        if (controle.lemb1 != false)
        {
         //   TempoDaImagem = 4;
          //  OnTriggerEnter();

            Debug.Log("Aqui");    }

    }
}