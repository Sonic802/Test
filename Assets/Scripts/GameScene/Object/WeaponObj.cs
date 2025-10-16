using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] firePos;
    //武器拥有者
    public TankBaseObj weaponOwner;
    //设置拥有者
    public void SetOwner(TankBaseObj owner)
    {
        weaponOwner = owner;
    }

    public  void Fire()
    {
        //实例化子弹
        for (int i = 0; i < firePos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, firePos[i].position, firePos[i].rotation);
            //获取子弹的BulletObj脚本 并设置其创造者
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetOwner(weaponOwner);
        }        
        
    }
}
