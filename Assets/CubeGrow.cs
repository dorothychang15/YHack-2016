using UnityEngine;
using System.Collections.Generic;

public class CubeGrow : MonoBehaviour {

	public GameObject us;
	public GameObject china;
	public Dictionary<string, int> data;
	public Dictionary<string, GameObject> map;
	int time;
	int count;

	// Use this for initialization
	void Start () {
		// read in input data
		// determine values for each
		data = new Dictionary<string, int>();
		data.Add ("us", 10);
		data.Add ("china", 20);
		map = new Dictionary<string, GameObject> ();
		map.Add ("us", us);
		map.Add ("china", china);
		time = 0;
		count = 0;
	}

	public void draw (int count) {
		foreach(KeyValuePair<string, int> entry in data)
		{
			GameObject obj = map [entry.Key];
			if (count < entry.Value) {
				grow (obj);
			}
		}
	}

	public void grow (GameObject obj) {
		obj.transform.localPosition += new Vector3(0, 0.0125f, 0);
		obj.transform.localScale += new Vector3 (0, 0.025f, 0);
	}

	void Update () {
		time++;
		if (time % 10 == 0) {
			draw (count);
			count++;
		}
		if (count == 20) {
			count = 0;
			us.transform.localScale = new Vector3 (1, 1, 1);
			us.transform.localPosition = new Vector3 (1, -0.21f, -0.41f);
			china.transform.localScale = new Vector3 (1, 1, 1);
			china.transform.localPosition = new Vector3 (2, 0, -0.87f);
		}
	}

}
