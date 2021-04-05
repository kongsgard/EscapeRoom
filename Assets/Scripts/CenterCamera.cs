using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCamera : MonoBehaviour {
	public Transform _camera;
	public Transform _target;

	public GameObject _playerMovement;
	public GameObject _mouseLook;

	Vector3 _cameraPlayerPosition = Vector3.zero;
	Quaternion _cameraPlayerRotation = Quaternion.identity;
	bool _hasCenteredCamera = false;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity)) {
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
				}
			} else {
				_playerMovement.GetComponent<PlayerMovement>().enabled = true;
				_mouseLook.GetComponent<MouseLook>().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;

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
