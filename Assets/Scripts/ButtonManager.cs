using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private List<Transform> layers = new List<Transform>();

    public void OpenCraftingScene()
    {
        Instantiate(Resources.Load<GameObject>($"Screens/CraftingPanel"), layers[0]);
    }
    public void OpenFightScene()
    {
        Instantiate(Resources.Load<GameObject>($"Screens/FightPanel"), layers[0]);
    }
    public void OpenPerksScene()
    {
        Instantiate(Resources.Load<GameObject>($"Screens/PerksPanel"), layers[0]);
    }
    public void OpenTrainingScene()
    {
        Instantiate(Resources.Load<GameObject>($"Screens/TrainingPanel"), layers[0]);
    }


}
