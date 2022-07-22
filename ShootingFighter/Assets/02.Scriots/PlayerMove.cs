using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Transform _tr;

    private void Awake()
    {
        _tr = transform;
    }
    private void FixedUpdate()
    {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        Vector3 deltaMove = dir * _moveSpeed * Time.fixedDeltaTime;

        _tr.Translate(deltaMove);

    }
}
