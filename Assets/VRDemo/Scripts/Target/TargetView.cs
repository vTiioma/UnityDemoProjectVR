using UnityEngine;

public class TargetView : View {
	[SerializeField]
	private TargetModel model;
	[Space]
	[SerializeField]
	private Renderer rend;
	private Animator animator;
	private ValueRandomizer valueX, valueY;

	private void Awake () {
		this.animator = this.gameObject.GetComponentInChildren<Animator> ();
		this.rend = this.gameObject.GetComponentInChildren<Renderer> ();
		this.rend.material.color = Color.magenta;
		this.valueX = new ValueRandomizer ((MonoBehaviour)this, ((float x) => this.animator.SetFloat ("x", x)));
		this.valueY = new ValueRandomizer ((MonoBehaviour)this, ((float y) => this.animator.SetFloat ("y", y)));

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
		this.rend.material.color = Color.Lerp (Color.magenta, Color.cyan, progress);
	}

	private void OnEnable () {
		this.transform.parent.position = Vector3.zero;
		this.transform.parent.gameObject.SetActive (true);
		this.rend.material.color = Color.magenta;
	}

	private void OnDisable () {
		this.transform.parent.gameObject.SetActive (false);
	}
}
