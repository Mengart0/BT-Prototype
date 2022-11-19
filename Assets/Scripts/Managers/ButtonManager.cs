using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private List<Transform> layers = new List<Transform>();
    UIPanelController UIPanelController;

    private void Start()
    {
        UIPanelController = GameObject.Find("UIPanelController").GetComponent<UIPanelController>();
    }

    public void CloseScene()
    {
        UIPanelController.OnClosePanel(0);
    }

    public void OpenScene(string SceneName)
    {
        CloseScene();
        Instantiate(Resources.Load<GameObject>($"Screens/{SceneName}Panel"), layers[0]);
    }
     
}
