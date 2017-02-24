using System;
using UnityEngine;

public class PreloaderModel : Model {
	public event Action<float> onProgressUpdate;
	public event Action onProgressComplete;

	public float progress {
		get {
			return _progress;
		}
		set {
			_progress = 0;

			if (onProgressUpdate != null)
				onProgressUpdate (value);

			if (value == 1.0 && onProgressComplete != null)
				onProgressComplete ();
		}
	}

	private float _progress = 0.0f;
}
