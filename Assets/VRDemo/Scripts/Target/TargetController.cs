using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetController : Controller {
	[SerializeField]
	private TargetModel model;

	public void OnPointerEnter (BaseEventData e) {
		this.model.StartTargetUpdate ();
	}

	public void OnPointerExit (BaseEventData e) {
		this.model.StopTargetUpdate ();
	}

	public void Enable () {
		this.model.Enable ();
	}

	public void Disable () {
		this.model.Disable ();
	}
}
