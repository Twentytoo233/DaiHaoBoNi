using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Start_SLPanel : BasePanel
{
    private CanvasGroup PanelGroup;
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
        AllEvent();
    }

    /// <summary>
    /// ��ӿؼ������¼�
    /// </summary>
    private void AllEvent()
    {
        GetControl<Button>("SLButton").onClick.AddListener(() =>
        {
            Debug.Log("ѡ��");
            UIMgr.Instance.ShowPanel<RightPanel>();
        });
    }
}
