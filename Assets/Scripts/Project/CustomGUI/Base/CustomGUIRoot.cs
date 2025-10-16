using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    //���ڴ洢�Ӷ��� ���е�GUI�ؼ�������
    private CustomGUIControl[] allControls;
    
    void Start()
    {
        allControls = GetComponentsInChildren<CustomGUIControl>();
    }

    //�˴�ͳһ�����Ӷ���ؼ�������
    private void OnGUI()
    {
        //ÿһ�λ���֮ǰ �õ������Ӷ���ؼ��� ����ű�
        //����ÿ��ִ��OnGUI����ȥ��ȡ���пؼ���Ӧ�Ľű�
        //�˷����ܵĽ����ʽ���༭״̬��һֱִ�У���Ϸ��ʼ��ֻ��Ҫ��Start������ִ��һ�μ���

        allControls = GetComponentsInChildren<CustomGUIControl>();
        
       

        //����ÿһ���ؼ� ����ִ�л���
        for (int i = 0; i < allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }
    }
}
