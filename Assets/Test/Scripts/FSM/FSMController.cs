using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace Scripts
{
    public class FSMController : MonoBehaviourExtBind
    {
        private readonly string TAG = "[FSM] Controller: ";

        private readonly string IdleStateName = nameof(IdleState);
        private readonly string SpinningStateName = nameof(SpinningState);
        private readonly string StoppingStateName = nameof(StoppingState);
        private readonly string ResultStateName = nameof(ResultState);

        [OnAwake]
        private void CreateFsm()
        {
            Debug.Log(TAG + "Create");
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new IdleState());
            Settings.Fsm.Add(new SpinningState());
            Settings.Fsm.Add(new StoppingState());
            Settings.Fsm.Add(new ResultState());
        }

        [OnStart]
        private void StartFsm()
        {
            Debug.Log(TAG + "Start");
            Settings.Fsm.Start(IdleStateName);
        }

        [OnUpdate]
        private void UpdateFsm()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }

        [Bind(FSMNames.Buttons.OnStartButtonClick)]
        private void OnStartButtonClick()
        {
            Debug.Log(TAG + "On Start Button Click");
            GoToState(SpinningStateName);
        }

        [Bind(FSMNames.Buttons.OnStopButtonClick)]
        private void OnStopButtonClick()
        {
            Debug.Log(TAG + "On Stop Button Click");
            GoToState(StoppingStateName);
        }

        [Bind(FSMNames.LootBox.OnSpinStopped)]
        private void OnSpinStopped()
        {
            GoToState(ResultStateName);
        }

        [Bind(FSMNames.States.OnResultStateEnter)]
        private void OnResultStateEnter()
        {
            GoToState(IdleStateName);
        }

        private void GoToState(string stateName)
        {
            Debug.Log(TAG + "Go To State -> " + stateName);
            Settings.Fsm.Change(stateName);
        }
    }

    [State(nameof(IdleState))]
    public class IdleState : FSMState
    {
        private readonly string TAG = "[FSM] Idle State: ";

        [Enter]
        private void Enter()
        {
            Debug.Log(TAG + "Enter");

            Debug.Log(TAG + "Set Enabled Start Button");
            Model.Set(FSMNames.Buttons.StartButtonEnable, true);
        }

        [Exit]
        private void Exit()
        {
            Debug.Log(TAG + "Exit");

            Debug.Log(TAG + "Set Disabled Start Button");
            Model.Set(FSMNames.Buttons.StartButtonEnable, false);
        }
    }

    [State(nameof(SpinningState))]
    public class SpinningState : FSMState
    {
        private readonly string TAG = "[FSM] Spinning State: ";

        [Enter]
        private void Enter()
        {
            Debug.Log(TAG + "Enter");

            Debug.Log(TAG + "Set Enabled LootBox Spin");
            Model.Set(FSMNames.LootBox.SpinEnable, true);
        }

        [One(3.0f)]
        private void SetEnabledStopButton()
        {
            Debug.Log(TAG + "Set Enabled Stop Button");
            Model.Set(FSMNames.Buttons.StopButtonEnable, true);
        }

        [Exit]
        private void Exit()
        {
            Debug.Log(TAG + "Exit");

            Debug.Log(TAG + "Set Disabled Stop Button");
            Model.Set(FSMNames.Buttons.StopButtonEnable, false);
        }
    }

    [State(nameof(StoppingState))]
    public class StoppingState : FSMState
    {
        private readonly string TAG = "[FSM] Stopping State: ";

        [Enter]
        private void Enter()
        {
            Debug.Log(TAG + "Enter");

            Debug.Log(TAG + "Set Disabled LootBox Spin");
            Model.Set(FSMNames.LootBox.SpinEnable, false);
        }

        [Exit]
        private void Exit()
        {
            Debug.Log(TAG + "Exit");
        }
    }

    [State(nameof(ResultState))]
    public class ResultState : FSMState
    {
        private readonly string TAG = "[FSM] Result State: ";

        [Enter]
        private void Enter()
        {
            Debug.Log(TAG + "Enter");
            Settings.Invoke(FSMNames.States.OnResultStateEnter);
        }

        [Exit]
        private void Exit()
        {
            Debug.Log(TAG + "Exit");
        }
    }
}