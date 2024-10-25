using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    /*玩家走到对话范围内 弹出对话E提示 离开碰撞体 提示消失*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //显示提示
        UIMgr.Instance.ShowPanel<DialohueTip>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //关闭提示
        UIMgr.Instance.HidePanel<DialohueTip>();
    }
}
