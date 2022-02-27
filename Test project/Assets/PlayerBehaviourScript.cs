using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourScript : MonoBehaviour
{
    public Vector2 playerVelocity = new Vector2(1, 3);  // ���

    [SerializeField] private LayerMask Ground; // �������� ���������� �� �����

    private Rigidbody2D rigidBody; // ���������� ���� �������
    private Collider2D coll; // ���������
    private SpriteRenderer spriteRenderer;
    private Animator animatorComponent; //��������
    private enum AnimationState { idle, run, jump, fall }; //������ ��������
    private AnimationState currentAnimationState = AnimationState.idle; //��������� ��������
    public int score;
    public Text textscore;

    private void Start() // �������� ������ ������� Player
    {
       rigidBody = gameObject.GetComponent<Rigidbody2D>(); // � Rigidbody2D 
       coll = gameObject.GetComponent<Collider2D>(); // � ��������� 
       spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
       animatorComponent = gameObject.GetComponent<Animator>(); // � ���������
       textscore.text = score.ToString(); // ��� ��������
    }

    private void Update()
    {
        updatePlayerPosition(); // ��������� ������
    }
        public void Bonus(int count)
    {
        score += count;
        textscore.text = score.ToString();
    }
    private void updatePlayerPosition() // ���������� ��������� ������
    {
        float horizontalmoveInput = Input.GetAxis("Horizontal"); // �������� ����� ��������������� �����������
        float jumpInput = Input.GetAxis("Jump"); // �������� ����� ������
                
        if (horizontalmoveInput < 0)
        { 
            rigidBody.velocity = new Vector2(-playerVelocity.x, rigidBody.velocity.y); // �������� �����
            spriteRenderer.flipX = true;
        }
        else if (horizontalmoveInput > 0)
        { 
            rigidBody.velocity = new Vector2(playerVelocity.x, rigidBody.velocity.y); // �������� ������
            spriteRenderer.flipX = false;
        }
        else if (coll.IsTouchingLayers(Ground)) {
            rigidBody.velocity = Vector2.zero; // ���������� �������
        }
        if (jumpInput > 0 && coll.IsTouchingLayers(Ground))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, playerVelocity.y); // ������ � �������� ������� �� �����
        }
        setAnimationState(); 
    }
            private void setAnimationState() // �������� ������� ��������
    {
                 if (coll.IsTouchingLayers(Ground)) // �������� �������� �����
        {
                       if (Mathf.Abs(rigidBody.velocity.x) > 0.1f)  // ��� ������ Mathf.Abs �������� ������ �������� ���������
            {
                       currentAnimationState = AnimationState.run;
            }
            else
            {
                 currentAnimationState = AnimationState.idle; // ����� �� �����  
            }
              
        }
        else // �������� �� �������� �����
        {
            
            currentAnimationState = AnimationState.jump; // ������ �������� ������

            if (currentAnimationState == AnimationState.jump)
            {
                
                if (rigidBody.velocity.y < .1f) // ������ ������� 
                {
                    currentAnimationState = AnimationState.fall;
                }
            }
            else if (currentAnimationState == AnimationState.fall)
            {
                if (coll.IsTouchingLayers(Ground)) // ���� �������� �����, �� ��������� � ��������� �����������
                {
                    currentAnimationState = AnimationState.idle;
                }
            }
        }
                animatorComponent.SetInteger("state", (int)currentAnimationState); // ��������� "state" � ���������
            }
    
}