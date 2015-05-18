using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueView : MonoBehaviour {
	public PlayerKnowledge knowledge;

	[Space(20f)]
	public Text text;

	public Button option1button;
	public Text option1text;

	public Button option2button;
	public Text option2text;

	public Button option3button;
	public Text option3text;

	public Button option4button;
	public Text option4text;

	public Dialogue dialogue;

	Animation animation;

	void Start() {
		animation = GetComponent<Animation>();
	}

	public bool activated {get; private set;}

	public void StartDialogue(Dialogue dialogue) {
		this.dialogue = dialogue;
		animation.Play("DialogueActivate");
		activated = true;
		UpdateDialogue();
	}

	public void EndDialogue() {
		this.dialogue = null;
		animation.Play("DialogueDeactivate");
		activated = false;
	}

	public void UpdateDialogue() {
		text.text = dialogue.current.text;
		//Debug.LogError("Moved to node: "+dialogue.current.name);
		if (dialogue.current.blocker) dialogue.current.blocker.SetActive(false);

		if (!string.IsNullOrEmpty(dialogue.current.newKey)) {
			knowledge.Add(dialogue.current.newKey);
			//Debug.LogError("Added key: "+dialogue.current.newKey);
		}

		//==== Option 1
		if (option1button) {
		if (!string.IsNullOrEmpty(dialogue.current.option1)) {
			option1text.text = dialogue.current.option1;

			if (ValidKey(dialogue.current.option1Key)) {
				option1button.gameObject.SetActive(false);
			} else {
				option1button.gameObject.SetActive(true);
			}
		} else {
			option1button.gameObject.SetActive(false);
		}
		}

		//==== Option 2
		if (option2button) {
		if (!string.IsNullOrEmpty(dialogue.current.option2)) {
			option2text.text = dialogue.current.option2;
			
			if (ValidKey(dialogue.current.option2Key)) {
				option2button.gameObject.SetActive(false);
			} else {
				option2button.gameObject.SetActive(true);
			}
		} else {
			option2button.gameObject.SetActive(false);
		}
		}

		//==== Option 3
		if (option3button) {
		if (!string.IsNullOrEmpty(dialogue.current.option3)) {
			option3text.text = dialogue.current.option3;
			
			if (ValidKey(dialogue.current.option3Key)) {
				option3button.gameObject.SetActive(false);
			} else {
				option3button.gameObject.SetActive(true);
			}
		} else {
			option3button.gameObject.SetActive(false);
		}
		}

		//==== Option 4
		if (option4button) {
		if (!string.IsNullOrEmpty(dialogue.current.option4)) {
			option4text.text = dialogue.current.option4;
			
			if (ValidKey(dialogue.current.option4Key)) {
				option4button.gameObject.SetActive(false);
			} else {
				option4button.gameObject.SetActive(true);
			}
		} else {
			option4button.gameObject.SetActive(false);
		}
		}
	}

	public void OnClick1() {
		if (dialogue.current.option1Node) {
			dialogue.current = dialogue.current.option1Node;
			UpdateDialogue();
		} else {
			EndDialogue();
		}
	}

	public void OnClick2() {
		if (dialogue.current.option2Node) {
			dialogue.current = dialogue.current.option2Node;
			UpdateDialogue();
		} else {
			EndDialogue();
		}
	}

	public void OnClick3() {
		if (dialogue.current.option3Node) {
			dialogue.current = dialogue.current.option3Node;
			UpdateDialogue();
		} else {
			EndDialogue();
		}
	}

	public void OnClick4() {
		if (dialogue.current.option4Node) {
			dialogue.current = dialogue.current.option4Node;
			UpdateDialogue();
		} else {
			EndDialogue();
		}
	}

	//returns false if the key is empty or not found.
	bool ValidKey(string key) {
		if (string.IsNullOrEmpty(key)) {
			return false;
		}

		if (key.StartsWith("!")) {
			if (knowledge.Contains(key.Remove(0,1))) {
				return true;
			} else {
				return false;
			}
		} else {
			if (knowledge.Contains(key)) {
				return false;
			} else {
				return true;
			}
		}
	}
}
