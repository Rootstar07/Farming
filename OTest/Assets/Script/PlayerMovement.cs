﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    public float jumpSpeed; // 캐릭터 점프 힘.
    public float gravity;    // 캐릭터에게 작용하는 중력.

    private CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.
    public Animator animator;
    float last_x;
    float last_z;

    void Start()
    {
        speed = 6.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;

        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        // 현재 캐릭터가 땅에 있는가?
        if (controller.isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0) //하나라도 움직인다.
            {
                // 위, 아래 움직임 셋팅. 
                MoveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


                animator.SetFloat("_X", MoveDir.x);
                last_x = MoveDir.x;

                animator.SetFloat("_Y", MoveDir.z);
                last_z = MoveDir.z;

                animator.SetBool("IsMoving", true);
            }
            else
            {
                MoveDir = new Vector3(0, 0, 0);

                animator.SetBool("IsMoving", false);
                animator.SetFloat("_X", last_x);
                animator.SetFloat("_Y", last_z);
            }
           

            // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
            MoveDir = transform.TransformDirection(MoveDir);

            // 스피드 증가.
            MoveDir *= speed;

            // 캐릭터 점프
            if (Input.GetButton("Jump"))
                MoveDir.y = jumpSpeed;

        }

        // 캐릭터에 중력 적용.
        MoveDir.y -= gravity * Time.deltaTime;

        // 캐릭터 움직임.
        controller.Move(MoveDir * Time.deltaTime);
    }



    void Update()
    {

    }
}
