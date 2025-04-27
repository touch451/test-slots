using DanielLochner.Assets.SimpleScrollSnap;
using AxGrid.Base;
using UnityEngine;
using AxGrid;

namespace Scripts
{
    public class LootBox : MonoBehaviourExtBind
    {
        [SerializeField] int speed;
        [SerializeField] private SimpleScrollSnap scroll;

        private string TAG = "[LootBox] ";
        private bool isEnabled = false;
        private int deviceSpeedMultiply = 20;

        [OnStart]
        private void onStart()
        {
            Model.EventManager.AddAction(FSMNames.LootBox.OnSpinEnableChanged, OnSpinEnable);

            if (!Application.isEditor)
                speed *= deviceSpeedMultiply;
        }

        private void OnSpinEnable()
        {
            bool value = Model.GetBool(FSMNames.LootBox.SpinEnable, false);

            if (isEnabled == value)
                return;

            isEnabled = value;

            Debug.Log(TAG + (isEnabled ? "Start Spin" : "Stop Spin"));

            if (!isEnabled)
                scroll.OnPanelSelected.AddListener(OnSpinStopped);
        }

        private void OnSpinStopped(int itemId)
        {
            Debug.Log(TAG + "Spin Stopped. Item id = " + itemId);

            scroll.ScrollRect.StopMovement();
            scroll.OnPanelSelected.RemoveListener(OnSpinStopped);

            Settings.Invoke(FSMNames.LootBox.OnSpinStopped);
        }

        [OnUpdate]
        private void onUpdate()
        {
            if (isEnabled)
            {
                scroll.Velocity += speed * Vector2.down;
            }
        }

        [OnDestroy]
        private void onDestroy()
        {
            Model.EventManager.RemoveAction(FSMNames.LootBox.OnSpinEnableChanged, OnSpinEnable);
            scroll.OnPanelSelected.RemoveListener(OnSpinStopped);
        }
    }
}