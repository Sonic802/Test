using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTank : TankBaseObj
{
    public float fireInteral = 1.5f;
    public float nowTime = 0;
    public float fireDistance = 20;
    public Transform firePos;
    public GameObject bullet;

    //从多个点里随机取一个作为目标点,坦克朝向它,并移动
    //小于一定距离后,再随机取一个目标点,朝向它移动
    public Transform[] randomPos;
    public Transform moveTarget;
    //炮台和开火朝向
    public Transform playerPos;

    //敌人血条
    public Texture maxHpBack;
    public Texture nowHp;
    private float showTime = 0f;
    private Rect maxHpRect;
    private Rect nowHpRect;
    private float showDuration = 3f; // 血条显示时间


    private void Start()
    {
        GetRandomPos();
    }

    private void Update()
    {
        //随机两个点之间移动
        if(moveTarget != null)
        {
            this.transform.LookAt(moveTarget);
        }       
        this.transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
        if(Vector3.Distance(this.transform.position,moveTarget.position) < 0.05f)
        {
            //重新随机一个目标点
            GetRandomPos() ;
        }

        //开火
        tankHead.LookAt(playerPos);
        nowTime += Time.deltaTime;
        //如果距离小于开火距离
        if(Vector3.Distance(this.transform.position,playerPos.position) < fireDistance)
        {
            if (nowTime > fireInteral)
            {
                Fire();
                nowTime = 0;
            }
        }
        

    }

    private void OnGUI()
    {
        if (showTime > 0)
        {
            // 计算血条显示剩余时间
            showTime -= Time.deltaTime;

            // 获取当前坦克的位置并转换为屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            // 转换为GUI坐标系
            screenPos.y = Screen.height - screenPos.y; // Unity屏幕坐标系原点在左下，GUI原点在左上

            // 设置背景血条的位置和大小
            maxHpRect.x = screenPos.x - 50; // 偏移50个像素
            maxHpRect.y = screenPos.y - 100; // 偏移50个像素
            maxHpRect.width = 200;
            maxHpRect.height = 30;
            GUI.DrawTexture(maxHpRect, maxHpBack); // 绘制血条背景

            // 绘制当前血量
            nowHpRect.x = screenPos.x - 50;
            nowHpRect.y = screenPos.y - 100;
            nowHpRect.width = (float)Hp / maxHp * 200; // 根据血量比例调整宽度
            nowHpRect.height = 30;
            GUI.DrawTexture(nowHpRect, nowHp); // 绘制当前血量
        }
    }


    public override void Fire()
    {
        GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
        //设置子弹的发射者
        BulletObj bulletObj = obj.GetComponent<BulletObj>();
        bulletObj.SetOwner(this);
    }

    public void GetRandomPos()
    {
        int index= Random.Range(0, randomPos.Length);
        moveTarget = randomPos[index];
    }

    public override void Die()
    {
        base.Die();
        showTime = 0;  // 死亡后隐藏血条
        GamePanel.Instance.AddScore(10) ;
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = showDuration; // 受伤后设置血条显示时间为2秒
    }
}
