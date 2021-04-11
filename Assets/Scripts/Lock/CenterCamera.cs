using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCamera : MonoBehaviour {
	public Transform _camera;
	public Transform _target;

	public GameObject _playerMovement;
	public GameObject _mouseLook;

	public GameObject _canvas;

	Vector3 _cameraPlayerPosition = Vector3.zero;
	Quaternion _cameraPlayerRotation = Quaternion.identity;
	bool _hasCenteredCamera = false;

	static readonly int s_layerMask = 1 << 5; // UI = 5

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast(
				ray: Camera.main.ScreenPointToRay(Input.mousePosition),
				hitInfo: out RaycastHit hit,
				maxDistance: Mathf.Infinity,
				layerMask: s_layerMask)) {
				if (hit.transform.gameObject == gameObject) {
					_playerMovement.GetComponent<PlayerMovement>().enabled = false;
					_mouseLook.GetComponent<MouseLook>().enabled = false;
					Cursor.lockState = CursorLockMode.None;

					if (!_hasCenteredCamera) {
						_cameraPlayerPosition = _camera.position;
						_cameraPlayerRotation = _camera.rotation;
					}
					_camera.position = _target.position + _target.forward;
					_camera.LookAt(_target);
					_hasCenteredCamera = true;

					_canvas.GetComponent<ToggleUI>().Hide();
				}
			} else {
				_playerMovement.GetComponent<PlayerMovement>().enabled = true;
				_mouseLook.GetComponent<MouseLook>().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				_canvas.GetComponent<ToggleUI>().Show();

				if (_cameraPlayerPosition != Vector3.zero && _cameraPlayerRotation != Quaternion.identity) {
					_camera.SetPositionAndRotation(_cameraPlayerPosition, _cameraPlayerRotation);
					_cameraPlayerPosition = Vector3.zero;
					_cameraPlayerRotation = Quaternion.identity;
					_hasCenteredCamera = false;
				}
			}
		}
	}
}

