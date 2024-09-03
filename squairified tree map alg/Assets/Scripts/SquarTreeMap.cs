using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Manages generation and placement of UI Rect to visually
/// represent the treemap
/// </summary>
public class SquarTreeMap : MonoBehaviour
{


    //private void Start()
    //{
    //    //create a list of predifined nodes/rectangles for the treemap
    //    List<TreeMapNode> TreeNodes = new List<TreeNode>
    //    {
    //        new TreeNode(15), //rectangle with 15% area of overall rectangle
    //        new TreeNode(38), //rectangle with 38% area of overall rectangle
    //        new TreeNode(5), //rectangle with 5% area of overall rectangle
    //        new TreeNode(65), //rectangle with 65% area of overall rectangle
    //        new TreeNode(49) //rectangle with 49% area of overall rectangle
    //    };

    //    Rect initRect = new Rect(0, 0, 1920, 1080); //define the large/initial rectangle

    //    Squareify(treeNodes, initRect); //call method to apply squarified treemap algorythm
    //}

    //private void Squareify(List<TreeNode> nodes, Rect rect) //apply squarified treemap algorythm
    //{
    //    if (nodes.Count == 0) return; //if there are no nodes defined, just return

    //    float totalArea = 0;

    //    foreach (var node in nodes) //add the area of all nodes together
    //    {
    //        totalArea += node.Area;
    //    }

    //    float currentX = rect.x; //this is the x position of large rectangle
    //    float currentY = rect.y; //this is the y position of the large rectangle
    //    float currentWidth = rect.width; //the width of large rectangle
    //    float currentHeight = rect.height; //the height of large rectangle

    //    foreach (var node in nodes) //loop through nodes, calculate size and instantiate
    //    {
    //        //calculate the width of each node based on its area
    //        float nodeWidth = (node.area / totalArea) * currentWidth; //width of node
    //        node.rectangle = new Rect(currentX, currentY, nodeWidth, currentHeight); //set nodes rectangle to calculated size
    //        currentX += nodeWidth; //increase x position to prevent overlap

    //        //create a UI panel that will visualise the node
    //        GameObject nodePanel = new GameObject("NodePanel"); //create a new GO
    //        nodePanel.transform.SetParent(this.transform); //Set nodePanel as child of canvas
    //        RectTransform rectTransform = nodePanel.AddComponent<RectTransform>(); //add rect transform component to newly created GO
    //        rectTransform.anchorMin = new Vector2(0, 0); //set rect transform Min anchor position
    //        rectTransform.anchorMax = new Vector2(0, 0); //set rect transform Max anchor position
    //        rectTransform.pivot = new Vector2(0, 0); //set Pivot to centre
    //        rectTransform.anchoredPosition = new Vector2(node.Rectangle.x, node.Rectangle.y); //set anchor position relative to pivot 
    //        rectTransform.sizeDelta = new Vector2(node.Rectangle.width, node.Rectangle.height); // size of the rectangle relative to anchor

    //        //add an image and colour to the panel for visualisation
    //        Image image = nodePanel.AddComponent<Image>(); //add image component to panel
    //        image.color = Random.ColorHSV(); //assign a random colour to the panel
    //    }
    //}

    private void Start()
    {
        //creates list of predefined nodes/rectangles for treemap
        List<TreeMapNode> TreeNodes = new List<TreeMapNode>
        {
            //representation of rectangle with its percentage of overall rect
            new TreeMapNode(15),
            new TreeMapNode(23),
            new TreeMapNode(19),
            new TreeMapNode(10),
            new TreeMapNode(27)
        };

        Rect LargestRect = new Rect(0, 0, 1920, 1080);
        Squarify(TreeNodes, LargestRect);
    }

    //Squarified treemap algorithm
    private void Squarify(List<TreeMapNode> TreeNodes, Rect RectRef)
    {
        if (TreeNodes.Count == 0) return;
        int RectCount = 0;
        float TotalArea = 0;
        //Adding all nodes area together
        foreach (var Node in TreeNodes)
        {
            TotalArea += Node.Area;
        }

        float CurrentX = RectRef.x;
        float CurrentY = RectRef.y;

        float CurrentWidth = RectRef.width;
        float CurrentHeight = RectRef.height;

        //loop through nodes, cal size and spawn
        foreach (var Node in TreeNodes)
        {
            //Calculates width of node based off area
            float NodeWidth = (Node.Area / TotalArea) * CurrentWidth;

            //set the node calculated size
            Node.Rectangle = new Rect(CurrentX, CurrentY, NodeWidth, CurrentHeight);
            //Debug.Log(Node.Rectangle.size);

            //incriment position disallowing for overlap
            CurrentX += NodeWidth;

            //Create Ui to visualise node
            GameObject NodePanel = new GameObject("CreatedNodePanel" + RectCount);
            NodePanel.transform.SetParent(this.transform);
            Debug.Log(NodePanel.transform.localScale + "   " + RectCount);

            RectTransform RectRefTrans = NodePanel.AddComponent<RectTransform>();

            RectRefTrans.anchorMin = new Vector2(0, 0);
            RectRefTrans.anchorMax = new Vector2(0, 0);
            RectRefTrans.pivot = new Vector2(0, 0);
            //sets anchored pos relitive to the pivot
            RectRefTrans.anchoredPosition = new Vector2(Node.Rectangle.x, Node.Rectangle.y);
            //Debug.Log(RectRefTrans.transform.localScale + "    " +RectCount);
            RectRefTrans.sizeDelta = new Vector2(Node.Rectangle.width, Node.Rectangle.height);
            //Debug.Log(RectRefTrans.transform.localScale+ "    " + RectCount);

            Image NodeImage = NodePanel.AddComponent<Image>();
            NodeImage.color = Random.ColorHSV();
            RectCount++;
        }

    }

    IEnumerator CallDelay()
    {
        yield return new WaitForSeconds(2);
    }
    
}
