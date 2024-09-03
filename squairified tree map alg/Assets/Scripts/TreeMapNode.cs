using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the individual nodes within the tree map
/// Each node has an area and a rectangle that defines 
/// the position and size within the tree map
/// </summary>
public class TreeMapNode
{
    // Node area (Weighting/percentage of the node)
    public float Area;

    //Visual representation of the nodes position and size
    public Rect Rectangle;

    public TreeMapNode(float NodeArea)
    {
        Area = NodeArea;
    }
    
}
