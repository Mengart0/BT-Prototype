using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private List<Transform> layers = new List<Transform>();
    UIPanelController UIPanelController;

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

    public void ColorForPressedButton(string PanelName)
    {
        ColorButton(PanelName);
        UnColorExButton(PanelName);
    }

    private void ColorButton(string PanelName)
    {
        GameObject.Find(PanelName).GetComponent<Image>().color = Color.red;
    }

    private void UnColorExButton(string excludedPanel)
    {
        foreach (string item in BTNPanelNames)
        {
            if (item != excludedPanel)
            {
                GameObject.Find(item).GetComponent<Image>().color = Color.white;
            }
        }
    }

}
