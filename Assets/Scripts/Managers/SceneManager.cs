using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class SceneManager : MonoBehaviour //Adds events to the different buttons when one of the scenes is loaded
    {
        public Button TSbtn;
        public ButtonManager btnManager;

        private void OnEnable() //added to the different scenes while on editor so on awake it adds events to the buttons
        {
            switch (transform.parent.name)
            {
                case ("TrainingPanel(Clone)"):
                    //Upgrade Button
                    TSbtn = GameObject.Find("BTN-Upgrade").GetComponent<Button>();
                    btnManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();

                    TSbtn.onClick.AddListener(() => { btnManager.UpgradeModifier(); });

                    break;

                case ("FightPanel(Clone)"):

                    break;

                default:
                    break;
            }
        }
    }
}