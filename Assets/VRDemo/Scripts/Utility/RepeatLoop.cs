using System;
using System.Collections;
using UnityEngine;

public class RepeatLoop {
	private readonly Action updateCallback;
	private readonly MonoBehaviour monoBehaviour;
	private IEnumerator routine;

	public RepeatLoop (MonoBehaviour monoBehaviour, Action updateCallback) {
		this.updateCallback = updateCallback;
		this.monoBehaviour = monoBehaviour;
		this.routine = Loop ();
	}

	public static implicit operator bool (RepeatLoop reference) {
		return reference != null;
	}

	public void Start () {
		monoBehaviour.StartCoroutine (routine);
	}

	public void Stop () {
		monoBehaviour.StopCoroutine (routine);
	}

	private IEnumerator Loop () {
		while (true) {
			yield return new WaitForEndOfFrame ();
			updateCallback ();
		}
	}
}