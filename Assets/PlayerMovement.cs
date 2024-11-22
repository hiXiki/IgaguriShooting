using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float groundDrag;

    public float JumpForce;�@//�W�����v�͂̒l
    public float JumpCoolDown;�@//�W�����v�̃N�[���_�E��
    public float airMultiplier;�@//�󒆂ł̑��쐫�������������邽�߂̒l
    bool ReadyToJump;�@//�W�����v���ł��邩�ł��Ȃ����̂��߂̐^�U�l

    public float playerheight;
    public LayerMask Ground;
    bool grounded;

    public Transform orientation;

    float HorizontalInput;
    float VerticalInput;

    Vector3 moveDirection;

    Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        ReadyToJump = true;
    }


    void Update()
    {
        //�n�ʂƐڂ��Ă��邩�𔻒f
        grounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f, Ground);

        //�ڂ��Ă���ꍇ�́A�ݒ肵�������l�������v���C���[������ɂ�������
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        ProcessInput();
        SpeedControl();
    }


    private void FixedUpdate()
    {
        movePlayer();
    }


    private void ProcessInput()
    {
        //���͂��擾
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && grounded && ReadyToJump)
        {
            ReadyToJump = false;

            Jump();

            Invoke(nameof(resetJump), JumpCoolDown);�@//JumpCoolDown�Őݒ肵���b�����resetJump�֐����Ăяo���B
        }
    }


    private void movePlayer()
    {
        //�����Ă�������ɐi��
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        ReadyToJump = true;
    }


    private void SpeedControl()
    {
        //�v���C���[�̃X�s�[�h�𐧌�
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}