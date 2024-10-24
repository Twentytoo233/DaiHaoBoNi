using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPanel : BasePanel
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
        base.Awake();
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        AllEvent();
    }
    private void AllEvent()
    {
        GetControl<Button>("StartSaveBtn").onClick.AddListener(() =>
        {
            Debug.Log("�Ӵ浵��ʼ��Ϸ");
            //��ת���浵��
        });

        GetControl<Button>("DeleteArchive").onClick.AddListener(() =>
        {
            //������ʾ��
            UIMgr.Instance.ShowPanel<DeletePrompt>();
        });

        GetControl<Button>("ReturnSelection").onClick.AddListener(() =>
        {
            //������һ�����
            UIMgr.Instance.HidePanel<RightPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<Start_SLPanel>();
        });

        GetControl<Button>("ReturnTitle").onClick.AddListener(() =>
        {
            //���ر���
            UIMgr.Instance.HidePanel<RightPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<StartPanel>();
        });
    }
}
