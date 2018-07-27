using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State<T> : MonoBehaviour {

	public State(T id)
    {
        this.Id = id;
    }

    public T Id { get; private set; }

    public Action SetUpAction { private get; set; }

    public Action UpdateAction { private get; set; }

    public Action CleanUpAction { private get; set; }

    public void SetUp()
    {
        if (SetUpAction != null)
        {
            SetUpAction.Invoke();
        }
    }

    public void Update()
    {
        if (UpdateAction != null)
        {
            UpdateAction.Invoke();
        }
    }

    public void CleanUp()
    {
        if (CleanUpAction != null)
        {
            CleanUpAction.Invoke();
        }
    }
}
