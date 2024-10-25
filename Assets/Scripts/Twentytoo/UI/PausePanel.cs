using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : BasePanel
{
    public string sceneName;
    public Scene scene;
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

    // Start is called before the first frame update
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        //UIMgr.Instance.ShowPanel<PausePanel>();
        AllEvent();
    }

    private void AllEvent()
    {
        GetControl<Button>("Continue").onClick.AddListener(() =>
        {
            Debug.Log("继续游戏");
            UIMgr.Instance.HidePanel<PausePanel>();
            HideMe();
            //显示倒计时
            UIMgr.Instance.ShowPanel<CountDown>();
        });

        GetControl<Button>("Restart").onClick.AddListener(() =>
        {
            //重新加载场景
            SceneMgr.Instance.LoadSceneAsyn(sceneName);
        });

        GetControl<Button>("SL").onClick.AddListener(() =>
        {
            //弹出存档界面
            UIMgr.Instance.HidePanel<PausePanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<SLPanel>();
        });

        GetControl<Button>("Return").onClick.AddListener(() =>
        {
            //返回标题
            UIMgr.Instance.HidePanel<PausePanel>();
            HideMe();
            SceneMgr.Instance.LoadSceneAsyn("StartScreen");
        });
    }
}
