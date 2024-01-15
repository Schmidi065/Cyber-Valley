using UnityEngine;

public class TeleportationZone : MonoBehaviour
{
    // Die Zielposition, zu der der Spieler teleportiert werden soll
    public Vector2 targetPosition;

    // Wird aufgerufen, wenn ein Collider mit dem Teleportationsbereich in Berührung kommt
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfe, ob der Kollisionspartner der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Setze die Rigidbody2D-Komponente des Spielers auf eine vorübergehende kinematische Einstellung,
            // um ihn zu teleportieren, ohne dass er durch die Schwerkraft beeinflusst wird
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            bool wasKinematic = playerRb.isKinematic;
            playerRb.isKinematic = true;

            // Teleportiere den Spieler zur Zielposition
            other.transform.position = targetPosition;

            // Stelle die kinematische Einstellung wieder her
            playerRb.isKinematic = wasKinematic;
        }
    }
}
