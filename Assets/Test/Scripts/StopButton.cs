using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Tools.Binders;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Buttons
{
    [RequireComponent(typeof(Button))]
    public class StopButton : UIButtonDataBind
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
            Settings.Invoke(Constants.EventName.OnStopButtonClick);
        }

        [Bind(Constants.EventName.OnIdleStateEnter)]
        private void OnStateChanged(string stateName)
        {
            //if (stateName == Constants.EventName.)
            //_button.interactable = true;
        }
    }
}