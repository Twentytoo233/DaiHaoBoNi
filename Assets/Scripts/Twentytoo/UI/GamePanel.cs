using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
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

    // Start is called before the first frame update
    private void Start()
    {
        UIMgr.Instance.ShowPanel<GamePanel>();

        AllEvent();
    }

    private void Update()
    {
        //按下esc键或点击右上角暂停按钮 弹出暂停面板
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPause();
        }
    }

    private void AllEvent()
    {
        GetControl<Button>("PauseButton").onClick.AddListener(() =>
        {
            ShowPause();
        }); 
    }
    private void ShowPause()
    {
        Time.timeScale = 0;//暂停
        UIMgr.Instance.HidePanel<GamePanel>();
        HideMe();
        Debug.Log("游戏暂停");
        UIMgr.Instance.ShowPanel<PausePanel>();
    }
}
