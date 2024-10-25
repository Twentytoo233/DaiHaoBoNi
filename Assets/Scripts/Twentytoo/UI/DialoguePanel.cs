using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DialoguePanel : BasePanel
{
    public Image npcDialog;
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
        //npcDialog = GetControl<Image>("NPCDialogBox");
        ////bubble.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth + 50f);
        //StartCoroutine("Textwidth");
    }
    //IEnumerator Textwidth()
    //{
    //    TMP_Text _text = GetControl<TMP_Text>("NPCDialogText");
    //    ContentSizeFitter _contentSizeFitter = npcDialog.gameObject.GetComponent<ContentSizeFitter>();
    //    while(true)
    //    {
    //        if(_text.rectTransform.rect.width>=200)
    //        {
    //            Debug.Log("´ïµ½200");
    //            _contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    //            _text.rectTransform.sizeDelta = new Vector2(200, _text.rectTransform.rect.height);
    //            break;
    //        }
    //        yield return null;
    //    }
    //}
}
