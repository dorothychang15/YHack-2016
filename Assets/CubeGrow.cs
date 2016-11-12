using UnityEngine;
using System.Collections;

public class CubeGrow : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3 (0, 0.01f, 0);
		Vector3 position = transform.position;
		transform.position = new Vector3 (position.x, 0, position.z);
	}
}
