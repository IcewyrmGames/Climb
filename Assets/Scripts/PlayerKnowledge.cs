using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerKnowledge : MonoBehaviour {
	public List<string> knowledge;

	public bool Contains(string s) {
		return knowledge.Contains(s);
	}

	public void Add(string s) {
		if (!knowledge.Contains(s)) {
			knowledge.Add(s);
		}
	}

	public void Remove(string s) {
		knowledge.Remove(s);
	}
}
