using UnityEngine;
using System.Collections;

public class LineActivator : MonoBehaviour {
	public GameObject line;

	void OnDisable() {
		line.SetActive(true);
	}
}
