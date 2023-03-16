using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Controller_Rumble : MonoBehaviour
{
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 30)
        {
            GamePad.SetVibration(playerIndex, 0.8f - Vector3.Distance(transform.position, player.position) / 30, 0.8f - Vector3.Distance(transform.position, player.position) / 30);
        }

        if (Vector3.Distance(transform.position, player.position) > 30)
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }


    }
}
