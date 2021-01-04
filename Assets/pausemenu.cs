using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

        [SerializeField] private bool isPause;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if (isPause)
        {

            ActiveMenu();
        }
        else { DesactiveMenu(); }


    }
    void ActiveMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);

    }
        
        void DesactiveMenu()
        {
        AudioListener.pause = false;
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        }
    
}