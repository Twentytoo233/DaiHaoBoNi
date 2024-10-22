using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public override void HideMe()
    {
        gameObject.SetActive(false);
    }

    public override void ShowMe()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        UIMgr.Instance.ShowPanel<StartPanel>();

    }
    private void Update()
    {
        GetControl<Button>("StartButton").onClick.AddListener(() =>
        {
            //�Ѱ��¿�ʼ��ť ���ؿ�ʼ���
            UIMgr.Instance.HidePanel<StartPanel>();
            HideMe();
            //�򿪿������
            UIMgr.Instance.ShowPanel<TurnOnPanel>();

        });

        //���½�����Ϸ��ť ������Ϸ
        GetControl<Button>("EndButton").onClick.AddListener(() =>
        {
            //���������ѿ�

            //�������Զ��浵

            //�رճ���
            Application.Quit();
        });

        //�����Ϸ�浵 ������Ϸ�浵����
        GetControl<Button>("LoadButton").onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<StartPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<Start_SLPanel>();
        });
    }
}
