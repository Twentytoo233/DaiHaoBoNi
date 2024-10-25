using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialohueTip : BasePanel
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
    private void Update()
    {
        //按下E 隐藏提示 打开对话框
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowDialohue();
        }
    }

    private void ShowDialohue()
    {
        UIMgr.Instance.ShowPanel<DialoguePanel>();
        Debug.Log("显示对话框");
        UIMgr.Instance.HidePanel<DialohueTip>();
        HideMe();
    }
}
