using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Tile Interaction")]
    public Tilemap targetTilemap;
    public Vector2 facingDirection = Vector2.down;
    public float interactionDistance = 1f;
    public TileBase dirtTile;
    public TileBase[] grassTiles;

    void Update()
    {
        HandleTileInteraction();
    }

    void HandleTileInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3Int tilePos = GetFacingTilePosition();
            TileBase tile = targetTilemap.GetTile(tilePos);

            if (tile != null && grassTiles.Contains(tile))
            {
                targetTilemap.SetTile(tilePos, dirtTile);
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
