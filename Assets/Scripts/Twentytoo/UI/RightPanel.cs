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
            Debug.Log("从存档开始游戏");
            //跳转到存档处
        });

        GetControl<Button>("DeleteArchive").onClick.AddListener(() =>
        {
            //弹出提示框
            UIMgr.Instance.ShowPanel<DeletePrompt>();
        });

        GetControl<Button>("ReturnSelection").onClick.AddListener(() =>
        {
            //返回上一个面板
            UIMgr.Instance.HidePanel<RightPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<Start_SLPanel>();
        });

        GetControl<Button>("ReturnTitle").onClick.AddListener(() =>
        {
            //返回标题
            UIMgr.Instance.HidePanel<RightPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<StartPanel>();
        });
    }
}
