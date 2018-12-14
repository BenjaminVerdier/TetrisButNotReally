using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

    private bool push = false;

	// Use this for initialization
	void Start () {

	}

	void Update () {
        if (push)
        {
            Push();
        }
    }
	void OnMouseDown () {
        push = true;
	}

    void OnMouseUp() {
        push = false;
    }

    void Push() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = gameObject.transform.position - mousePos;
        this.GetComponent<Rigidbody>().AddForce(dir.normalized * 4, ForceMode.Impulse);
    }
}
