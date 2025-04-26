using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace Scripts.Fsm
{
    public class FsmController : MonoBehaviourExtBind
    {
        private readonly string TAG = "[FSM] Main: ";

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

        [Bind(Constants.EventName.OnStartButtonClick)]
        private void OnStartButtonClick()
        {
            Debug.Log(TAG + "On Start Button Click");
            GoToSpinningState();
        }

        [Bind(Constants.EventName.OnStopButtonClick)]
        private void OnStopButtonClick()
        {
            Debug.Log(TAG + "On Stop Button Click");
        }

        private void GoToIdleState()
        {
            Debug.Log(TAG + "Go To Idle State");
            Settings.Fsm.Change(IdleStateName);
        }

        private void GoToSpinningState()
        {
            Debug.Log(TAG + "Go To Spinning State");
            Settings.Fsm.Change(SpinningStateName);
        }

        private void GoToStoppingState()
        {
            Debug.Log(TAG + "Go To Stopping State");
            Settings.Fsm.Change(StoppingStateName);
        }

        private void GoToResultState()
        {
            Debug.Log(TAG + "Go To Result State");
            Settings.Fsm.Change(ResultStateName);
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
            Settings.Invoke(Constants.EventName.OnIdleStateEnter);
        }

        [Exit]
        private void Exit()
        {
            Debug.Log(TAG + "Exit");
            Settings.Invoke(Constants.EventName.OnIdleStateExit);
        }
    }

    [State(nameof(SpinningState))]
    public class SpinningState : FSMState
    {
        private readonly string TAG = "[FSM] Spinning State: ";

        [Enter]
        private void Enter() => Debug.Log(TAG + "Enter");

        [Exit]
        private void Exit() => Debug.Log(TAG + "Exit");
    }

    [State(nameof(StoppingState))]
    public class StoppingState : FSMState
    {
        private readonly string TAG = "[FSM] Stopping State: ";

        [Enter]
        private void Enter() => Debug.Log(TAG + "Enter");

        [Exit]
        private void Exit() => Debug.Log(TAG + "Exit");
    }

    [State(nameof(ResultState))]
    public class ResultState : FSMState
    {
        private readonly string TAG = "[FSM] Result State: ";

        [Enter]
        private void Enter() => Debug.Log(TAG + "Enter");

        [Exit]
        private void Exit() => Debug.Log(TAG + "Exit");
    }
}