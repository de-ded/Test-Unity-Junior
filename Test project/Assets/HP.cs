using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HP : MonoBehaviour
{
    public int hp;
    public Text hpT;
    public int hpDamage;

    void Start()
    {
        hpT.text = "�����: " + hp.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp = hp - hpDamage;
            hpT.text = "�����: " + hp.ToString();
            if (hp <= 0)
            {
                SceneManager.LoadScene(0);
                gameObject.SetActive(false);
            }
        }
    }
}
