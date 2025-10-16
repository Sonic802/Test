using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    public MusicData musicdata;

    public RankList rankData;

    public event Action<float> OnMusicVolumeChanged;
    public event Action<bool> OnMusicOnChanged;

    //这里只是设置数据,面板上的数据还需要显示和更新
    private GameDataMgr() 
    {   
        //初始化音乐数据
        musicdata = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "music") as MusicData;
        //第一次进游戏初始化数据
        if (!musicdata.notFirst)
        {
            musicdata.notFirst = true;
            musicdata.musicOn = true;
            musicdata.soundOn = true;

            musicdata.musicVolume = 0.8f;
            musicdata.soundVolume = 0.8f;

            PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
            
        }
        //初始化 读取排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "rank") as RankList;

    }
    //在排行榜添加数据的方法
    public void AddRankInfo(string name,float time,int score)
    {
        rankData.list.Add(new RankData(name, time, score));
        //按时间长短排序
        //如果a的用时小于b的用时,那么排在左边即前面
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1
        );
        //去掉3名以后的数据
        for (int i = rankData.list.Count -1; i >=3; i--)
        {
            rankData.list.RemoveAt(i);
        }

        //添加数据后要存储
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "rank");

    }

    public void ToggleMusic(bool isOn)
    {
        //记录数据
        musicdata.musicOn = isOn;
        //发布音量开关事件!
        OnMusicOnChanged?.Invoke(isOn);

        //存储数据
        PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
    }

    public void ToggleSound(bool isOn)
    {
        musicdata.soundOn = isOn;
       
        PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
    }

    public void ChangeMusicVol(float vol)
    {
        musicdata.musicVolume = vol;
        //发布音量变化事件!
        OnMusicVolumeChanged?.Invoke(vol);
        PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
    }

    public void ChangeSoundVol(float vol)
    {
        musicdata.soundVolume = vol;    

        PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
    }

  
}
