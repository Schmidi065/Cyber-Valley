using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerController Player;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 0.1f;
    [SerializeField] float sizeOfInteractableArea = 0.1f;

    private void Awake()
    {
        Player = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rgbd2d.position + Player.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}


