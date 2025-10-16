using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;
    public GameObject getEff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //���������������ȡһ������
            //��Ϊ��������Player��ChangeWeapon����
            int index = Random.Range(0, weaponObj.Length);
            //weaponObj[index]����Ӧ������,��δ���Player:�ȵõ���ű�
            //�õ�˭�Ľű�,��other��������Ϲ��صĽű�
            PlayerObj player =other.GetComponent<PlayerObj>();
            if (player != null)
            {
                player.ChangeWeapon(weaponObj[index]);
            }
            if (getEff != null)
            {
                //ʵ��������
                GameObject effectObj = Instantiate(getEff, this.transform.position, this.transform.rotation);

                //��Ч����,�õ���Ч�������Ϲ��ص���Ƶ�ű�
                AudioSource audioSource = effectObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
                audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
            }
            //���ٴ�����
            Destroy(this.gameObject);
        }
    }

}
