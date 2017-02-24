using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloaderController : Controller {
	[SerializeField]
	private PreloaderModel model;

	private AsyncOperation operation;

	// Use this for initialization
	private IEnumerator Start () {
		yield return new WaitForSeconds (1.0f);

		operation = SceneManager.LoadSceneAsync (1);
		operation.allowSceneActivation = false;

		while (!operation.isDone) {
			model.progress = operation.progress;
			if (operation.progress == 0.9f) {
				model.progress = 1.0f;
				yield return new WaitForSeconds (1.0f);
				operation.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}
