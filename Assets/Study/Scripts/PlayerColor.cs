using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerColor : NetworkBehaviour
{
    public MeshRenderer MeshRenderer;
    
    [Networked(OnChanged = nameof(NetworkColorChanged))]
    public Color NetworkedColor { get; set; }

    private void Awake()
    {
        MeshRenderer = transform.Find("Interpolation Target").GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 여기에서 색을 직접 바꾸는 것은 작동하지 않습니다. 이 코드는 클라이언트가 버튼을 누를 때만 실행되고 모든 클라이언트에서 실행되지 않기 때문입니다.
            NetworkedColor =  new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }
    
    private static void NetworkColorChanged(Changed<PlayerColor> changed)
    {
        changed.Behaviour.MeshRenderer.material.color = changed.Behaviour.NetworkedColor;
    }
}
