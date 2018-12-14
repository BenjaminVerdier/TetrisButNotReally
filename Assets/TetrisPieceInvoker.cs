using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPieceInvoker : MonoBehaviour {

    public GameObject[] pieces;
    

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, transform.rotation);
        }
    }
}
