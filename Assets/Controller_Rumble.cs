using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Controller_Rumble : MonoBehaviour
{
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            GamePad.SetVibration(playerIndex, 0.4f, 0.4f);
        }

        if (Input.GetKeyDown("joystick button 1"))
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }


    }
}
