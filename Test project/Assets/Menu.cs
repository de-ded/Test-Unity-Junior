using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню

   
    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; // Вкл/выкл Canvas
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //Кнопка выхода 
        {
            ShowHideMenu();
        }
    }
      public void GoToMain()
    {
        SceneManager.LoadScene("Menu"); //Переход на сцену с названием Menu
    }

    public void QuitGame()
    {
        Application.Quit(); //Закрытие игры.
    }
}
