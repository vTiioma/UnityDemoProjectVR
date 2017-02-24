using System;
using System.Collections;
using UnityEngine;

public class ValueRandomizer {
	private IEnumerator coroutine;
	private MonoBehaviour monoBehaviour;
	private Action<float> onUpdate;
	private Action onComplete;

	public ValueRandomizer (Action<float> onUpdate, Action onComplete) {
		
	}
}