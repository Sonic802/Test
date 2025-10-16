using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankData 
{
    //不需要排名 会自动排序 这里只是存放数据而已
    //public int rank;
    public string name;
    public float time;
    public int score;

    public RankData() { }

    public RankData(string name, float time, int score)
    {
        this.name = name;
        this.time = time;
        this.score = score;
    }
}

public class RankList
{
    public List<RankData> list;
}