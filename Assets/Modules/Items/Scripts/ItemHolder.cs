using UnityEngine;

//Pickup logic, this component displays an item that the player is holding
public class ItemHolder : MonoBehaviour
{
    public string ItemId => _id;
    public ItemData Item => ItemDatabase.Get(_id);

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
        }
    }

    [SerializeField]
    private Transform _itemParent;
    private GameObject _activeItem;
    private string _id;
}