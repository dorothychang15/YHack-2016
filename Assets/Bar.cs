using UnityEngine;
using System.Collections.Generic;

public class Bar : MonoBehaviour {

	public GameObject us;
	public GameObject china;
	public GameObject russia;
	public Dictionary<string, Dictionary<string, long>> data;
	public Dictionary<string, GameObject> map;
	int time;
	int count;

	// Use this for initialization
	void Start () {
		LoadData getData = GetComponent<LoadData>();
		getData.Start();
		data = getData.data;
		map = new Dictionary<string, GameObject> ();
		map.Add ("United States", us);
		map.Add ("China", china);
		map.Add ("Russian Federation", russia);
		time = 0;
		count = 0;
	}

	public void draw (float count) {
		foreach(KeyValuePair<string, GameObject> entry in map)
		{
			GameObject obj = entry.Value;
			if (count < data[entry.Key]["\"2015\""]) {
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
	}

}
