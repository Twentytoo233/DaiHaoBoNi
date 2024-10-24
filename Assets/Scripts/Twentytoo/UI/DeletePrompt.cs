using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletePrompt : BasePanel
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
        //ÊÇ É¾³ý´æµµ
        GetControl<Button>("OKButton").onClick.AddListener(() =>
        {
            Debug.Log("É¾³ý´æµµ");
        });
        //·ñ ·µ»ØÉÏÒ»¸öÃæ°å
        GetControl<Button>("NoButton").onClick.AddListener(() =>
        {
            UIMgr.Instance.HidePanel<DeletePrompt>();
            HideMe();
        });
    }
}
