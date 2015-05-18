using UnityEngine;
using System.Collections;

public class DialogueNode : MonoBehaviour {
	[TextArea]
	public string text;
	public string newKey;

	[Space(10f)]
	public string option1Key;
	[Multiline] public string option1;
	public DialogueNode option1Node;

	[Space(10f)]
	public string option2Key;
	[Multiline] public string option2;
	public DialogueNode option2Node;

	[Space(10f)]
	public string option3Key;
	[Multiline] public string option3;
	public DialogueNode option3Node;

	[Space(10f)]
	public string option4Key;
	[Multiline] public string option4;
	public DialogueNode option4Node;

	[Space(20f)]
	public GameObject blocker;
}