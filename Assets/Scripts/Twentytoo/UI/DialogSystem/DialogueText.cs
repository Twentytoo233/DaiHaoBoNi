using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialogue/New Diaogue Content")]
public class DialogueText : ScriptableObject
{
    public string speakerName;

    [TextArea(5,10)]
    public string[] paragraphs;
}
