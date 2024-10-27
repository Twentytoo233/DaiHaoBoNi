using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPanel : BasePanel
{
    private bool isSun = true;
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
        //UIMgr.Instance.ShowPanel<SunPanel>();
        //UIMgr.Instance.HidePanel<MoonPanel>();
    }
    private void Update()
    {
        //°´ÏÂ1 ÇÐ»»
        if(Input.GetKeyDown(KeyCode.Alpha1)&&isSun==true)
        {
            SwitchSkill();
            isSun = false;
        }
    }
    private void SwitchSkill()
    {
        UIMgr.Instance.HidePanel<SunPanel>();
        HideMe();
        UIMgr.Instance.ShowPanel<MoonPanel>();
    }
}
