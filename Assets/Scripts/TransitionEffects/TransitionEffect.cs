using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEffect : StateMachine<TransitionEffectState> {

    private const float ALPHA_CUTOFF_MAX = 1.0f;
    private const float ALPHA_CUTOFF_MIN = 0.0f;

    public float transitionDuration = 1.0f;
    public TransitionEffectSpriteMask transitionEffectSpriteMask;

    private float transitionProgress;

    private void Awake()
    {
        InitializeStateMachine();
        Debug.Log("fgafae");
    }

    private void InitializeStateMachine()
    {
        {
            var state = new State<TransitionEffectState>(TransitionEffectState.FadeIn);
            state.SetUpAction = OnSetUpFadeIn;
            state.UpdateAction = OnUpdateFadeIn;
            state.CleanUpAction = OnCleanUpFadeIn;
            AddState(state);
        }

        {
            var state = new State<TransitionEffectState>(TransitionEffectState.Idle);
            AddState(state);
        }

        {
            var state = new State<TransitionEffectState>(TransitionEffectState.FadeOut);
            state.SetUpAction = OnSetUpFadeOut;
            state.UpdateAction = OnUpdateFadeOut;
            AddState(state);
        }
    }

    public bool IsComplete()
    {
        return transitionProgress >= transitionDuration;
    }

    public void ExecuteFadeIn()
    {
        GoToState(TransitionEffectState.FadeIn);
    }

    public void ExecuteFadeOut()
    {
        GoToState(TransitionEffectState.FadeOut);
    }

    private void OnSetUpFadeIn()
    {
        transitionEffectSpriteMask.SetAlphaCutOff(ALPHA_CUTOFF_MIN);
        transitionProgress = 0.0f;
    }

    private void OnUpdateFadeIn()
    {
        transitionProgress += Time.deltaTime;
        transitionEffectSpriteMask.SetAlphaCutOff(ALPHA_CUTOFF_MAX * transitionProgress / transitionDuration);

        if (IsComplete())
        {
            GoToState(TransitionEffectState.Idle);
        }
    }

    private void OnCleanUpFadeIn()
    {
        transitionEffectSpriteMask.SetAlphaCutOff(ALPHA_CUTOFF_MAX);
    }

    private void OnSetUpFadeOut()
    {
        transitionEffectSpriteMask.SetAlphaCutOff(ALPHA_CUTOFF_MAX);
        transitionProgress = 0.0f;
    }

    private void OnUpdateFadeOut()
    {
        transitionProgress += Time.deltaTime;
        transitionEffectSpriteMask.SetAlphaCutOff(ALPHA_CUTOFF_MAX - ALPHA_CUTOFF_MAX * transitionProgress / transitionDuration);
    }
}
