using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D furnitureCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        furnitureCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Beispiel: Möbelstück vor dem Charakter
        if (PlayerIsInFrontOfFurniture())
        {
            // Setze die Rendering Order des Möbelstücks höher als die des Charakters
            spriteRenderer.sortingOrder = 1;
        }
        // Beispiel: Möbelstück hinter dem Charakter
        else
        {
            // Setze die Rendering Order des Möbelstücks niedriger als die des Charakters
            spriteRenderer.sortingOrder = -1;
        }
    }

    bool PlayerIsInFrontOfFurniture()
    {
        if (PlayerController.instance != null)
        {
            float playerBottomY = PlayerController.instance.GetComponent<Collider2D>().bounds.min.y;
            float furnitureTopY = furnitureCollider.bounds.max.y;

            // Überprüfen Sie, ob der Spieler unter dem Möbelstück steht (niedrigere Y-Position)
            return playerBottomY > furnitureTopY;
        }
        else
        {
            return false;
        }
    }
}
