using System;
using UnityEngine;

public class TargetObserver {
	public static event Action<TargetModel> onTargetSelected;
	public static event Action<TargetModel> onFull;

	public static void OnTargetSelected (TargetModel target) {
		if (onTargetSelected != null) {
			onTargetSelected (target);
		}
	}

	public static void OnFull (TargetModel target) {
		if (onFull != null) {
			onFull (target);
		}
	}
}
