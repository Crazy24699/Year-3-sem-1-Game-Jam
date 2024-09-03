using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int Rows;
    [SerializeField] private int Columns;

    [SerializeField] private GameObject CellPrefab;
    [SerializeField] private GameObject[,] GridArray;

    private GameObject GridParent;

    private void Start()
    {
        GridParent=Instantiate(new GameObject(), Vector2.zero, Quaternion.identity);

        if(Rows == 0) Rows = 10;
        if(Columns == 0) Columns = 10;

        GridArray = new GameObject[Rows, Columns];
        PopulateGrid();
    }

    private void PopulateGrid()
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                Vector2 CellPosition = new Vector2(x, y);
                GridArray[x, y] = Instantiate(CellPrefab, CellPosition, Quaternion.identity);
                GridArray[x, y].transform.SetParent(GridParent.transform);
                GridArray[x, y].GetComponent<Cell>().CellAlive = Random.Range(0, 2) == 0 ? true : false;
                GridArray[x, y].GetComponent<Cell>().UpdateCellColour();
                
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            UpdateGrid();
        }
    }

    private void UpdateGrid()
    {
        bool[,] NewStates = new bool[Rows, Columns];
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                int LiveNeighbours = CountLiveNeighbours(x, y);
                //Conways game of life rules
                if (GridArray[x, y].GetComponent<Cell>().CellAlive)
                {
                    //if cell equaled to 2 or 3 its alive, if not, it dead
                    NewStates[x, y] = LiveNeighbours == 2 || LiveNeighbours == 3; 
                }
                else
                {
                    //if its stated as dead but has neighbours, make it alive
                    NewStates[x, y] = LiveNeighbours == 3;
                }
            }
        }

        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                GridArray[x, y].GetComponent<Cell>().CellAlive = NewStates[x, y];
                GridArray[x, y].GetComponent<Cell>().UpdateCellColour();
            }
        }

    }

    private int CountLiveNeighbours(int Row, int Column)
    {
        int Count = 0;
        for (int x = -1; x <= 1; x++) 
        {
            for (int y = -1; y <= 1; y++)
            {

                if (x == 0 && y == 0) continue;

                int XNeighbour = x + Row;
                int YNeighbour = y + Column;

                //out of bounds check 
                if((XNeighbour >= 0 && XNeighbour < Rows) 
                    && (YNeighbour >= 0 && YNeighbour < Columns))
                {
                    Debug.Log(XNeighbour + "  " + YNeighbour);
                    if (GridArray[XNeighbour, YNeighbour].GetComponent<Cell>().CellAlive)
                    {
                        Count++;
                    }
                }
            }
        }

        return Count;
    }
    int CountLiveNeighbour(int Row, int Column)
    {
        int Count = 0;

        // loop through the 8 neighbours of the cell
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                //if (x >= rows || y >= columns) break; // out of bounds check

                if (x == 0 && y == 0) continue; //skip over the cell we are checking for neighbours

                int xNeighbourC = x + Row; //x co ordinate for neighbour

                int yNeighbourC = y + Column; //y co ordinate for neighbour

                if ((xNeighbourC >= 0 && xNeighbourC < Rows) && (yNeighbourC >= 0 && yNeighbourC < Columns))
                {
                    // if cell is alive, add to count
                    if (GridArray[xNeighbourC, yNeighbourC].GetComponent<Cell>().CellAlive)
                    {
                        Count++;
                    }
                }
            }
        }

        return Count;
    }
}
