using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    #region References

    private RectTransform _rectTransform;

    private RectTransform[] _rtChildren;

    private float _width, _height;

    private float _childWidth, _childHeight;

    private Vector3 _resizeCenter;

    private float _areaWidth;

    #endregion

    #region Serialize

    [Tooltip(" How far apart each item is in the scroll view.")]
    [SerializeField] private float _itemSpacing;


    [Tooltip("How much the items are indented from the top/bottom and left/right of the scroll view.")]
    [SerializeField] private float _horizontalMargin, _verticalMargin;



    [Tooltip("Is the scroll view oriented horizontal or vertically ?")]
    [SerializeField] private bool _horizontal, _vertical;



    [SerializeField] private AnimationCurve _resizeRatio;

    [SerializeField] private int _contentSize;

    #endregion


    #region Properties

    public float ItemSpacing { get { return _itemSpacing; } }

    public float HorizontalMargin { get { return _horizontalMargin; } }

    public float VerticalMargin { get { return _verticalMargin; } }

    public bool Horizontal { get { return _horizontal; } }

    public bool Vertical { get { return _vertical; } }

    public float Width { get { return _width; } }

    public float Height { get { return _height; } }

    public float ChildWidth { get { return _childWidth; } }

    public float ChildHeight { get { return _childHeight; } }


    #endregion


    private void Start()
    {
        EnableContentObjects();
        InitializeScrollContent();
        VisibleAreaWidthCalculator();
        if (_vertical)
            CalculateContentPos();
    }

    private void InitializeScrollContent()
    {
        _rectTransform = GetComponent<RectTransform>();
        _resizeCenter = _rectTransform.position;
        _rtChildren = new RectTransform[_rectTransform.childCount];

        for (int i = 0; i < _rectTransform.childCount; i++)
        {
            _rtChildren[i] = _rectTransform.GetChild(i) as RectTransform;
        }

        _width = _rectTransform.rect.width - (2 * _horizontalMargin);

        _height = _rectTransform.rect.height - (2 * _verticalMargin);

        _childWidth = _rtChildren[0].rect.width;
        _childHeight = _rtChildren[0].rect.height;

        _horizontal = !_vertical;
    }

    private void CalculateContentPos()
    {
        float originY = 0 - (_height * 0.5f);
        float posOffset = _childHeight * 0.5f;
        for (int i = 0; i < _rtChildren.Length; i++)
        {
            Vector2 childPos = _rtChildren[i].localPosition;
            childPos.y = originY + posOffset + i * Screen.width * (_childHeight + _itemSpacing);
            _rtChildren[i].localPosition = childPos;
        }
    }

    public void ResizeObjects()
    {
        foreach (var t in _rtChildren)
        {
            var distance = Vector3.Distance(_resizeCenter, t.position);
            distance = Mathf.Abs(distance);
            var offSet = distance / _areaWidth;
            t.localScale = Vector3.one * _resizeRatio.Evaluate(offSet);
        }
    }

    private void VisibleAreaWidthCalculator() => _areaWidth = _rectTransform.rect.height;

    private void EnableContentObjects()
    {
        for (var i = 0; i < _contentSize; i++)
        {
            GameEvents.GetObjectsInPoolMethod(ObjectTypes.BarrackUi);
            GameEvents.GetObjectsInPoolMethod(ObjectTypes.PowerPlantUi);
        }
    }
}
