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
        //ΪGameobject������ ��line7�ֶ���ק��Ч��ʵ������һ����
        //�����˴����ں����ж�̬��ӽű�
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

    //������� ʲôʱ�������?��Ȼ����ʾ����ͬʱ��Ҫ����
    //��ô���� ���ڴ��ж�ȡ���ݺ���������ݸ������
    public void UpdateInfo()
    {
        //ȡ������
        List<RankData> list = GameDataMgr.Instance.rankData.list;

        // ȷ���б���Խ��
        for (int i = 0; i < list.Count; i++)
        {
            // ȷ�� labels �б����㹻��Ԫ��
            if (i < nameLabels.Count)
            {
                nameLabels[i].content.text = list[i].name;
                scoreLabels[i].content.text = list[i].score.ToString();
                int time = (int)list[i].time;
                timeLabels[i].content.text = time.ToString() + "��";
            }
        }

    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdateInfo();
    }
}
