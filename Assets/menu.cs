using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;



using System;
public class menu : MonoBehaviour
{
    public Slider musicaVolume;
    public Slider efeitoVolume;
    public KeyCode inicia = KeyCode.KeypadEnter;
    public Button Botaojogar;
    public Button Botaojogar1;
    public Button Botaojogar2;
    public Button BotaoEscolha;
    public Button BotaoSair;
    public Button BotaoVoltar;
        public Button BotaoOpcoes;
    public Image capacete;
    public Image capacete1;
    public Image capacete2;
    public Image _Imagem;
    // Start is called before the first frame update
    void Start()
    {
        BotaoVoltar.onClick = new Button.ButtonClickedEvent();
        BotaoEscolha.onClick = new Button.ButtonClickedEvent();
        BotaoOpcoes.onClick = new Button.ButtonClickedEvent();
        Botaojogar.onClick = new Button.ButtonClickedEvent();
        Botaojogar1.onClick = new Button.ButtonClickedEvent();
        Botaojogar2.onClick = new Button.ButtonClickedEvent();
        BotaoOpcoes.onClick = new Button.ButtonClickedEvent();
        BotaoSair.onClick = new Button.ButtonClickedEvent();
        Botaojogar.onClick.AddListener(() => Jogar());
        Botaojogar1.onClick.AddListener(() => Jogar1());
        Botaojogar2.onClick.AddListener(() => Jogar2());
        BotaoEscolha.onClick.AddListener(() => Opcoes3(true));
        BotaoOpcoes.onClick.AddListener(() => Opcoes2(true));
        BotaoVoltar.onClick.AddListener(() => voltar());
        BotaoSair.onClick.AddListener(() => Sair());
        Opcoes(false);
        Opcoes2(false);
        Opcoes3(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inicia))
        {
            Opcoes(true);
        }
    }


    private void Opcoes(bool ativarOP)
    {
        _Imagem.gameObject.SetActive(ativarOP);
        BotaoEscolha.gameObject.SetActive(ativarOP);
        BotaoOpcoes.gameObject.SetActive(ativarOP);
        BotaoSair.gameObject.SetActive(ativarOP);
       
    }

    private void Opcoes3(bool ativarOP)
    {
        Opcoes(false);
        _Imagem.gameObject.SetActive(ativarOP);
        capacete.gameObject.SetActive(ativarOP);
        capacete1.gameObject.SetActive(ativarOP);
        capacete2.gameObject.SetActive(ativarOP);
        Botaojogar.gameObject.SetActive(ativarOP);
        Botaojogar1.gameObject.SetActive(ativarOP);
        Botaojogar2.gameObject.SetActive(ativarOP);
        BotaoVoltar.gameObject.SetActive(ativarOP);





        //    BotaoOpcoes.gameObject.SetActive(!ativarOP);
        //  BotaoSair.gameObject.SetActive(!ativarOP);

    }

    private void Opcoes2(bool ativarOP2)
    {
        Opcoes(false);
        _Imagem.gameObject.SetActive(ativarOP2);
        BotaoVoltar.gameObject.SetActive(ativarOP2);
        // BotaoEscolha.gameObject.SetActive(!ativarOP2);
        // BotaoOpcoes.gameObject.SetActive(!ativarOP2);
        //BotaoSair.gameObject.SetActive(!ativarOP2);
        //
        //textoVol.gameObject.SetActive(ativarOP2);
        musicaVolume.gameObject.SetActive(ativarOP2);
       efeitoVolume.gameObject.SetActive(ativarOP2);
        //CaixaModoJanela.gameObject.SetActive(ativarOP2);
        //Resolucoes.gameObject.SetActive(ativarOP2);
        //Qualidades.gameObject.SetActive(ativarOP2);
        //BotaoVoltar.gameObject.SetActive(ativarOP2);
        //BotaoSalvarPref.gameObject.SetActive(ativarOP2);
    }

    private void voltar()
    {
        Opcoes3(false);
        Opcoes2(false);
        Opcoes(true);
    }
    private void Jogar()
    {

        GameObject.FindGameObjectWithTag("UIAnimation").GetComponent<selectSave>().vira = true;
    }


    private void Jogar1()
    {

        GameObject.FindGameObjectWithTag("UIAnimation1").GetComponent<selectSave>().vira = true;
    }

    private void Jogar2()
    {

        GameObject.FindGameObjectWithTag("UIAnimation2").GetComponent<selectSave>().vira = true;
    }

    private void Sair()
    {
        Application.Quit();
    }

}
