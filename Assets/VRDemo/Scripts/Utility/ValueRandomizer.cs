using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ValueRandomizer {
	private float progress = 0;
	private float duration;
	private float delay;

	private float value;
	private float startValue;
	private float targetValue;

	private IEnumerator routine;
	private readonly MonoBehaviour monoBehaviour;
	private readonly Action<float> onUpdate;

	public ValueRandomizer (MonoBehaviour monoBehaviour, Action<float> onUpdate) {
		this.monoBehaviour = monoBehaviour;
		this.onUpdate = onUpdate;
		this.Start ();
	}

	public void Start () {
		ResetBaseValues ();
		startValue = targetValue;
		SetRandomValues ();
		this.routine = randomizeValue ();

		this.monoBehaviour.StartCoroutine (this.routine);
	}

	private void StartNew () {
		this.monoBehaviour.StopCoroutine (this.routine);

		ResetBaseValues ();
		startValue = targetValue;
		SetRandomValues ();
		this.routine = randomizeValue ();

		this.monoBehaviour.StartCoroutine (this.routine);
	}

	private void ResetBaseValues () {
		this.progress = 0;
		this.value = 0;
	}

	private void SetRandomValues () {
		targetValue = Random.Range (-1.0f, 1.0f);
		duration = Random.Range (0.5f, 1.5f);
		delay = Random.Range (0.5f, 1.0f);
	}

	private IEnumerator randomizeValue () {
		while (progress < duration + delay) {
			value = Mathf.Lerp (startValue, targetValue, Mathf.Clamp (progress, 0, duration));
			if (onUpdate != null) {
				onUpdate (value);
			}

			progress += Time.smoothDeltaTime;
			yield return new WaitForEndOfFrame ();
		}
		StartNew ();
	}
}