using UnityEngine;

public class TargetParticleView : MonoBehaviour {
	[SerializeField]
	private TargetModel model;
	[Space]
	public int mixParticles = 8;
	public int maxParticles = 20;
	[SerializeField]
	private ParticleSystem particles;

	private void Awake () {
		this.particles = this.gameObject.GetComponentInChildren<ParticleSystem> ();

		this.model.onDisable += OnDisable;
	}

	private void OnDestroy () {
		this.model.onDisable -= OnDisable;
	}

	private void OnDisable () {
		this.particles.Emit (Random.Range (mixParticles, maxParticles));
	}
}
