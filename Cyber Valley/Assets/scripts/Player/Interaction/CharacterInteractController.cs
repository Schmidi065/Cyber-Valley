using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Player player;
    [SerializeReference] HighlightController highlightController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

   private void Update()
    {
        check();

        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void check()
    {
        Vector2 position = rgbd2d.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }
        
        highlightController.Hide();


    }

    private void Interact()
    {
        Vector2 position = rgbd2d.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(player);
                break;
            }
        }
    }
}
