using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    public float fireInteral = 1;
    public float nowTime = 0;
    public Transform firePos;
    public GameObject bullet;

    private void Update()
    {
        nowTime += Time.deltaTime;
        if(nowTime > fireInteral)
        {
            Fire();
            nowTime = 0;
        }
    }

    public override void Fire()
    {
        GameObject obj = Instantiate(bullet, firePos.position,firePos.rotation);
        //设置子弹的发射者
        BulletObj bulletObj =obj.GetComponent<BulletObj>();
        bulletObj.SetOwner(this);
    }

    public override void Wound(TankBaseObj other)
    {
        //无敌
    }


}
