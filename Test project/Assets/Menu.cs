using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isOpened = false; //������� �� ����

   
    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; // ���/���� Canvas
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //������ ������ 
        {
            ShowHideMenu();
        }
    }
      public void GoToMain()
    {
        SceneManager.LoadScene("Menu"); //������� �� ����� � ��������� Menu
    }

    public void QuitGame()
    {
        Application.Quit(); //�������� ����.
    }
}
