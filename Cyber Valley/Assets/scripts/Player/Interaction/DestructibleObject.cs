using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceDropData
{
    public GameObject resourcePrefab;
    public int dropCount;
}

public class DestructibleObject : ToolHit
{
    [SerializeField] List<ResourceDropData> resourceDrops;
    [SerializeField] float spread = 0.7f;

    public override void Hit()
    {
        GameObject resourceContainer = new GameObject("ResourceContainer");

        foreach (var resourceDropData in resourceDrops)
        {
            for (int i = 0; i < resourceDropData.dropCount; i++)
            {
                Vector2 randomOffset = spread * UnityEngine.Random.insideUnitCircle;
                Vector3 position = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

                GameObject resourceDrop = Instantiate(resourceDropData.resourcePrefab, position, Quaternion.identity);
                resourceDrop.transform.parent = resourceContainer.transform;
            }
        }

        Destroy(gameObject);
    }
}
