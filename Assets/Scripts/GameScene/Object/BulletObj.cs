using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    //子弹发射者
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
            //受伤判断 如果other对象是坦克基类 那么调用其受伤函数
            //如果 other 碰撞到的对象上挂载了一个继承自 TankBaseObj 的脚本，就会返回这个组件的引用
            TankBaseObj tank =other.GetComponent<TankBaseObj>();
            if (tank != null)
            {
                //将子弹的发射者传入受伤函数,用于物体进行受伤计算
                tank.Wound(owner);
            }

            if (hitEff != null)
            {
                //实例化对象
                GameObject effectObj = Instantiate(hitEff, this.transform.position, this.transform.rotation);

                //音效设置,得到特效对象身上挂载的音频脚本
                AudioSource audioSource = effectObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
                audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
            }
            //销毁子弹
            Destroy(this.gameObject);
            
        }
    }
}
