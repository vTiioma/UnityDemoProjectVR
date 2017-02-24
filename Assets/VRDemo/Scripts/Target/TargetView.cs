using UnityEngine;

public class TargetView : View {
	[SerializeField]
	private TargetModel model;
	private Animator animator;

	private void Awake () {
		this.animator = this.gameObject.GetComponentInChildren<Animator> ();
		this.model.onUpdateTarget += this.OnUpdateTarget;

		this.model.onEnable += OnEnable;
		this.model.onDisable += OnDisable;
	}

	private void OnDestroy () {
		this.model.onUpdateTarget -= this.OnUpdateTarget;

		this.model.onEnable -= OnEnable;
		this.model.onDisable -= OnDisable;
	}

	private void OnUpdateTarget (float progress) {

	}

	private void OnUpdateRotation (float x, float y) {
		this.animator.SetFloat ("x", x);
		this.animator.SetFloat ("y", y);
	}

	private void OnEnable () {
		this.transform.parent.position = Vector3.zero;
		this.transform.parent.gameObject.SetActive (true);
	}

	private void OnDisable () {
		this.transform.parent.gameObject.SetActive (false);
	}
}
