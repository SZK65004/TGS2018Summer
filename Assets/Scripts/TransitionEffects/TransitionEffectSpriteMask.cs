using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEffectSpriteMask : MonoBehaviour {

    private TransitionType transitionType;
    private SpriteMask spriteMask;

    public void SetTransitionType(TransitionType transitionType)
    {
        this.transitionType = transitionType;

        string path = "";
        switch (transitionType)
        {
            case TransitionType.Circle:
                path = "Transitions/SpriteMaskCircle";
                break;
            case TransitionType.Line:
                path = "Transitions/SpriteMaskLine";
                break;
        }

        Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;

        GetSpriteMask().sprite = sprite;
    }

    public void SetAlphaCutOff(float alphaCutOff)
    {
        GetSpriteMask().alphaCutoff = Mathf.Clamp01(alphaCutOff);
    }

    private SpriteMask GetSpriteMask()
    {
        return spriteMask ?? (spriteMask = GetComponent<SpriteMask>());
    }
}
