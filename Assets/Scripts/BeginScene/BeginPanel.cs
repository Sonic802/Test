using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton beginBtn;
    public CustomGUIButton settingBtn;
    public CustomGUIButton quitBtn;
    public CustomGUIButton rankBtn;

    private void Start()
    {
        beginBtn.clickEvent += LoadGameScene;

        settingBtn.clickEvent += () =>
        {
            //��ʾ�������
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        quitBtn.clickEvent += () =>
        {
            Application.Quit();
        };

        rankBtn.clickEvent += () =>
        {
            //��ʾ���а����
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }

    private void LoadGameScene()
    {
        //ת����Ϸ����
        SceneManager.LoadScene("GameScene");        
    }
}
