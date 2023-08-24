using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [Networked(OnChanged = nameof(NetworkedHealthChanged))]
    public float NetworkedHealth { get; set; } = 100f;
    
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void DealDamageRpc(float damage)
    {
        // 여기에 있는 코드는 이 객체를 소유한 클라이언트에서 실행됩니다. (상태와 입력 권한이 있는)
        // 즉, RpcTarget의 클라이언트에서 실행됩니다.
        Debug.Log("Received DealDamageRpc on StateAuthority, modifying Networked variable");
        NetworkedHealth -= damage;
    }
    
    private static void NetworkedHealthChanged(Changed<Health> changed)
    {
        // 여기에서 플레이어의 체력바를 업데이트하는 코드를 추가하면 됩니다.
        Debug.Log($"Health changed to: {changed.Behaviour.NetworkedHealth}");
    }
}
