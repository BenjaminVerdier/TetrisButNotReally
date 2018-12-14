using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void Update () {

	}
	void OnMouseDown () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 dir = gameObject.transform.position - mousePos;
		this.GetComponent<Rigidbody>().AddForce(dir.normalized * 10, ForceMode.Impulse);
	}
}
