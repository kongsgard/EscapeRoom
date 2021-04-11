using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public float _mouseSensitivity = 200f;

	public Transform _playerBody;

	float _xRotation = 0f;

	private void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update() {
		float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

		_xRotation -= mouseY;
		_xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
		_playerBody.Rotate(Vector3.up * mouseX);
	}
}
