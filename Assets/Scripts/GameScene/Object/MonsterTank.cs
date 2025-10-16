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

    //�Ӷ���������ȡһ����ΪĿ���,̹�˳�����,���ƶ�
    //С��һ�������,�����ȡһ��Ŀ���,�������ƶ�
    public Transform[] randomPos;
    public Transform moveTarget;
    //��̨�Ϳ�����
    public Transform playerPos;

    //����Ѫ��
    public Texture maxHpBack;
    public Texture nowHp;
    private float showTime = 0f;
    private Rect maxHpRect;
    private Rect nowHpRect;
    private float showDuration = 3f; // Ѫ����ʾʱ��


    private void Start()
    {
        GetRandomPos();
    }

    private void Update()
    {
        //���������֮���ƶ�
        if(moveTarget != null)
        {
            this.transform.LookAt(moveTarget);
        }       
        this.transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
        if(Vector3.Distance(this.transform.position,moveTarget.position) < 0.05f)
        {
            //�������һ��Ŀ���
            GetRandomPos() ;
        }

        //����
        tankHead.LookAt(playerPos);
        nowTime += Time.deltaTime;
        //�������С�ڿ������
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
            // ����Ѫ����ʾʣ��ʱ��
            showTime -= Time.deltaTime;

            // ��ȡ��ǰ̹�˵�λ�ò�ת��Ϊ��Ļ����
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            // ת��ΪGUI����ϵ
            screenPos.y = Screen.height - screenPos.y; // Unity��Ļ����ϵԭ�������£�GUIԭ��������

            // ���ñ���Ѫ����λ�úʹ�С
            maxHpRect.x = screenPos.x - 50; // ƫ��50������
            maxHpRect.y = screenPos.y - 100; // ƫ��50������
            maxHpRect.width = 200;
            maxHpRect.height = 30;
            GUI.DrawTexture(maxHpRect, maxHpBack); // ����Ѫ������

            // ���Ƶ�ǰѪ��
            nowHpRect.x = screenPos.x - 50;
            nowHpRect.y = screenPos.y - 100;
            nowHpRect.width = (float)Hp / maxHp * 200; // ����Ѫ�������������
            nowHpRect.height = 30;
            GUI.DrawTexture(nowHpRect, nowHp); // ���Ƶ�ǰѪ��
        }
    }


    public override void Fire()
    {
        GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
        //�����ӵ��ķ�����
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
        showTime = 0;  // ����������Ѫ��
        GamePanel.Instance.AddScore(10) ;
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = showDuration; // ���˺�����Ѫ����ʾʱ��Ϊ2��
    }
}
