using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sons : MonoBehaviour
{
    


    
        [SerializeField] private AudioSource musica;
        [SerializeField] private AudioSource efeito;

        public static sons instance;

        private void Awake()
        {
            instance = this;
        }

        public void TocarBGM(AudioClip _musica)
        {
        musica.clip = _musica;
        musica.Play();
        }

        public void PararBGM()
        {
            musica.Stop();
        }

        public void TocarSFX(AudioClip _efeitoSonoro)
        {
        efeito.PlayOneShot(_efeitoSonoro);
        }

        public void PararSFX()
        {
        efeito.Stop();
        }
    }