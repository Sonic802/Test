using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUIButton closeBtn;
    public CustomGUIToggle musicToggle;
    public CustomGUIToggle soundToggle;
    public CustomGUISlider musicSlider;
    public CustomGUISlider soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        closeBtn.clickEvent += () =>
        {
            if (SceneManager.GetActiveScene().name == "BeginPanel")
            {
                BeginPanel.Instance.ShowMe();
            }
           
            HideMe();
        };

        musicToggle.isPressed += (isOn) =>
        {
            //Ϊ��ť����¼�:��GameDataMgr��ִ�п������ֵķ���
            GameDataMgr.Instance.ToggleMusic(isOn);
        };

        soundToggle.isPressed += (isOn) =>
        {
            GameDataMgr.Instance.ToggleSound(isOn);
        };

        musicSlider.OnValueChanged += (volume) =>
        {
            GameDataMgr.Instance.ChangeMusicVol(volume);
        };

        soundSlider.OnValueChanged += (volume) =>
        {
            GameDataMgr.Instance.ChangeSoundVol(volume);
        };

        HideMe ();
    }

    //��������ϵ���Ϣ
    public void UpdateInfo()
    {
        MusicData data = GameDataMgr.Instance.musicdata;
        musicToggle.isSel= data.musicOn;
        soundToggle.isSel= data.soundOn;
        musicSlider.nowValue = data.musicVolume;
        soundSlider.nowValue = data.soundVolume;

    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdateInfo();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
