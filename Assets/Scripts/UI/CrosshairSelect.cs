using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSelect : MonoBehaviour {
	Image _crosshair;
	public Sprite _defaultCrosshair, _onFocusCrosshair;

	static readonly int s_layerMask = 1 << 5; // UI = 5

	private void Start() {
		_crosshair = GetComponent<Image>();
	}

	private void Update() {
		if (Physics.Raycast(
			ray: Camera.main.ScreenPointToRay(Input.mousePosition),
			hitInfo: out RaycastHit hit,
			maxDistance: Mathf.Infinity,
			layerMask: s_layerMask)) {
			_crosshair.sprite = _onFocusCrosshair;
		} else {
			_crosshair.sprite = _defaultCrosshair;
		}
	}
}
