using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {
	public CanvasGroup _canvasGroup;

	public void Hide() {
		_canvasGroup.alpha = 0f;
		_canvasGroup.blocksRaycasts = false;
	}

	public void Show() {
		_canvasGroup.alpha = 1f;
		_canvasGroup.blocksRaycasts = true;
	}
}
