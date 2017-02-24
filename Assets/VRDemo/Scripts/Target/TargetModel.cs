using System;
using UnityEngine;

public class TargetModel : Model {
	public float multiplier = 1.0f;

	public Action<float,float> onUpdateRotation;
	public Action<float> onUpdateTarget;
	public Action onEnable, onDisable;

	[SerializeField]
	private float x, y;
	private float progress;

	void Update () {
//		UpdateRotation ();
	}

	public void Enable () {
		if (this.onEnable != null) {
			this.onEnable ();
		}
	}

	public void Disable () {
		if (this.onDisable != null) {
			this.onDisable ();
		}
	}

	public void UpdateRotation () {
		if (this.onUpdateRotation != null) {
			this.onUpdateRotation (x, y);
		}
	}

	public void UpdateTarget () {
		this.progress += Time.deltaTime * multiplier;
		if (this.progress > 1.0f) {
			this.progress = 1.0f;
		}

		if (this.onUpdateTarget != null) {
			this.onUpdateTarget (progress);
		}
	}
}
