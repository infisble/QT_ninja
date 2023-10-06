using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_jump_warious : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху персонажа
    public float jumpForce = 7f; // Сила стрибка персонажа
    private bool isGrounded; // Перевірка, чи персонаж на землі
    private Rigidbody2D rb; // Компонент Rigidbody2D
    private Animator animator; // Компонент Animator

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Перевірка, чи персонаж на землі
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground"));

        // Визначення напрямку руху
        float moveDirection = Input.GetAxis("Horizontal");
        // Рух персонажа
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Зміна анімації в залежності від швидкості руху
       // animator.SetFloat("Speed", Mathf.Abs(moveDirection));

        // Стрибок
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Зміна анімації стрибка
       // animator.SetBool("IsJumping", !isGrounded);
    }


}
