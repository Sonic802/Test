using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton closeBtn;

    public List<CustomGUILabel> nameLabels = new List<CustomGUILabel>();
    public List<CustomGUILabel> timeLabels = new List<CustomGUILabel>();
    public List<CustomGUILabel> scoreLabels = new List<CustomGUILabel>();

    private void Start()
    {
        //为Gameobject添加组件 和line7手动拖拽的效果实际上是一样的
        //不过此处是在函数中动态添加脚本
        for (int i = 1; i <= 3; i++)
        {
            nameLabels.Add(this.transform.Find("nameLabel" + i).GetComponent<CustomGUILabel>());
            timeLabels.Add(this.transform.Find("timeLabel" +i).GetComponent <CustomGUILabel>());
            scoreLabels.Add(this.transform.Find("scoreLabel" +i).GetComponent <CustomGUILabel>());

        }

        closeBtn.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };

        HideMe();
    }

    //更新面板 什么时候更新呢?当然是显示面板的同时就要更新
    //怎么更新 从内存中读取数据后用这个数据更新面板
    public void UpdateInfo()
    {
        //取出数据
        List<RankData> list = GameDataMgr.Instance.rankData.list;

        // 确保列表不会越界
        for (int i = 0; i < list.Count; i++)
        {
            // 确保 labels 列表有足够的元素
            if (i < nameLabels.Count)
            {
                nameLabels[i].content.text = list[i].name;
                scoreLabels[i].content.text = list[i].score.ToString();
                int time = (int)list[i].time;
                timeLabels[i].content.text = time.ToString() + "秒";
            }
        }

    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdateInfo();
    }
}
