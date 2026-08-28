using UnityEngine;
using System.Collections.Generic;
using System;

public class GridData
{
    // Creates data for placed items
    Dictionary<Vector3Int, PlacementData> placedItems = new Dictionary<Vector3Int, PlacementData>();

    // Adds item at a certain position on the grid
    public void AddItemAt(Vector3Int gridPosition, Vector2Int itemSize, int ID, int placedItemIndex)
    {
        // Calculates grid and item size
        List<Vector3Int> positionTaken = CalculatePositions(gridPosition, itemSize);

        PlacementData data = new PlacementData(positionTaken, ID, placedItemIndex);

        // Loops through Dictionary to check if an item occupies a cell position
        foreach (var pos in positionTaken)
        {
            if(placedItems.ContainsKey(pos))
            
                throw new Exception($"Dictionary already contains this cell position {pos}");
                // Assigns grid position to an item
                placedItems[pos] = data;
            
        }
    }

    // Creates a method for Calculate positions
    private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int itemSize)
    {
        // Returns values of list
        List<Vector3Int> returnVal = new();

        // Gets offset x distance for item
        for(int x = 0; x < itemSize.x; x++)
        {
            // Gets offset y distance for item
            for (int y = 0; y < itemSize.y; y++)
            {
                returnVal.Add(gridPosition + new Vector3Int(x, 0, y));
            }
        }
        // Returns values
        return returnVal;
    }

    // Checks if an item can be placed on an unoccupied position
    public bool CanPlaceItemAt(Vector3Int gridPosition, Vector2Int itemSize)
    {
        // Calculates grid position and item size
        List<Vector3Int> positionTaken = CalculatePositions(gridPosition, itemSize);
        foreach(var pos in positionTaken)
        {
            // If there are placed items on the positions in the dictionary, return false
            if (placedItems.ContainsKey(pos))
 
                return false;
        }
        // Return true if there are no placed items on dictionary positions
        return true;
    }

    // Defines PlacementData
    public class PlacementData
    {
        // Positions occupied by an item
        public List<Vector3Int> takenPositions;

        // Saves data of item
        public int ID { get; set; }

        // Used to remove items
        public int PlacedItemIndex { get; private set; }

        // Creates a constructor for PlacementData
        public PlacementData(List<Vector3Int> takenPositions, int iD, int placedItemIndex)
        {
            // Assigns values to fields above
            this.takenPositions = takenPositions;
            ID = iD;
            PlacedItemIndex = placedItemIndex;
        }
    }
}
