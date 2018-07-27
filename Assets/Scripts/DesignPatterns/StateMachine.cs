using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : MonoBehaviour {

    private Dictionary<T, State<T>> stateList = new Dictionary<T, State<T>>();

    public State<T> CurrentState { get; private set; }
    
    protected void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    protected void GoToState(T nextStateId)
    {
        if (!stateList.ContainsKey(nextStateId))
        {
            Debug.Log("ステートリストにないステートへ移行しようとしました。");
            return;
        }

        if (CurrentState != null)
        {
            CurrentState.CleanUp();
        }

        CurrentState = stateList[nextStateId];
        CurrentState.SetUp();
    }

    protected void AddState(State<T> state)
    {
        var stateId = state.Id;

        if (stateList.ContainsKey(stateId))
        {
            Debug.Log("ステートリストにすでに存在しているステートを登録しようとしました。");
            return;
        }

        stateList.Add(stateId, state);
    }
}
