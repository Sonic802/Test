using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCube : MonoBehaviour
{
    public GameObject[] rewards;
    public int rewardProbability = 30;
    public GameObject desEff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            int random = Random.Range(0, 100);
            //几率生成
            if (random <= rewardProbability)
            {
                //随机从奖励中取一个出来
                random = Random.Range(0, rewards.Length);
                GameObject reward = Instantiate(rewards[random],this.transform.position,
                    this.transform.rotation);
            }
            //毁坏特效

            if (desEff != null)
            {
                //实例化对象
                GameObject effectObj = Instantiate(desEff, this.transform.position, this.transform.rotation);

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
