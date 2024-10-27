using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed = 10;

    private Queue<string> paragraphs = new Queue<string>();
    private bool conversationEnded;
    private bool isTyping;
    private string p;
    private Coroutine typeDialogueCoroutine;
    
    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //队列为空
        if(paragraphs.Count==0)
        {
            //对话未结束
            if(!conversationEnded)
            {
                //开始对话
                StartConversation(dialogueText);
            }
            else
            {
                //结束对话
                EndConversation();
                return;
            }
        }
        //队列不为空
        if(!isTyping)
        {
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
            //StartCoroutine(Textwidth());
        }
        
        //更新对话
        //NPCDialogueText.text = P;
        if(paragraphs.Count==0)
        {
            conversationEnded = true;
        }
    }
    private void StartConversation(DialogueText dialogueText)
    {
        //激活对象
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        NPCNameText.text = dialogueText.speakerName;
        for(int i=0;i<dialogueText.paragraphs.Length;i++)
        {
            //入队
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }
    private void EndConversation()
    {
        //清空队列

        //禁用
        conversationEnded = false;

        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    //逐字输入
    private IEnumerator TypeDialogueText(string p)
    {
        float elapsedTime = 0f;
        int charIndex = 0;
        charIndex = Mathf.Clamp(charIndex, 0, p.Length);
        while(charIndex<p.Length)
        {
            elapsedTime += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);
            NPCDialogueText.text = p.Substring(0, charIndex);
            yield return null;
        }
        NPCDialogueText.text = p;
    }
    //自适应
    //private IEnumerator Textwidth()
    //{
    //    ContentSizeFitter _contentSizeFitter = gameObject.GetComponent<ContentSizeFitter>();
    //    while(true)
    //    {
    //        if(NPCDialogueText.rectTransform.rect.width>=300)
    //        {
    //            Debug.Log("到达300");
    //            _contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    //            NPCDialogueText.rectTransform.sizeDelta = new Vector2(300, NPCDialogueText.rectTransform.rect.height);
    //            break;
    //        }
    //        yield return null;
    //    }
    //}
}
