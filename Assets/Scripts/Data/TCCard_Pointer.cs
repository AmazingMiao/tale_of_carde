using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class TCCard : TCNode, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector2 pointerDifference;
    public TCGrid selectedGridTemp;

    public void OnBeginDrag(PointerEventData selectingCard)
    {
        //Debug.Log(selectingCard);
        pointerDifference.x = selectingCard.position.x - transform.position.x;
        pointerDifference.y = selectingCard.position.y - transform.position.y;
        this.source = TCBattleSystem.instance.playerUnits[0];
        this.GetComponent<CanvasGroup>().alpha = 0.3f;
        ShowAvaliableGrids();
    }

    public void OnDrag(PointerEventData selectingCard)
    {
        //Debug.Log(selectingCard);
        transform.position = selectingCard.position - pointerDifference;
        TCGrid selectedGrid = TCMap.instance.FindGridByPointer(selectingCard);
        if(selectedGridTemp != null && selectedGrid != selectedGridTemp)
        {
            selectedGridTemp.EnterState(TCGridState.Normal);
            ShowAvaliableGrids();
        }
        if(selectedGrid != null)
        {
            selectedGrid.EnterState(TCGridState.Selected);
            selectedGridTemp = selectedGrid;
            //Debug.Log(selectedGridTemp);
        }
        
    }

    public void OnEndDrag(PointerEventData selectingCard)
    {
        TCGrid selectedGrid = TCMap.instance.FindGridByPointer(selectingCard);
        // Debug.Log(selectingCard);
        // Debug.Log(selectedGrid);
        if(FindAvaliableGrids().Contains(selectedGrid) == false)
        {
            Clear();
            return;    
        }
        switch(type)
            {
                case Type.Attack:
                if(selectedGrid.unit == null)
                {
                    Clear();
                    return;
                }
                break;
                case Type.Move:
                if(selectedGrid.unit != null)
                {
                    Clear();
                    return;
                }
                break;
                default:
                break;
            }
        ExcuteEffect(selectedGrid);
        TCCardSystem.instance.Play(this);
        Clear();
    }

    public List<TCGrid> FindAvaliableGrids()
    {
        List<TCGrid> grids = TCMap.instance.FindGridsWithinDistance(source.grid, this.range);
        return grids;
    }

    public void ShowAvaliableGrids()
    {
        List<TCGrid> grids = TCMap.instance.FindGridsWithinDistance(source.grid, this.range);
        foreach(var grid in grids)
        {
            grid.EnterState(TCGridState.Green);
        }
    }

    public void HideAvaliableGrids()
    {
        List<TCGrid> grids = TCMap.instance.grids;
        foreach(var grid in grids)
        {
            grid.EnterState(TCGridState.Normal);
        }
    }

    public void Clear()
    {
        TCCardSystem.instance.UpdateUI();
        this.GetComponent<CanvasGroup>().alpha = 1f;
        HideAvaliableGrids();
        this.source = null;
    }
}
