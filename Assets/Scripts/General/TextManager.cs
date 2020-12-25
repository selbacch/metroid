using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text _text; // 

    public static float count = 0;

    private void Update()
    {

        _text.text = count.ToString();

    }
}//void MetodoQualquer(){
//TextManager.count++;//adicionar ao controle ou player quando pegar a munição
