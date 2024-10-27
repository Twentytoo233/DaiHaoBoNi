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
        //����Ϊ��
        if(paragraphs.Count==0)
        {
            //�Ի�δ����
            if(!conversationEnded)
            {
                //��ʼ�Ի�
                StartConversation(dialogueText);
            }
            else
            {
                //�����Ի�
                EndConversation();
                return;
            }
        }
        //���в�Ϊ��
        if(!isTyping)
        {
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
            //StartCoroutine(Textwidth());
        }
        
        //���¶Ի�
        //NPCDialogueText.text = P;
        if(paragraphs.Count==0)
        {
            conversationEnded = true;
        }
    }
    private void StartConversation(DialogueText dialogueText)
    {
        //�������
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        NPCNameText.text = dialogueText.speakerName;
        for(int i=0;i<dialogueText.paragraphs.Length;i++)
        {
            //���
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }
    private void EndConversation()
    {
        //��ն���

        //����
        conversationEnded = false;

        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    //��������
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
    //����Ӧ
    //private IEnumerator Textwidth()
    //{
    //    ContentSizeFitter _contentSizeFitter = gameObject.GetComponent<ContentSizeFitter>();
    //    while(true)
    //    {
    //        if(NPCDialogueText.rectTransform.rect.width>=300)
    //        {
    //            Debug.Log("����300");
    //            _contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    //            NPCDialogueText.rectTransform.sizeDelta = new Vector2(300, NPCDialogueText.rectTransform.rect.height);
    //            break;
    //        }
    //        yield return null;
    //    }
    //}
}
