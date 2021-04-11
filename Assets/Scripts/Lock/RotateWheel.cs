using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour {
	public static event Action<GameObject, int> Rotated = delegate { };

	bool _coroutineAllowed;
	int _numberShown;

	static readonly int s_layerMask = 1 << 5; // UI = 5

	private void Start() {
		_coroutineAllowed = true;
		_numberShown = 0;
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast(
				ray: Camera.main.ScreenPointToRay(Input.mousePosition),
				hitInfo: out RaycastHit hit,
				maxDistance: Mathf.Infinity,
				layerMask: ~s_layerMask)) {
				if (hit.transform.gameObject == gameObject) {
					if (_coroutineAllowed) {
						StartCoroutine("Rotate");
					}
				}
			}
		}
	}

	private IEnumerator Rotate() {
		_coroutineAllowed = false;

		for (int i = 0; i <= 11; i++) {
			transform.Rotate(0f, -3f, 0f);
			yield return new WaitForSeconds(0.01f);
		}

		_coroutineAllowed = true;

		_numberShown += 1;
		if (_numberShown > 9) {
			_numberShown = 0;
		}

		Rotated(gameObject, _numberShown);
	}
}
