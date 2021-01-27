using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text _text; // 

    public  int count = 0;
    void Start()
    {
       


    }
    private void Update()
    {
        bool missil = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ms.misseis;
        bool bomb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ms.bombs;
        int count1 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().tradGun;
        if (count1 == 0) {  _text.gameObject.SetActive(false); }
        if (missil == true && count1==1)
        {
            
            _text.gameObject.SetActive(true);
            count = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mcontm;
            _text.text = count.ToString("10/00");
        }
        if (bomb == true && count1 == 2)
        {
            _text.gameObject.SetActive(true);

            count = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().bcontb;
            _text.text = count.ToString("10/00");

        }
    }
}//void MetodoQualquer(){
//TextManager.count++;//adicionar ao controle ou player quando pegar a munição
