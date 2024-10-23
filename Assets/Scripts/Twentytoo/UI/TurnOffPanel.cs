using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TurnOffPanel : BasePanel
{
    private double video_time, currentTime;

    public GameObject video_img2;
    float tempProgress;
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
        video_time = 1f;
        //video_time = video_img2.GetComponent<VideoPlayer>().clip.length;

        tempProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > video_time)
        {
            //��Ƶ���Ž������������д��Ƶ���Ž�������¼�
            UIMgr.Instance.HidePanel<TurnOffPanel>();
            HideMe();
            //�л����³���
            EventCenter.Instance.AddEventListener<float>(E_EventType.E_SceneLoadChange, (o) => {
                UpdateProgess(o);
            });
            SceneMgr.Instance.LoadSceneAsyn("SceneL0", () =>
             {
                 Debug.Log("�����������");
             });
            
        }
    }
    public void UpdateProgess(float progessVal)
    {
        //tempProgress = Mathf.Lerp(tempProgress, progessVal,Time.deltaTime);
        tempProgress = progessVal;
        Debug.Log("���յ�" + tempProgress);
        //slider.value = tempProgress;
        //text.text = tempProgress * 100 + "%";
    }


}
