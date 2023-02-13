using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float x;
    float z;
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 10f;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //���ݹ�ʽ�Ƶ�����Ҫ����һ����Ծ�߶�,����Ծ�߶ȷ������Ƶ���Ծ������߶�������ٶ�
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        
        

        Vector3 move =transform.right*x+transform.forward*z;
        controller.Move(move*speed*Time.deltaTime);
        velocity.y+=gravity*Time.deltaTime;
        controller.Move(velocity);
    }
}
