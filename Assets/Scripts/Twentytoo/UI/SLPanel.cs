using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLPanel : BasePanel
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

    private void Start()
    {
        AllEvent();
    }
    private void AllEvent()
    {

    }
}
