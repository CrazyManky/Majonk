using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Screpts.Instances.Bones
{
    public abstract class BaseBone : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        private SelectedItemCanvas _selectedItemCanvas;

        private Vector2 _hasPosition = Vector2.zero;

        public RectTransform RectTransform => _rectTransform;

        public void Construct(SelectedItemCanvas SelectedItemCanvas)
        {
            _selectedItemCanvas = SelectedItemCanvas;
        }

        public void MovePosition(Vector2 targetPosition)
        {
            if (_hasPosition == Vector2.zero)
            {
                _hasPosition = transform.position;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_hasPosition == Vector2.zero)
            {
                _hasPosition = _rectTransform.position;
            }

            _selectedItemCanvas.SelectBone(this);
        }

        public void Reset()
        {
            _rectTransform.DOAnchorPos(_hasPosition, 0.5f);
        }
    }
}