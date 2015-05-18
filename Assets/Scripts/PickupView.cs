using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class PickupView : MonoBehaviour {
	public Image imageSprite;
	public Text titleText;
	public Text descriptionText;

	Animation anim;
	bool activated;

	void Start() {
		anim = GetComponent<Animation>();
	}

	void Update() {
		if (Input.GetAxis("Vertical") < -.1 && activated) {
			activated = false;
			anim.Play("PickupDeactivate");
		}
	}

	public void ShowPickup(string title, string description, Sprite image) {
		imageSprite.sprite = image;
		titleText.text = title;
		descriptionText.text = description;

		activated = true;
		anim.Play("PickupActivate");
	}
}