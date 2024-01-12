using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    private Transform playerTransform;
    private SpriteRenderer furnitureRenderer;
    private SpriteRenderer playerRenderer;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        furnitureRenderer = GetComponent<SpriteRenderer>();
        playerRenderer = playerTransform.GetComponent<SpriteRenderer>();

        if (playerRenderer == null || furnitureRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on Player or Furniture.");
        }
    }

    private void Update()
    {
        if (playerTransform.position.y < transform.position.y)
        {
            // Spieler ist unter dem Möbel, also setze den Spieler über das Möbel
            playerRenderer.sortingOrder = furnitureRenderer.sortingOrder + 1;
        }
        else
        {
            // Spieler ist über dem Möbel, setze den Spieler unter das Möbel
            playerRenderer.sortingOrder = furnitureRenderer.sortingOrder - 1;
        }
    }
}
