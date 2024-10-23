using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_SLPanel : BasePanel
{
    public Button slInfoBtn;
    public override void HideMe()
    {
        gameObject.SetActive(false);
    }

    public override void ShowMe()
    {
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        slInfoBtn = GetControl<Button>("SLInfoBtn");
    }

    // Update is called once per frame
    void Update()
    {
        //�浵ҳ�Ŀ�ʼ��ť
        //ѡ�д浵 �����ʼ��Ϸ
        GetControl<Button>("SLInfoBtn").onClick.AddListener(() =>
        {
            //ѡ�� ��ɫ�仯
            slInfoBtn.GetComponent<Image>().color = Color.blue;
            
        });
    }
}
