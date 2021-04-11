using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LockControl : MonoBehaviour {
	public List<GameObject> _lockWheels = new List<GameObject>(4);
	public GameObject _shackle;
	public int[] _correctCombination = new int[4];

	int[] _result;
	bool _isOpened;

	private void Start() {
		_result = new int[] { 0, 0, 0, 0 };
		_isOpened = false;
		RotateWheel.Rotated += CheckResults;
	}

	private void CheckResults(GameObject wheel, int number) {
		_result[_lockWheels.IndexOf(wheel)] = number;

		if (_result.SequenceEqual(_correctCombination) && !_isOpened) {
			_isOpened = true;
			StartCoroutine("MoveShackle");
		}
	}

	private IEnumerator MoveShackle() {
		yield return new WaitForSeconds(0.15f);
		_shackle.transform.Translate(new Vector3(0f, 0.01f, 0f));
	}

	private void OnDestroy() {
		RotateWheel.Rotated -= CheckResults;
	}
}
