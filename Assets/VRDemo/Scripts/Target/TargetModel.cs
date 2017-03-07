using System;
using UnityEngine;

public class TargetModel : Model {
	public float multiplier = 1.0f;

	public Action<float> onUpdateTarget;
	public Action onEnable, onDisable;

	private RepeatLoop repeatLoop;
	[SerializeField]
	private float progress;

	private void Awake () {
		TargetObserver.onTargetSelected += this.OnTargetSelected;
		TargetObserver.onFull += this.OnFull;
		repeatLoop = new RepeatLoop ((MonoBehaviour)this, UpdateTarget);
	}

	private void OnDestroy () {
		TargetObserver.onTargetSelected -= this.OnTargetSelected;
		TargetObserver.onFull -= this.OnFull;
	}

	private void OnTargetSelected (TargetModel target) {
		if (target == this) {
			if (this.onEnable != null) {
				this.onEnable ();
			}
		}
	}

	private void OnFull (TargetModel target) {
		if (target == this) {
			if (this.onDisable != null) {
				this.onDisable ();
			}
		}
	}

	public void StartTargetUpdate () {
		repeatLoop.Start ();
	}

	public void StopTargetUpdate () {
		repeatLoop.Stop ();
	}

	private void UpdateTarget () {
		this.progress += Time.deltaTime * multiplier;
		if (this.progress > 1.0f) {
			this.progress = 1.0f;
		}

		if (this.onUpdateTarget != null) {
			this.onUpdateTarget (progress);
		}

		if (this.progress == 1.0f) {
			TargetObserver.OnFull (this);
		}
	}
}
