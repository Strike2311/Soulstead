using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Soulstead.Enums;
using System;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Tile Interaction")]
    public Tilemap targetTilemap;
    public Vector2 facingDirection = Vector2.down;
    public float interactionDistance = 0.3f;
    public TileBase dirtTile;
    public TileBase[] grassTiles;

    public FacingDirection CurrentDirection { get; private set; }
    private PlayerMovement playerMovementObject;
    void Start()
    {
        grassTiles = TilemapUtility.LoadTilesFromFolder("GrassTiles");
        playerMovementObject = gameObject.GetComponent<PlayerMovement>();
        SubscribeToEvents();

    }
    void Update()
    {
        HandleTileInteraction();
    }

    void SubscribeToEvents()
    {
        if (playerMovementObject != null)
            playerMovementObject.OnFacingDirectionChanged += SetFacingDirection;
    }

    void SetFacingDirection(Vector2 newFacingDirection)
    {
        facingDirection = newFacingDirection;
    }

    void HandleTileInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3Int tilePos = GetFacingTilePosition();
            TileBase tile = targetTilemap.GetTile(tilePos);

            if (tile != null && grassTiles.Contains(tile))
            {
                /*TileManager tileManager = GameObject.Find("Tile Manager");
                Vector2Int tilePos = tilemap.WorldToCell(worldClickPosition);

                tileManager.SetDug(tilePos, true);
                tilemap.SetTile(tilePos, dugTile);*/
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
