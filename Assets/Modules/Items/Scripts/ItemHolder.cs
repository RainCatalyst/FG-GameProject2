using System;
using UnityEngine;

//Pickup logic, this component displays an item that the player is holding
public class ItemHolder : MonoBehaviour
{
    public string ItemId => _id;
    public ItemData Item => ItemDatabase.Get(_id);
    public Transform ItemParent => _itemParent;

    private void Awake()
    {
        _defaultScale = _itemParent.localScale;
    }

    public void SetItem(string id)
    {
        _id = id;

        if (_activeItem != null)
        {
            Destroy(_activeItem);
        }

        if (_id != null)
        {
            _activeItem = Instantiate(Item.GameObject, _itemParent);
            LeanTween.cancel(_itemParent.gameObject);
            _itemParent.localScale = Vector3.zero;
            LeanTween.scale(_itemParent.gameObject, _defaultScale, 0.21f).setEaseOutBack();
        }
    }

    [SerializeField]
    private Transform _itemParent;
    private GameObject _activeItem;
    private Vector3 _defaultScale;
    private string _id;
}