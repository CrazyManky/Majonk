using System;
using System.Collections.Generic;
using _Project.Screpts.Instances.Bones;
using _Project.Screpts.ItemsCounter;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace _Project.Screpts.Instances
{
    [Serializable]
    public class BoneInstance
    {
        [SerializeField] private Counter _counter;
        [SerializeField] private SelectedItemCanvas _selectedItemCanvas;
        [SerializeField] public List<BaseBone> _bones;
        [SerializeField] public Transform _boneConteiner;
        [SerializeField] public GridLayoutGroup _gridLayout;
        [SerializeField] public int _countInstance;


        public async UniTask InstanceItemsAsync()
        {
            // Проверяем, что количество объектов чётное и больше 0
            if (_countInstance <= 1)
            {
                Debug.LogError("Количество объектов должно быть больше 1!");
                return;
            }

            if (_countInstance % 2 != 0)
            {
                _countInstance--; // Уменьшаем на 1, если нечётное
            }

            Debug.Log($"Количество объектов после корректировки: {_countInstance}");

            List<BaseBone> instances = new List<BaseBone>();

            // Создаём объекты парами
            for (int i = 0; i < _countInstance / 2; i++)
            {
                // Проверяем, что список _bones не пуст
                if (_bones.Count == 0)
                {
                    Debug.LogError("Список _bones пуст!");
                    return;
                }

                // Выбираем случайный индекс
                int randomIndex = new Random().Next(0, _bones.Count);

                // Создаем два экземпляра объекта
                var firstInstance = Object.Instantiate(_bones[randomIndex], _boneConteiner);
                _counter.AddItems();
                firstInstance.Construct(_selectedItemCanvas);
                var secondInstance = Object.Instantiate(_bones[randomIndex], _boneConteiner);
                secondInstance.Construct(_selectedItemCanvas);
                _counter.AddItems();

                instances.Add(firstInstance);
                instances.Add(secondInstance);

                Debug.Log($"Созданы объекты {firstInstance.name} и {secondInstance.name}");
            }

            Shuffle(_gridLayout);
        }

        private void Shuffle(GridLayoutGroup gridLayoutGroup)
        {
            if (gridLayoutGroup == null) return;

            // Получаем дочерние объекты GridLayoutGroup
            List<RectTransform> children = new List<RectTransform>();
            foreach (Transform child in gridLayoutGroup.transform)
            {
                if (child is RectTransform rectTransform)
                {
                    children.Add(rectTransform);
                }
            }

            // Перемешиваем дочерние элементы
            Random random = new Random();
            for (int i = children.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);
                RectTransform temp = children[i];
                children[i] = children[randomIndex];
                children[randomIndex] = temp;
            }

            // Обновляем порядок в GridLayoutGroup
            for (int i = 0; i < children.Count; i++)
            {
                children[i].SetSiblingIndex(i); // Устанавливаем новый порядок объектов в контейнере
            }
        }

        public void FinalizeInstanceCreation()
        {
            _gridLayout.enabled = false;
        }
    }
}