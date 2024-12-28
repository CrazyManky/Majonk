using System;
using TMPro;
using UnityEngine;

namespace _Project.Screpts.ItemsCounter
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textCount;

        public event Action CountEnd;

        private int _itemsCountInstasnce;

        public void AddItems()
        {
            _itemsCountInstasnce++;
            _textCount.text = $"{_itemsCountInstasnce}";
        }

        public void RemoveItems()
        {
            _itemsCountInstasnce--;
            _textCount.text = $"{_itemsCountInstasnce}";

            if (_itemsCountInstasnce <= 0)
            {
                CountEnd?.Invoke();
            }
        }
    }
}