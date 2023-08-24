using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public struct PlayerInputs : INetworkStruct
{
    // 플레이어의 모든 인풋들은 여기에 추가해주세요.
    public Vector2 dir;
    public bool jump;
    public bool hammering;
    public bool throwhammer;
}

public struct CombinedPlayerInputs : INetworkInput
{
    // 플레이어의 수를 정의합니다.
    public PlayerInputs PlayerA;
    public PlayerInputs PlayerB;
    public PlayerInputs PlayerC;
    public PlayerInputs PlayerD;
    
    // 플레이어 구조에 쉽게 접근하기 위한 인덱서 예시입니다.
    public PlayerInputs this[int i]
    {
        get
        {
            switch (i)
            {
                case 0: return PlayerA;
                case 1: return PlayerB;
                case 2: return PlayerC;
                case 3: return PlayerD;
                default: return default;
            }
        }

        set
        {
            switch (i)
            {
                case 0: PlayerA = value;
                    return;
                case 1: PlayerB = value;
                    return;
                case 2: PlayerC = value;
                    return;
                case 3: PlayerD = value;
                    return;
                default:
                    return;
            }
        }
    }
}
