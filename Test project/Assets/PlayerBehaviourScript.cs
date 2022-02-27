using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourScript : MonoBehaviour
{
    public Vector2 playerVelocity = new Vector2(1, 3);  // Оси

    [SerializeField] private LayerMask Ground; // Проверка нахождения на земле

    private Rigidbody2D rigidBody; // Физическое тело объекта
    private Collider2D coll; // Коллайдер
    private SpriteRenderer spriteRenderer;
    private Animator animatorComponent; //Анимации
    private enum AnimationState { idle, run, jump, fall }; //Массив анимаций
    private AnimationState currentAnimationState = AnimationState.idle; //Начальная анимация
    public int score;
    public Text textscore;

    private void Start() // Получаем доступ объекта Player
    {
       rigidBody = gameObject.GetComponent<Rigidbody2D>(); // к Rigidbody2D 
       coll = gameObject.GetComponent<Collider2D>(); // к колайдеру 
       spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
       animatorComponent = gameObject.GetComponent<Animator>(); // к аниматору
       textscore.text = score.ToString(); // Для счётчика
    }

    private void Update()
    {
        updatePlayerPosition(); // Положение игрока
    }
        public void Bonus(int count)
    {
        score += count;
        textscore.text = score.ToString();
    }
    private void updatePlayerPosition() // Обновление положения игрока
    {
        float horizontalmoveInput = Input.GetAxis("Horizontal"); // Значение ввода горизонтального перемещения
        float jumpInput = Input.GetAxis("Jump"); // Значение ввода прыжка
                
        if (horizontalmoveInput < 0)
        { 
            rigidBody.velocity = new Vector2(-playerVelocity.x, rigidBody.velocity.y); // Движение влево
            spriteRenderer.flipX = true;
        }
        else if (horizontalmoveInput > 0)
        { 
            rigidBody.velocity = new Vector2(playerVelocity.x, rigidBody.velocity.y); // Движение вправо
            spriteRenderer.flipX = false;
        }
        else if (coll.IsTouchingLayers(Ground)) {
            rigidBody.velocity = Vector2.zero; // Отключение инерции
        }
        if (jumpInput > 0 && coll.IsTouchingLayers(Ground))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerVelocity.y); // Прыжок с условием стояния на земле
        }
        setAnimationState(); 
    }
            private void setAnimationState() // Выбираем текущую анимацию
    {
                 if (coll.IsTouchingLayers(Ground)) // Персонаж касается земли
        {
                       if (Mathf.Abs(rigidBody.velocity.x) > 0.1f)  // При помощи Mathf.Abs получаем модуль значения ускорения
            {
                       currentAnimationState = AnimationState.run;
            }
            else
            {
                 currentAnimationState = AnimationState.idle; // Стоим на месте  
            }
              
        }
        else // Персонаж не касается земли
        {
            
            currentAnimationState = AnimationState.jump; // Ставим анимацию прыжок

            if (currentAnimationState == AnimationState.jump)
            {
                
                if (rigidBody.velocity.y < .1f) // Ставим падение 
                {
                    currentAnimationState = AnimationState.fall;
                }
            }
            else if (currentAnimationState == AnimationState.fall)
            {
                if (coll.IsTouchingLayers(Ground)) // Если коснулся земли, то переходим в состояние спокойствия
                {
                    currentAnimationState = AnimationState.idle;
                }
            }
        }
                animatorComponent.SetInteger("state", (int)currentAnimationState); // Изменияем "state" в аниматоре
            }
    
}