using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{    
    public Transform target;
    public float height = 10;
    //���������λ��
    private Vector3 pos;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        pos.x = target.transform.position.x;
        pos.z = target.transform.position.z;
        pos.y =height;

        this.transform.position = pos;
    }
}
