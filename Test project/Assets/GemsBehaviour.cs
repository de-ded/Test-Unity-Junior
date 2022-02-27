using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemsBehaviour : MonoBehaviour
{
   [SerializeField] private GameObject Win; // ����� ������
    public int count; //������� ������
    private int WinScore = 100; //���-�� ����� ��� ������
   
    public bool isOpened = false; //������� �� ����

        public void ShowHideWin()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; // ���/���� Canvas
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.tag == "Player") //���������, ��� �������, ��������������� �������
        {
            Destroy(gameObject); // ���������� ��� ������
            collision.GetComponent<PlayerBehaviourScript>().Bonus(count); //������� ������
            if (count >= WinScore)
            {
                ShowHideWin();
            }
        }
             }
}
