using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemsBehaviour : MonoBehaviour
{
   [SerializeField] private GameObject Win; // Сцена победы
    public int count; //счётчик баллов
    private int WinScore = 100; //Кол-во очков для победы
   
    public bool isOpened = false; //Открыто ли меню

        public void ShowHideWin()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; // Вкл/выкл Canvas
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.tag == "Player") //Проверяем, тэг объекта, активировавшего триггер
        {
            Destroy(gameObject); // Уничтожаем наш объект
            collision.GetComponent<PlayerBehaviourScript>().Bonus(count); //выводим бонусы
            if (count >= WinScore)
            {
                ShowHideWin();
            }
        }
             }
}
