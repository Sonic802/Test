using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk = 5;
    public int def = 2;
    public int maxHp = 15;
    public int Hp = 15;
    public int moveSpeed = 10;
    public int rotateSpeed = 100;
    public int headRotateSpeed = 100;

    //坦克的炮台 可以让其旋转
    public Transform tankHead;
    //死亡特效 关联预设体
    public GameObject deadEff;


    public abstract void Fire();

    public virtual void Wound(TankBaseObj other)
    {
        int damage = other.atk - this.def;
        if (damage < 0)
            return;
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            Die();
        }
            
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
        //播放死亡特效
        if (deadEff != null)
        {
            //实例化对象
            GameObject effectObj =Instantiate(deadEff,this.transform.position,this.transform.rotation); 

            //音效设置,得到特效对象身上挂载的音频脚本
            AudioSource audioSource = effectObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
        }
    }
}
