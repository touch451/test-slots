using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Buttons
{
    [RequireComponent(typeof(Button))]
    public class StartButton : MonoBehaviourExtBind
    {
        private Button _button;

        [OnAwake]
        private void Init()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Settings.Invoke(Constants.EventName.OnStartButtonClick);
        }

        [Bind(Constants.EventName.OnIdleStateEnter)]
        private void OnIdleStateEnter()
        {
            _button.interactable = true;
        }

        [Bind(Constants.EventName.OnIdleStateExit)]
        private void OnIdleStateExit()
        {
            _button.interactable = false;
        }
    }
}