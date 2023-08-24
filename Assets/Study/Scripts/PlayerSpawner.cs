using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

/// <summary>
/// IPlayerJoined에는 PlayerJoined(PlayerRef player)가 있음.
/// </summary>
public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            // player에게 input 권한을 준다.
            Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity, player);
        }
    }
}
