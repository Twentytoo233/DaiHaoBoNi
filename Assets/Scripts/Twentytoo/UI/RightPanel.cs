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
        AllEvent();
    }

    private void AllEvent()
    {
        GetControl<Button>("StartSaveBtn").onClick.AddListener(() =>
        {
            Debug.Log("�Ӵ浵��ʼ��Ϸ");
            //��ת���浵��
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}