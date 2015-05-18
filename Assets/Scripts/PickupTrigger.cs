using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {
	public string pickupKey;
	public string title;
	[TextArea]
	public string description;
	public Sprite image;

	public PickupView pickupView;
	public PlayerKnowledge knowledge;

	void OnTriggerEnter() {
		pickupView.ShowPickup(title, description, image);

		if (!knowledge.Contains(pickupKey)) {
			knowledge.Add(pickupKey);
		}

		Destroy(gameObject);
		knowledge.audio.Play();
	}
}
