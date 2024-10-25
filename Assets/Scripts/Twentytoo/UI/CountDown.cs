using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : BasePanel
{
    private TMP_Text textTime;
    public int second = 120;
    public float totalTime;
    int M;
    int S;
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
        textTime = GetControl<TMP_Text>("TextTime");
        //AllEvent();
        //Timer2();
    }

    private void Update()
    {
        Timer2();
    }

    private void Timer2()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= 1)
        {
            second--;
            if (second >= 0)
            {
                totalTime -= 1;
                M = second / 60;
                S = second % 60;
                textTime.text = string.Format("{0:d2}:{1:d2}", M, S);
                if (M == 0 && S == 3)//3秒后继续游戏
                {
                    Time.timeScale = 1;
                    Debug.Log("继续游戏");
                    UIMgr.Instance.HidePanel<CountDown>();
                    HideMe();
                }
            }
            else Time.timeScale = 0;

        }
    }

    //private void AllEvent()
    //{
    //    throw new NotImplementedException();
    //}
}
