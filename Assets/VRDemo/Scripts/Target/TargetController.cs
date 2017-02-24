using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetController : Controller {
	[SerializeField]
	private TargetModel model;

	public void OnPointerEnter (BaseEventData e) {
		Debug.Log ("enter");
	}

	public void OnPointerExit (BaseEventData e) {
		Debug.Log ("exit");
	}

	public void Enable () {
		this.model.Enable ();
	}

	public void Disable () {
		this.model.Disable ();
	}
}
