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
        //存档页的开始按钮
        //选中存档 点击开始游戏
        GetControl<Button>("SLInfoBtn").onClick.AddListener(() =>
        {
            //选中 颜色变化
            slInfoBtn.GetComponent<Image>().color = Color.blue;
            
        });
    }
}
