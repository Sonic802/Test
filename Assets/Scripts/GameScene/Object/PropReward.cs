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
            //从other身上得到Player的组件
            PlayerObj player =other.GetComponent<PlayerObj>();
            switch (reward)
            {
                case E_PropReward.Hp:
                    player.Hp += HpHeal;
                    //不能超出上限
                    if (player.Hp>player.maxHp)
                    {
                        player.Hp = player.maxHp;
                    }
                    //更新血条显示
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
                //实例化对象
                GameObject effectObj = Instantiate(getEff, this.transform.position, this.transform.rotation);

                //音效设置,得到特效对象身上挂载的音频脚本
                AudioSource audioSource = effectObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
                audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
            }
            //销毁此物体
            Destroy(this.gameObject);
        }
        
    }
}
