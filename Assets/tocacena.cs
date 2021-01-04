using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocacena : MonoBehaviour
{


    [SerializeField] private AudioClip musica1;
    [SerializeField] private AudioClip musica2;
    [SerializeField] private AudioClip musica3;
    [SerializeField] private AudioClip musica4;

    [SerializeField] private AudioClip efeito1;
    [SerializeField] private AudioClip efeito2;

    public void TocaMusica1()
    {
        sons.instance.TocarBGM(musica1);
    }

    public void TocaMusica2()
    {
        sons.instance.TocarBGM(musica2);
    }

    public void TocaMusica3()
    {
        sons.instance.TocarBGM(musica3);
    }


    public void TocaMusica4()
    {
        sons.instance.TocarBGM(musica4);
    }

    public void PararMusica()
    {
        sons.instance.PararBGM();
    }

   
}
