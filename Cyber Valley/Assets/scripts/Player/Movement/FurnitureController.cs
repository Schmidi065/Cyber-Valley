using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        // Holen Sie die Y-Positionen von Spieler und Möbelstück
        float playerY = PlayerController.instance.transform.position.y;
        float furnitureY = transform.position.y;

        // Überprüfen Sie, ob der Spieler vor dem Möbelstück steht (höhere Y-Position)
        return playerY > furnitureY;
    }
}