using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLPanel : BasePanel
{
    /*选中Save->选中一个存档位->确定->如果存档位为空 弹出提示框 存档成功
                                    ->不为空 弹出是否覆盖存档
      选中Load->选中一个存档位->确定->读档*/
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
