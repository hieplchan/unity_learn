using System.Collections;
using System.Collections.Generic;
using Harvestable;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += moveSpeed * moveDir * Time.deltaTime;
        transform.LookAt(moveDir.normalized + transform.position);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Harvest();
        }
    }

    void Harvest()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (var hit in hitColliders)
        {
            var node = hit.GetComponent<BaseNode>();
            if (node == null) continue;
            var (baseResource, specialResource) = node.Gather();
            Debug.Log($"Havest baseResource: {baseResource.Amount} {baseResource.ResourceType} - " +
                      $"specialResource: {specialResource.Amount} {specialResource.ResourceType}");
        }
    }
}
