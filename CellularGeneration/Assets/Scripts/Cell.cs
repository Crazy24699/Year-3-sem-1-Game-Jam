using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool CellAlive = false;

    public SpriteRenderer SpriteRenderRef;

    [SerializeField] private Color LivingColour;
    [SerializeField] private Color DeadColour;

    private void Start()
    {
        SpriteRenderRef = GetComponent<SpriteRenderer>();
        UpdateCellColour();
    }

    public void UpdateCellColour()
    {
        SpriteRenderRef.color = CellAlive ? LivingColour : DeadColour;
    }

}
