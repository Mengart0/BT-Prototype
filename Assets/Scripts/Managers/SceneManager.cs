using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class SceneManager : MonoBehaviour //Adds events to the different buttons when one of the scenes is loaded
    {
        public Button btn;
        public ButtonManager btnManager;

        private void OnEnable()
        {
            #region Training Scene

            //Upgrade Button
            btn = GameObject.Find("BTN-Upgrade").GetComponent<Button>();
            btnManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();

            btn.onClick.AddListener(() => { btnManager.UpgradeModifier(); });

            #endregion
        }

    }
}