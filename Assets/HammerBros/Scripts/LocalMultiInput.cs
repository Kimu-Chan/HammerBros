using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class LocalMultiInput : NetworkBehaviour
{
    // Player index 0-3, indicating which of the 4 players
    // on the associated peer controls this object.
    private int _playerIndex;

    public override void FixedUpdateNetwork()
    {
        if (GetInput<CombinedPlayerInputs>(out var input))
        {
            var dir = input[_playerIndex].dir;
            // Convert joystick direction into player heading
            float heading = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, heading - 90, 0f);
        }
    }
}
