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

    public FacingDirection CurrentDirection { get; private set; }
    private PlayerMovement playerMovementObject;
    public GameObject inventoryUI;
    void Start()
    {
        playerMovementObject = gameObject.GetComponent<PlayerMovement>();
        SubscribeToEvents();

    }
    void Update()
    {
        HandleUserKeypresses();
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

    void HandleUserKeypresses()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3Int tilePos = GetFacingTilePosition();
            TileBase tile = targetTilemap.GetTile(tilePos);

            if (tile != null)
            {
                targetTilemap.SetTile(tilePos, null);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(true);
        }
    }
    Vector3Int GetFacingTilePosition()
    {
        Vector3 playerPos = transform.position;
        Vector3 facingWorldPos = playerPos + (Vector3)facingDirection * interactionDistance;

        return targetTilemap.WorldToCell(facingWorldPos);
    }
}
