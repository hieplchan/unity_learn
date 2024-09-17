using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += moveSpeed * moveDir * Time.deltaTime;
    }
}
