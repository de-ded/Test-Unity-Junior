using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public bool isOpened = true; //������� �� ����

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //������ ������ 
        {
            GoToMain();
        }
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("Menu"); //������� �� ����� � ��������� Menu
    }

    public void QuitGame()
    {
        Application.Quit(); //�������� ����
    }
}