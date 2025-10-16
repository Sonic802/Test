using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;
    //��������λ��
    public Transform weaponPos;

    public float minAngle = -90f; // �����С�Ƕ�
    public float maxAngle = 90f;  // �ұ����Ƕ�

    private float currentAngle = 0f; // ��ǰ��̨�Ƕ�

    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed*Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * Input.GetAxis("Horizontal"));
        //������̨������ת��һ����Χ��

        // ������̨��ת
        float mouseX = Input.GetAxis("Mouse X"); // ��ȡ���ˮƽ�ƶ�������
        currentAngle += mouseX * rotateSpeed * Time.deltaTime; // �ۼ����ˮƽ�ƶ�ֵ
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle); // ������ת�Ƕ��� -90 �� 90 ��֮��

        // ������̨��ת
        tankHead.localRotation = Quaternion.Euler(0, currentAngle, 0); // ����������ĽǶ�Ӧ�õ���̨��ת
        //����
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void ChangeWeapon(GameObject weaponObject)
    {
        //ɾ����ǰ����
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        
        //����������
        GameObject gameObject = Instantiate(weaponObject, weaponPos,false);
        nowWeapon = gameObject.GetComponent<WeaponObj>();

        //��������ӵ����
        nowWeapon.SetOwner(this);
    }

    public override void Fire()
    {
        if (nowWeapon != null)
        nowWeapon.Fire();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdateHp(Hp, maxHp);
    }

    public override void Die()
    {
        //base.Die();
        if (deadEff != null)
        {
            //ʵ��������
            GameObject effectObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);

            //��Ч����,�õ���Ч�������Ϲ��ص���Ƶ�ű�
            AudioSource audioSource = effectObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicdata.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicdata.soundOn;
        }

        Invoke("ShowLosePanel", 1);
        
        
    }

    public void ShowLosePanel()
    {
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }

}
