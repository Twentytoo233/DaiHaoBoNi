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
    //��������RawImage��ʹ��Sequence������˳ʱ������
    [Header("RawImage�������е�˳��")]
    public int[] Sequence;
    [Header("RawImage����")]
    public RawImage[] RawImages;
    [Header("RawImage������Ϣ����������")]
    public RollerChildInfo[] RollerChilds;
    //��ǰ������
    private int[] CurrentSequence;
    //�Ƿ���Ҫ����
    private bool IsNeedUpdateRoller = false;

    void Start()
    {
        if (Sequence.Length == 0 || RawImages.Length == 0)
        {
            Debug.Log("����д��������RawImage�����Ϣ");
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
            //��ȡ����Ϣ
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
                //�л���ɣ�todo
                IsNeedUpdateRoller = false;
            }
        }
        //������2�л�
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