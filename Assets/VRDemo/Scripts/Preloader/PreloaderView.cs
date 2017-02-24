using UnityEngine;
using UnityEngine.UI;

public class PreloaderView : View {
	[SerializeField]
	private PreloaderModel model;
	[Space]
	public Image progressBar;
	public Text progressText;

	private void Awake () {
		model.onProgressUpdate += OnProgressUpdate;
		model.onProgressComplete += OnProgressComplete;
	}

	private void OnDestroy () {
		model.onProgressUpdate -= OnProgressUpdate;
		model.onProgressComplete -= OnProgressComplete;
	}

	private void OnProgressUpdate (float progress) {
		string progressPercent = (progress * 100).ToString ("###");
		progressText.text = "Progress: " + progressPercent + "%";
		progressBar.fillAmount = progress;
	}

	private void OnProgressComplete () {}
}
