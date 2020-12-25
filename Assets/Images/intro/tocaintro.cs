using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocaintro : MonoBehaviour
{ 


    [SerializeField] private AudioClip musica1;
    [SerializeField] private AudioClip musica2;

    [SerializeField] private AudioClip efeito1;
    [SerializeField] private AudioClip efeito2;
    [SerializeField] private AudioClip efeito3;
    [SerializeField] private AudioClip efeito4;
    [SerializeField] private AudioClip efeito5;
    [SerializeField] private AudioClip efeito6;

    public void TocaMusica1()
    {
        sons.instance.TocarBGM(musica1);
    }

    public void TocaMusica2()
    {
        sons.instance.TocarBGM(musica2);
    }

    public void PararMusica()
    {
        sons.instance.PararBGM();
    }

    public void TocaEfeito1()
    {
        sons.instance.TocarSFX(efeito1);
    }

    public void TocaEfeito2()
    {
        sons.instance.TocarSFX(efeito2);
    }
    public void TocaEfeito3()
    {
        sons.instance.TocarSFX(efeito3);
    }
    public void TocaEfeito4()
    {
        sons.instance.TocarSFX(efeito4);
    }
    public void TocaEfeito5()
    {
        sons.instance.TocarSFX(efeito5);
    }
    public void TocaEfeito6()
    {
        sons.instance.TocarSFX(efeito6);
    }

    public void PararEfeito()
    {
        sons.instance.PararSFX();
    }
}