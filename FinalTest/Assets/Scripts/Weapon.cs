using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage = 10.0f;
    public float range = 100.0f;
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //��ǹ�ķ���
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward,out hitInfo,range))
        {
            //������߻���������
            Debug.Log(hitInfo.transform.name);

        }
    }
}
