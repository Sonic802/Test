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

    //̹�˵���̨ ����������ת
    public Transform tankHead;
    //������Ч ����Ԥ����
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
        //����������Ч
        if (deadEff != null)
        {
            //ʵ��������
            GameObject effectObj =Instantiate(deadEff,this.transform.position,this.transform.rotation); 

            //��Ч����,�õ���Ч�������Ϲ��ص���Ƶ�ű�
            AudioSource audioSource = effectObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
        }
    }
}
