using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel scoreLabel;
    public CustomGUILabel timeLabel;
    public CustomGUIButton settingButton;
    public CustomGUIButton quitButton;

    public CustomGUITexture nowHpTexture;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public float nowTime;
    public float hpwidth;

    // Start is called before the first frame update
    void Start()
    {
        settingButton.clickEvent += () =>
        {
            //���������
            
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };

        quitButton.clickEvent += () =>
        {
            //���˳����
            Time.timeScale = 0;
            QuitPanel.Instance.ShowMe();
        };
    }

    // Update is called once per frame
    void Update()
    {
        //��ʱ,����ʾ
        nowTime += Time.deltaTime;
        timeLabel.content.text = ((int)nowTime).ToString() + "��";
    }

    //�ӷ�,���������
    public void AddScore(int score)
    {
        this.score += score;
        scoreLabel.content.text = score.ToString();
    }
    //����Ѫ��
    public void UpdateHp(int Hp,int maxHp)
    {
        nowHpTexture.GUIPos.width = (float)Hp / maxHp * hpwidth;
    }
}
