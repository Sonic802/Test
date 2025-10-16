using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;
    //武器创建位置
    public Transform weaponPos;

    public float minAngle = -90f; // 左边最小角度
    public float maxAngle = 90f;  // 右边最大角度

    private float currentAngle = 0f; // 当前炮台角度

    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed*Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * Input.GetAxis("Horizontal"));
        //控制炮台左右旋转在一定范围内

        // 控制炮台旋转
        float mouseX = Input.GetAxis("Mouse X"); // 获取鼠标水平移动的输入
        currentAngle += mouseX * rotateSpeed * Time.deltaTime; // 累加鼠标水平移动值
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle); // 限制旋转角度在 -90 到 90 度之间

        // 更新炮台旋转
        tankHead.localRotation = Quaternion.Euler(0, currentAngle, 0); // 将计算出来的角度应用到炮台旋转
        //开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void ChangeWeapon(GameObject weaponObject)
    {
        //删除当前武器
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        
        //创建新武器
        GameObject gameObject = Instantiate(weaponObject, weaponPos,false);
        nowWeapon = gameObject.GetComponent<WeaponObj>();

        //设置武器拥有者
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
            //实例化对象
            GameObject effectObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);

            //音效设置,得到特效对象身上挂载的音频脚本
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
