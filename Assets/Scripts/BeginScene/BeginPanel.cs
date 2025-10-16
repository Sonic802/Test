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
            //显示设置面板
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        quitBtn.clickEvent += () =>
        {
            Application.Quit();
        };

        rankBtn.clickEvent += () =>
        {
            //显示排行榜面板
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }

    private void LoadGameScene()
    {
        //转到游戏场景
        SceneManager.LoadScene("GameScene");        
    }
}
