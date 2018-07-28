using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConttoller : MonoBehaviour {

    static bool charge1p = false;
    static bool charge2p = false;

    public static bool Charge(int player)
    {
        if(player ==1 )
        {
            charge1p = true;
        }
        else if(player == 2)
        {
            charge2p = true;
        }

        return Input.GetKey(KeyCode.Space);
    }

    public static bool Release(int player)
    {
        if (player == 1 && charge1p)
        {
            charge1p = false;
            return Input.GetKeyUp(KeyCode.Space);
        }
        else if (player == 2 && charge2p)
        {
            charge2p = false;
            return Input.GetKeyUp(KeyCode.Space);
        }
        return false;
    }
}
