using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	public Dialogue dialogue;
	public DialogueView dialogueView;
	
	// Update is called once per frame
	void OnTriggerStay () {
		if (Input.GetKey(KeyCode.DownArrow)) {
			if (!dialogueView.activated) {
				dialogueView.StartDialogue(dialogue);
			}
		}
	}

	void OnTriggerExit() {
		if (dialogueView.activated) {
			dialogueView.EndDialogue();
		}
	}
}
