using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public bool isOpened = true; //Открыто ли меню

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //Кнопка выхода 
        {
            GoToMain();
        }
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("Menu"); //Переход на сцену с названием Menu
    }

    public void QuitGame()
    {
        Application.Quit(); //Закрытие игры
    }
}