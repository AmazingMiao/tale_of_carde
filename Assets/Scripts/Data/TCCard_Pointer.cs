using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

<<<<<<< Updated upstream
public partial class TCCard : TCNode, IBeginDragHandler, IDragHandler, IEndDragHandler
=======
public partial class TCCard : TCNode, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
>>>>>>> Stashed changes
{
    public Vector2 pointerDifference;
    public TCGrid selectedGridTemp;

    public void OnBeginDrag(PointerEventData selectingCard)
    {
<<<<<<< Updated upstream
        //Debug.Log(selectingCard);
        pointerDifference.x = selectingCard.position.x - transform.position.x;
        pointerDifference.y = selectingCard.position.y - transform.position.y;
        this.source = TCBattleSystem.instance.playerUnits[0];
        this.GetComponent<CanvasGroup>().alpha = 0.3f;
        ShowAvaliableGrids();
=======
        if(this.isReward != true)
        {
        //Debug.Log(selectingCard);
        pointerDifference.x = selectingCard.position.x - transform.position.x;
        pointerDifference.y = selectingCard.position.y - transform.position.y;
        this.source = TCUnitsSystem.instance.playerUnits[0];
        this.GetComponent<CanvasGroup>().alpha = 0.3f;
        ShowAvaliableGrids();
        }
>>>>>>> Stashed changes
    }

    public void OnDrag(PointerEventData selectingCard)
    {
<<<<<<< Updated upstream
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
        
=======
        if(this.isReward != true)
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
>>>>>>> Stashed changes
    }

    public void OnEndDrag(PointerEventData selectingCard)
    {
<<<<<<< Updated upstream
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
=======
        if(this.isReward != true)
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
                    case TCCardType.Attack:
                    if(selectedGrid.unit == null)
                    {
                        Clear();
                        return;
                    }
                    break;
                    case TCCardType.Move:
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
    }

    public void OnPointerClick(PointerEventData selectedCard)
    {
        isReward = false;
        TCCardSystem.instance.deck.Add(this);
        this.transform.SetParent(TCCardSystem.instance.transform);
        int childCount = TCCardSystem.instance.cardSelectingPanel.transform.childCount;
		for (int i = 0; i < childCount ; i++) 
        {
			Destroy (TCCardSystem.instance.cardSelectingPanel.transform.GetChild (0).gameObject);
		}
        TCCardSystem.instance.cardSelectingPanel.gameObject.SetActive(false);
        TCCardSystem.instance.selectCardButton.gameObject.SetActive(false);
>>>>>>> Stashed changes
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
