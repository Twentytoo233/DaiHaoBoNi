using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class RollerController : MonoBehaviour
{
    [System.Serializable]
    public struct RollerChildInfo
    {
        public Vector3 Position;
        public Vector3 Scale;

        public RollerChildInfo(Vector3 _pos, Vector3 _scale)
        {
            Position = _pos;
            Scale = _scale;
        }
    }
    //针对无序的RawImage，使用Sequence帮助其顺时针排序
    [Header("RawImage在数组中的顺序")]
    public int[] Sequence;
    [Header("RawImage数组")]
    public RawImage[] RawImages;
    [Header("RawImage属性信息，从左往右")]
    public RollerChildInfo[] RollerChilds;
    //当前的排列
    private int[] CurrentSequence;
    //是否需要更新
    private bool IsNeedUpdateRoller = false;

    void Start()
    {
        if (Sequence.Length == 0 || RawImages.Length == 0)
        {
            Debug.Log("请填写至少两个RawImage组件信息");
            return;
        }
        //
        CurrentSequence = new int[Sequence.Length];
        for (int i = 0; i < CurrentSequence.Length; i++)
        {
            CurrentSequence[i] = Sequence[i];
        }

        if (RollerChilds == null || RollerChilds.Length == 0)
        {
            //获取，信息
            RollerChilds = new RollerChildInfo[RawImages.Length];
            for (int i = 0; i < RawImages.Length; i++)
            {
                if (RawImages[i] != null)
                {
                    RollerChilds[i].Position = RawImages[i].rectTransform.localPosition;
                    RollerChilds[i].Scale = RawImages[i].rectTransform.localScale;
                }
            }
        }
        Debug.Log("RollerChilds:" + RollerChilds.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNeedUpdateRoller)
        {
            if (Vector3.Distance(RawImages[CurrentSequence[0]].rectTransform.localPosition, RollerChilds[0].Position) > 5.0f)
            {
                for (int i = 0; i < RawImages.Length; i++)
                {
                    RawImages[CurrentSequence[i]].rectTransform.localPosition = Vector3.Lerp(RawImages[CurrentSequence[i]].rectTransform.localPosition, RollerChilds[i].Position, 0.1f);
                    RawImages[CurrentSequence[i]].rectTransform.localScale = Vector3.Lerp(RawImages[CurrentSequence[i]].rectTransform.localScale, RollerChilds[i].Scale, 0.1f);
                    if (i != RawImages.Length - 1)
                    {
                        RawImages[CurrentSequence[i]].transform.SetAsFirstSibling();
                    }
                    else
                    {
                        RawImages[CurrentSequence[0]].transform.SetAsLastSibling();
                    }
                }
            }
            else
            {
                //切换完成，todo
                IsNeedUpdateRoller = false;
            }
        }
        //按数字2切换
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(this.gameObject.name);
            StartCoroutine(MoveLeft());
        }
        
    }
    IEnumerator MoveLeft()
    {
        if (!IsNeedUpdateRoller)
        {
            int[] tempSequence = new int[CurrentSequence.Length];
            for (int i = 0; i < CurrentSequence.Length; i++)
                tempSequence[i] = CurrentSequence[i];
            for (int i = 0; i < tempSequence.Length; i++)
            {
                if (i < tempSequence.Length - 1)
                {
                    CurrentSequence[i] = tempSequence[i + 1];
                }
                else
                {
                    CurrentSequence[i] = tempSequence[0];
                }
            }
            IsNeedUpdateRoller = true;
        }
        yield return null;
    }
    IEnumerator MoveRight()
    {
        if (!IsNeedUpdateRoller)
        {
            int[] tempSequence = new int[CurrentSequence.Length];
            for (int i = 0; i < CurrentSequence.Length; i++)
            {
                tempSequence[i] = CurrentSequence[i];
            }
            for (int i = 0; i < tempSequence.Length; i++)
            {
                if (i == 0)
                {
                    CurrentSequence[i] = tempSequence[tempSequence.Length - 1];
                }
                else
                {
                    CurrentSequence[i] = tempSequence[i - 1];
                }
            }
            IsNeedUpdateRoller = true;
        }
        yield return null;
    }
    public void UpdateRoller(bool left)
    {
        if (!this.gameObject.activeSelf) return;
        if (left)
        {
            Debug.Log(this.gameObject.name);
            StartCoroutine(MoveLeft());
        }
        else
        {
            Debug.Log(this.gameObject.name);
            StartCoroutine(MoveRight());
        }
    }

    public int GetSelected()
    {
        return CurrentSequence[0];
    }

    public Vector3 GetFirstChildPosition()
    {
        if (RawImages != null && RawImages[CurrentSequence[0]] != null)
        {
            return RawImages[CurrentSequence[0]].gameObject.GetComponent<RectTransform>().localPosition;
        }
        return new Vector3(0, 0, 0);
    }
}