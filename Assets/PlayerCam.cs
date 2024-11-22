using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform CamHolder;

    float xRotation;
    float yRotation;

    void Start()
    {
        //�}�E�X�|�C���^�[��^�񒆂ɌŒ肵�����Ȃ�����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X�̓��͂��擾
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        //Y���������_�ɏ����݂���
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //�J�����ƃv���C���[�̌����𓮂���
        CamHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}