using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueSystem : ScriptableObject
{
    public DialogueSection[] sections;

    [System.Serializable]
    public struct DialogueSection
    {
        [TextArea]
        public string[] dialogue;
        
    }
}
