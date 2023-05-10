using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GidManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    void Awake()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; x < gridSize.y; y++)
            {
                Vector2Int coordinate = new Vector2Int(x, y);
                grid.Add(coordinate, new Node(coordinate, true));
                Debug.Log(grid[coordinate].coordinates + "-" + grid[coordinate].isWalkable);
            }
        }
    }
}
