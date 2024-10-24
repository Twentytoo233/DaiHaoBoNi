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

    protected override void Awake()
    {
        this.enabled = true;
        base.Awake();
    }

    private void Start()
    {
        UIMgr.Instance.ShowPanel<StartPanel>();
        AllEvent();
    }
    private void Update()
    {
        
    }
    private void AllEvent()
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
            UIMgr.Instance.ShowPanel<Start_SLPanel>();

            UIMgr.Instance.HidePanel<StartPanel>();
            HideMe();
            
        });
    }
}
