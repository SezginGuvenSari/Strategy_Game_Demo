using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScrollController : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
{
    #region References

    private ScrollRect _scrollRect;


    private Vector2 _lastDragPosition;


    private bool _positiveDrag;

    #endregion


    #region Serialize

    [SerializeField]
    private ScrollContent _scrollContent;

    [SerializeField]
    private float _outOfBoundsThreshold;


    #endregion


    private void Start() => Initialize();

    private void Initialize()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _scrollRect.vertical = _scrollContent.Vertical;
        _scrollRect.horizontal = _scrollContent.Horizontal;
        _scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
    }

    public void OnBeginDrag(PointerEventData eventData) => _lastDragPosition = eventData.position;

    public void OnDrag(PointerEventData eventData)
    {
        if (_scrollContent.Vertical)
        {
            _positiveDrag = eventData.position.y > _lastDragPosition.y;
        }
        else if (_scrollContent.Horizontal)
        {
            _positiveDrag = eventData.position.x > _lastDragPosition.x;
        }

        _lastDragPosition = eventData.position;
    }

    public void OnScroll(PointerEventData eventData)
    {
        _positiveDrag = _scrollContent.Vertical
            ? eventData.scrollDelta.y > 0
            : _positiveDrag = eventData.scrollDelta.y < 0;
    }

    public void OnViewScroll()
    {
        if (_scrollContent.Vertical)
            HandleVerticalScroll();
    }

    private void HandleVerticalScroll()
    {
        int currentItemIndex = _positiveDrag ? _scrollRect.content.childCount - 1 : 0;
        var currentItem = _scrollRect.content.GetChild(currentItemIndex);

        if (!ReachedThreshold(currentItem))
        {
            return;
        }

        var endItemIndex = _positiveDrag ? 0 : _scrollRect.content.childCount - 1;
        var endItem = _scrollRect.content.GetChild(endItemIndex);
        Vector2 newPos = endItem.position;

        newPos.y = _positiveDrag
            ? endItem.position.y - _scrollContent.ChildHeight * 1.5f + _scrollContent.ItemSpacing
            : newPos.y = endItem.position.y + _scrollContent.ChildHeight * 1.5f - _scrollContent.ItemSpacing;

        currentItem.position = newPos;
        currentItem.SetSiblingIndex(endItemIndex);
    }

    private bool ReachedThreshold(Transform item)
    {
        if (_scrollContent.Vertical)
        {
            var posYThreshold = transform.position.y + _scrollContent.Height * 0.5f + _outOfBoundsThreshold;
            var negYThreshold = transform.position.y - _scrollContent.Height * 0.5f - _outOfBoundsThreshold;
            return _positiveDrag ? item.position.y - _scrollContent.ChildWidth * 0.5f > posYThreshold :
                item.position.y + _scrollContent.ChildWidth * 0.5f < negYThreshold;
        }
        else
        {
            var posXThreshold = transform.position.x + _scrollContent.Width * 0.5f + _outOfBoundsThreshold;
            var negXThreshold = transform.position.x - _scrollContent.Width * 0.5f - _outOfBoundsThreshold;
            return _positiveDrag ? item.position.x - _scrollContent.ChildWidth * 0.5f > posXThreshold :
                item.position.x + _scrollContent.ChildWidth * 0.5f < negXThreshold;
        }
    }
}
