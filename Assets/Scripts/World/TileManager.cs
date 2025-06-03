using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private Dictionary<Vector2Int, TileState> tileStates = new Dictionary<Vector2Int, TileState>();

    public TileState GetTileState(Vector2Int position)
    {
        if (!tileStates.ContainsKey(position))
            tileStates[position] = new TileState();

        return tileStates[position];
    }

    public void SetDug(Vector2Int position, bool dug)
    {
        GetTileState(position).isDug = dug;
    }

    public bool IsDug(Vector2Int position)
    {
        return GetTileState(position).isDug;
    }

}
