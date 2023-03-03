using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controllers;

namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> layers = new List<Transform>();
        UIPanelController UIPanelController;
        moneyManager moneyManager;

        private List<string> BTNPanelNames = new List<string>()
        {
        "BTN-TrainingPanel",
        "BTN-FightPanel",
        "BTN-PerksPanel",
        "BTN-CraftingPanel"
        };

        private void Start()
        {
            UIPanelController = GameObject.Find("UIPanelController").GetComponent<UIPanelController>();
            moneyManager = GameObject.Find("moneyManager").GetComponent<moneyManager>();
        }

        public void CloseScene()
        {
            UIPanelController.OnClosePanel(0);
        }

        public void OpenScene(string PanelName)
        {
            CloseScene();
            Instantiate(Resources.Load<GameObject>($"Screens/{PanelName}"), layers[0]);
        }

        public void UpgradeModifier()
        {
            moneyManager.multiplier += 1;
        }

        #region Coloring Clicked Buttons

        //to be used on the editors side
        public void ColorForPressedButton(string PanelName)
        {
            ColorButton(PanelName);
            UnColorOldButton(PanelName);
        }

        private void ColorButton(string PanelName)
        {
            GameObject.Find(PanelName).GetComponent<Image>().color = Color.red;
        }

        private void UnColorOldButton(string excludedPanel)
        {
            foreach (string item in BTNPanelNames)
            {
                if (item != excludedPanel)
                {
                    GameObject.Find(item).GetComponent<Image>().color = Color.white;
                }
            }
        }

        #endregion
    }
}