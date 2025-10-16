using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    //�ӵ�������
    public TankBaseObj owner;
    public GameObject hitEff;
    public float speed = 20;

    private void Update()
    {
        this.transform.Translate(Vector3.forward * speed*Time.deltaTime);
    }

    public void SetOwner(TankBaseObj owner)
    {
        this.owner = owner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube")||other.tag =="Player"&&owner.tag=="Monster"||
            other.tag == "Monster" && owner.tag == "Player")
        {
            //�����ж� ���other������̹�˻��� ��ô���������˺���
            //��� other ��ײ���Ķ����Ϲ�����һ���̳��� TankBaseObj �Ľű����ͻ᷵��������������
            TankBaseObj tank =other.GetComponent<TankBaseObj>();
            if (tank != null)
            {
                //���ӵ��ķ����ߴ������˺���,��������������˼���
                tank.Wound(owner);
            }

            if (hitEff != null)
            {
                //ʵ��������
                GameObject effectObj = Instantiate(hitEff, this.transform.position, this.transform.rotation);

                //��Ч����,�õ���Ч�������Ϲ��ص���Ƶ�ű�
                AudioSource audioSource = effectObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
                audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
            }
            //�����ӵ�
            Destroy(this.gameObject);
            
        }
    }
}
