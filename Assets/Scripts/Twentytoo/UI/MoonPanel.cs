using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPanel : BasePanel
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
        //°´ÏÂ1 ÇÐ»»
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchSkill();
        }
    }

    private void SwitchSkill()
    {
        UIMgr.Instance.HidePanel<MoonPanel>();
        HideMe();
        UIMgr.Instance.ShowPanel<SunPanel>();
    }
}
