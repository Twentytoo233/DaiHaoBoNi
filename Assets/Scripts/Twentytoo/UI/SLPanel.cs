using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLPanel : BasePanel
{
    /*ѡ��Save->ѡ��һ���浵λ->ȷ��->����浵λΪ�� ������ʾ�� �浵�ɹ�
                                    ->��Ϊ�� �����Ƿ񸲸Ǵ浵
      ѡ��Load->ѡ��һ���浵λ->ȷ��->����*/
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
