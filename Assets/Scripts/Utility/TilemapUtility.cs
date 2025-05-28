using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapUtility
{
    public static TileBase[] LoadTilesFromFolder(string folderName)
    {
        TileBase[] tiles = Resources.LoadAll<TileBase>("TileMap/" + folderName);

        return tiles;
    }
}
