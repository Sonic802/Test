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
            //��������
            if (random <= rewardProbability)
            {
                //����ӽ�����ȡһ������
                random = Random.Range(0, rewards.Length);
                GameObject reward = Instantiate(rewards[random],this.transform.position,
                    this.transform.rotation);
            }
            //�ٻ���Ч

            if (desEff != null)
            {
                //ʵ��������
                GameObject effectObj = Instantiate(desEff, this.transform.position, this.transform.rotation);

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
