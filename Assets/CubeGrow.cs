using UnityEngine;
using System.Collections.Generic;

public class CubeGrow : MonoBehaviour {

	public GameObject country1;
	public GameObject country2;
	public Dictionary<string, Dictionary<string, long>> data;
	public Dictionary<string, GameObject> map;
	int time;
	int count;

	// Use this for initialization
	void Start () {
		LoadData getData = GetComponent<LoadData>();
		getData.Start();
		data = getData.data;
		time = 0;
		count = 0;
	}

	public void draw (int count) {
		foreach(KeyValuePair<string, Dictionary<string, long>> entry in data)
		{
			GameObject obj = map [entry.Key];
			if (count < entry.Value["2000"]) {
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
			country1.transform.localScale = new Vector3 (1, 1, 1);
			country1.transform.localPosition = new Vector3 (1, -0.21f, -0.41f);
			country2.transform.localScale = new Vector3 (1, 1, 1);
			country2.transform.localPosition = new Vector3 (2, 0, -0.87f);
		}
	}

}
