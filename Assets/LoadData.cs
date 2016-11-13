using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class LoadData : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        string path = @"data\API_SP.POP.TOTL_DS2_en_csv_v2.csv"; // population
        string csv = File.ReadAllText(path);

        Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();
        string[] lines = csv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        string[] yearsLine = lines[4].Split(',');
        string[] years = new string[yearsLine.Length - 4];

        for (int i = 0; i < years.Length; i++)
        {
            years[i] = yearsLine[i + 4];
        }

        // country-values start on the fifth row
        for (int i = 5; i < lines.Length; i++)
        {
            string[] values = lines[i].Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string country = values[0];
            data[country] = new Dictionary<string, string>();

            // statistic-values start on the fifth column
            for (int j = 0; j < values.Length - 5; j++)
            {
                string year = years[j];
                string value = values[j + 4];
                data[country][year] = value;

            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
