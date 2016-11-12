using UnityEngine;
using System.Collections.Generic;

public class CubeGrow : MonoBehaviour {

	public GameObject us;
	public GameObject china;
	public Dictionary<string, int> data;
	public Dictionary<string, GameObject> map;

	// Use this for initialization
	void Start () {
		// read in input data
		// determine values for each
		data = new Dictionary<string, int>();
		data.Add ("us", 5);
		data.Add ("china", 10);
		map = new Dictionary<string, GameObject> ();
		map.Add ("us", us);
		map.Add ("china", china);
		draw ();
	}

	public void draw () {
		foreach(KeyValuePair<string, int> entry in data)
		{
			GameObject obj = map [entry.Key];
			for (int i = 0; i < entry.Value; i++) {
				grow (obj);
			}
		}
	}

	public void grow (GameObject obj) {
		obj.transform.localScale += new Vector3 (0, 0.1f, 0);
		Vector3 position = obj.transform.position;
		obj.transform.position = new Vector3 (position.x, 0, position.z);
	}


}
