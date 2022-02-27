using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    
    private int currentTarget; //направление противника из Vector3
    public SpriteRenderer spriterender;
    private Rigidbody2D rigidBody;
    public Transform Tochka1, Tochka2;
    public Transform Startpos;
    
    Vector3 nextpos; //позиция противника
    void Start()
    {
        nextpos = Startpos.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed*Time.deltaTime);
        if(transform.position == Tochka1.position)
        {
            nextpos = Tochka2.position;
            transform.localScale = new Vector2(-1, 1);
        }
        if (transform.position == Tochka2.position)
        {
            nextpos = Tochka1.position;
            transform.localScale = new Vector2(1, 1);
        }
    }

          private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

