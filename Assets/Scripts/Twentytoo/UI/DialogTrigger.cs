using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    /*����ߵ��Ի���Χ�� �����Ի�E��ʾ �뿪��ײ�� ��ʾ��ʧ*/
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
        //��ʾ��ʾ
        UIMgr.Instance.ShowPanel<DialohueTip>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //�ر���ʾ
        UIMgr.Instance.HidePanel<DialohueTip>();
    }
}
