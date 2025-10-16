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
            //随机从武器奖励中取一个出来
            //作为参数传入Player的ChangeWeapon方法
            int index = Random.Range(0, weaponObj.Length);
            //weaponObj[index]即对应的武器,如何传入Player:先得到其脚本
            //得到谁的脚本,是other即玩家身上挂载的脚本
            PlayerObj player =other.GetComponent<PlayerObj>();
            if (player != null)
            {
                player.ChangeWeapon(weaponObj[index]);
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
