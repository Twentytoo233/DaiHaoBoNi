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
            //已按下开始按钮 隐藏开始面板
            UIMgr.Instance.HidePanel<StartPanel>();
            HideMe();

            //打开开机面板
            UIMgr.Instance.ShowPanel<TurnOnPanel>();

        });

        //按下结束游戏按钮 结束游戏
        GetControl<Button>("EndButton").onClick.AddListener(() =>
        {
            //建议有提醒框

            //建议有自动存档

            //关闭程序
            Application.Quit();
        });

        //点击游戏存档 弹出游戏存档界面
        GetControl<Button>("LoadButton").onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Start_SLPanel>();

            UIMgr.Instance.HidePanel<StartPanel>();
            HideMe();
            
        });
    }
}
