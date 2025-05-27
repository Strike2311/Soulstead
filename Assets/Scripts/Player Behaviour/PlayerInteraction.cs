using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteraction : MonoBehaviour
{
    public Tilemap targetTilemap; // Assign in Inspector
    public KeyCode interactionKey = KeyCode.E;
    public Vector2 facingDirection = Vector2.down; // Could change based on player movement
    public float interactionDistance = 1f;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            Vector3Int tilePos = GetFacingTilePosition();
            TileBase tile = targetTilemap.GetTile(tilePos);

            if (tile != null)
            {
                Debug.Log("Interacted with tile: " + tile.name);
                // Add logic here: remove tile, trigger event, change sprite, etc.
            }
        }
    }

    Vector3Int GetFacingTilePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 facingWorldPos = playerPos + (Vector3)facingDirection * interactionDistance;

        return targetTilemap.WorldToCell(facingWorldPos);
    }
}
