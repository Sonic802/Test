using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] firePos;
    //����ӵ����
    public TankBaseObj weaponOwner;
    //����ӵ����
    public void SetOwner(TankBaseObj owner)
    {
        weaponOwner = owner;
    }

    public  void Fire()
    {
        //ʵ�����ӵ�
        for (int i = 0; i < firePos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, firePos[i].position, firePos[i].rotation);
            //��ȡ�ӵ���BulletObj�ű� �������䴴����
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetOwner(weaponOwner);
        }        
        
    }
}
