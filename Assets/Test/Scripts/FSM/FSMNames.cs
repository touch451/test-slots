public static class FSMNames
{
    public class States
    {
        public const string OnIdleStateEnter = "OnIdleStateEnter";
        public const string OnSpinningStateEnter = "OnSpinningStateEnter";
        public const string OnStoppingStateEnter = "OnStoppingStateEnter";
        public const string OnResultStateEnter = "OnResultStateEnter";

        public const string OnIdleStateExit = "OnIdleStateExit";
        public const string OnSpinningStateExit = "OnSpinningStateExit";
        public const string OnStoppingStateExit = "OnStoppingStateExit";
        public const string OnResultStateExit = "OnResultStateExit";
    }

    public class Buttons
    {
        public const string OnStartButtonClick = "OnStartButtonClick";
        public const string OnStartButtonEnableChanged = "OnStartButtonEnableChanged";
        public const string StartButtonEnable = "BtnStartButtonEnable";

        public const string OnStopButtonClick = "OnStopButtonClick";
        public const string OnStopButtonEnableChanged = "OnStopButtonEnableChanged";
        public const string StopButtonEnable = "BtnStopButtonEnable";
    }

    public class LootBox
    {
        public const string SpinEnable = "SpinEnable";
        public const string OnSpinEnableChanged = "OnSpinEnableChanged";
        public const string OnSpinStopped = "OnSpinStopped";
    }
}
