using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeginView : MonoBehaviour {
	public Dialogue dialogue;
	public GameObject player;

	public Text text;
	public Text option1text;

	void Start() {
		UpdateDialogue();
	}

	public void UpdateDialogue() {
		text.text = dialogue.current.text;

		option1text.text = dialogue.current.option1;
	}

	public void NextNode() {
		if (dialogue.current.option1Node) {
			dialogue.current = dialogue.current.option1Node;
			UpdateDialogue();
		} else {
			animation.Play();
			Destroy(gameObject, 2.0f);
			player.SetActive(true);
		}
	}
}
