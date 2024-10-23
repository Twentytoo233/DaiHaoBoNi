using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

public class TurnOnPanel : BasePanel
{
    private double video_time, currentTime;

    public GameObject video_img1;
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
        //video_time = video_img1.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > video_time)
        {
            //视频播放结束，这里可以写视频播放结束后的事件
            UIMgr.Instance.HidePanel<TurnOnPanel>();
            HideMe();
            UIMgr.Instance.ShowPanel<MemoryPanel>();
        }

    }
}
