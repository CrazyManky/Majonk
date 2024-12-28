using System.Collections.Generic;
using System.Linq;
using _Project.Screpts.Instances.Bones;
using _Project.Screpts.ItemsCounter;
using DG.Tweening;
using UnityEngine;

public class SelectedItemCanvas : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _positions;
    [SerializeField] private Counter _counter;
    
    private List<BaseBone> _selectedBones = new();
    private List<BaseBone> _usedBones = new();

    private int _itemIndex = 0;

    public void SelectBone(BaseBone bone)
    {
        if (_itemIndex > 3)
        {
            return;
        }

        bone.gameObject.SetActive(false);
        _usedBones.Add(bone);
        var instanceNewItem = Instantiate(bone, transform);
        instanceNewItem.gameObject.SetActive(true);
        var hashRect = instanceNewItem.RectTransform;
        instanceNewItem.RectTransform.sizeDelta = new Vector2(55, hashRect.sizeDelta.y);
        _selectedBones.Add(instanceNewItem);
        _itemIndex++;
        CheckForDuplicates();
    }


    private void CheckForDuplicates()
    {
        var duplicates = _selectedBones
            .GroupBy(b => b.GetType())
            .Where(group => group.Count() > 1)
            .ToList();

        bool hasPairs = false;

        foreach (var duplicateGroup in duplicates)
        {
            var duplicateList = duplicateGroup.ToList();
            for (int i = 0; i < duplicateList.Count; i += 2)
            {
                if (i + 1 < duplicateList.Count)
                {
                    hasPairs = true;

                    ProcessDuplicateBone(duplicateList[i], duplicateList[i + 1]);
                }
            }
        }

        if (_selectedBones.Count == 4 && !hasPairs)
        {
           
            foreach (var bone in _selectedBones)
            {
                Destroy(bone.gameObject);
            }

            _selectedBones.Clear();

            foreach (var bone in _usedBones)
            {
                bone.gameObject.SetActive(true);
            }
            _usedBones.Clear();
            _itemIndex = 0;
        }
    }

    private void ProcessDuplicateBone(BaseBone bone1, BaseBone bone2)
    {
        RectTransform rect1 = bone1.GetComponent<RectTransform>();
        RectTransform rect2 = bone2.GetComponent<RectTransform>();

        if (rect1 == null || rect2 == null)
        {
            Debug.LogError("Один из объектов не содержит RectTransform!");
            return;
        }

        Sequence sequence = DOTween.Sequence();
        
        sequence.Append(rect1.DOScale(Vector3.zero, 0.5f))
            .Join(rect1.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360));
        sequence.Join(rect2.DOScale(Vector3.zero, 0.5f))
            .Join(rect2.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360));

        sequence.OnComplete(() =>
        {
            Debug.Log($"Уничтожены дубликаты: {bone1.name} и {bone2.name}");
            
            _selectedBones.Remove(bone1);
            _selectedBones.Remove(bone2);
            
            var original1 = _usedBones.FirstOrDefault(b => b.GetType() == bone1.GetType());
            var original2 = _usedBones.FirstOrDefault(b => b.GetType() == bone2.GetType());

            if (original1 != null)
            {
                _usedBones.Remove(original1);
                Destroy(original1.gameObject);
            }

            if (original2 != null)
            {
                _usedBones.Remove(original2);
                Destroy(original2.gameObject);
            }
            
            Destroy(bone1.gameObject);
            Destroy(bone2.gameObject);
            _counter.RemoveItems();
            _counter.RemoveItems();
            _itemIndex -= 2;
        });
    }
}