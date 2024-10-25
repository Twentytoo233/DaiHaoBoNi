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
            Debug.Log("������Ϸ");
            UIMgr.Instance.HidePanel<PausePanel>();
            HideMe();
            //��ʾ����ʱ
            UIMgr.Instance.ShowPanel<CountDown>();
        });

        GetControl<Button>("Restart").onClick.AddListener(() =>
        {
            //���¼��س���
            SceneMgr.Instance.LoadSceneAsyn(sceneName);
        });

        GetControl<Button>("SL").onClick.AddListener(() =>
        {
            //�����浵����
            UIMgr.Instance.HidePanel<PausePanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<SLPanel>();
        });

        GetControl<Button>("Return").onClick.AddListener(() =>
        {
            //���ر���
            UIMgr.Instance.HidePanel<PausePanel>();
            HideMe();
            SceneMgr.Instance.LoadSceneAsyn("StartScreen");
        });
    }
}
