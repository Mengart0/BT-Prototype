using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class gameManager : MonoBehaviour
{
    public double money;
    public double power;
    public int multiplier = 1;

    public void Update()
    {
        money += 1 * multiplier;
        power += 1 * multiplier;
    }

    private void FixedUpdate()
    {
        WriteAbbrevate();
    }

    private void WriteAbbrevate()
    { 
        try
        {
            GameObject.Find("TXT-Money").GetComponent<TMP_Text>().text = FormatNumber(money);
            GameObject.Find("TXT-Power").GetComponent<TMP_Text>().text = FormatNumber(power);
        }
        catch (System.Exception)
        {  }
    }

    private static readonly int charA = Convert.ToInt32('a');

    private static readonly Dictionary<int, string> units = new Dictionary<int, string>
    {
        {0, ""},
        {1, "K"},
        {2, "M"},
        {3, "B"},
        {4, "T"},
        {5, "q"},
        {6, "Q"}
    };

    public static string FormatNumber(double value)
    {
        if (value < 1d)
        {
            return "0";
        }

        var n = (int)Math.Log(value, 1000);
        var m = value / Math.Pow(1000, n);
        var unit = "";

        if (n < units.Count)
        {
            unit = units[n];
        }
        else
        {
            var unitInt = n - units.Count;
            var secondUnit = unitInt % 26;
            var firstUnit = unitInt / 26;
            unit = Convert.ToChar(firstUnit + charA).ToString() + Convert.ToChar(secondUnit + charA).ToString();
        }

        // Math.Floor(m * 100) / 100) fixes rounding errors
        return (Math.Floor(m * 100) / 100).ToString("0.##") + unit;
    }
}
