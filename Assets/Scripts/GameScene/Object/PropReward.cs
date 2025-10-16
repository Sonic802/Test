using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropReward
{
    Hp,
    Atk,
    Def,
}

public class PropReward : MonoBehaviour
{
    public E_PropReward reward = E_PropReward.Hp;
    public GameObject getEff;
    public int HpHeal = 5;
    public int Atkup = 2;
    public int Defup = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //��other���ϵõ�Player�����
            PlayerObj player =other.GetComponent<PlayerObj>();
            switch (reward)
            {
                case E_PropReward.Hp:
                    player.Hp += HpHeal;
                    //���ܳ�������
                    if (player.Hp>player.maxHp)
                    {
                        player.Hp = player.maxHp;
                    }
                    //����Ѫ����ʾ
                    GamePanel.Instance.UpdateHp(player.Hp, player.maxHp);
                    break;
                case E_PropReward.Atk:
                    player.atk += Atkup;
                    break;
                case E_PropReward.Def:
                    player.def += Defup;
                    break;
                
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
