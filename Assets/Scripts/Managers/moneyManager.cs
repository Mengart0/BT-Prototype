using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Managers
{
    public class moneyManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public double money;
        public double power;
        public int moneyMultiplier = 1;
        public int powerMultiplier = 1;

        #endregion

        #region Private Variables

        private static readonly int charA = Convert.ToInt32('a');
        private static readonly Dictionary<int, string> units = new Dictionary<int, string> //Dictionary for the Abbrevations
    {
        {0, ""},
        {1, "K"},
        {2, "M"},
        {3, "B"},
        {4, "T"},
        {5, "q"},
        {6, "Q"}
    };

        #endregion

        #endregion

        private void Awake()
        {
            StartCoroutine(IncreaseMoney());
        }

        public void Update()
        {
            power += 1 * powerMultiplier;
        }

        private void FixedUpdate()
        {
            WriteAbbrevate();
        }

        IEnumerator IncreaseMoney()
        {
            while (true)
            {
                money += 1 * moneyMultiplier;
                yield return new WaitForSeconds(1);
            }
        }

        private void WriteAbbrevate()
        {
            try
            {
                GameObject.Find("TXT-Money").GetComponent<TMP_Text>().text = FormatNumber(money);
                GameObject.Find("TXT-Power").GetComponent<TMP_Text>().text = FormatNumber(power);
            }
            catch (System.Exception) { }
        }

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

            return (Math.Floor(m * 100) / 100).ToString("0.##") + unit; //fixes rounding errors and returns
        }
    }
}