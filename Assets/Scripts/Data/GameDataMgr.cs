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

    //����ֻ����������,����ϵ����ݻ���Ҫ��ʾ�͸���
    private GameDataMgr() 
    {   
        //��ʼ����������
        musicdata = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "music") as MusicData;
        //��һ�ν���Ϸ��ʼ������
        if (!musicdata.notFirst)
        {
            musicdata.notFirst = true;
            musicdata.musicOn = true;
            musicdata.soundOn = true;

            musicdata.musicVolume = 0.8f;
            musicdata.soundVolume = 0.8f;

            PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
            
        }
        //��ʼ�� ��ȡ���а�����
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "rank") as RankList;

    }
    //�����а�������ݵķ���
    public void AddRankInfo(string name,float time,int score)
    {
        rankData.list.Add(new RankData(name, time, score));
        //��ʱ�䳤������
        //���a����ʱС��b����ʱ,��ô������߼�ǰ��
        rankData.list.Sort((a, b) => a.time < b.time ? -1 : 1
        );
        //ȥ��3���Ժ������
        for (int i = rankData.list.Count -1; i >=3; i--)
        {
            rankData.list.RemoveAt(i);
        }

        //������ݺ�Ҫ�洢
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "rank");

    }

    public void ToggleMusic(bool isOn)
    {
        //��¼����
        musicdata.musicOn = isOn;
        //�������������¼�!
        OnMusicOnChanged?.Invoke(isOn);

        //�洢����
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
        //���������仯�¼�!
        OnMusicVolumeChanged?.Invoke(vol);
        PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
    }

    public void ChangeSoundVol(float vol)
    {
        musicdata.soundVolume = vol;    

        PlayerPrefsDataMgr.Instance.SaveData(musicdata, "music");
    }

  
}
