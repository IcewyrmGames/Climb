using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public GameObject menuUI;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (menuUI.activeSelf) {
				menuUI.SetActive(false);
			} else {
				menuUI.SetActive(true);
			}
		}
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void NewGame() {
		Application.LoadLevel(0);
	}
}
