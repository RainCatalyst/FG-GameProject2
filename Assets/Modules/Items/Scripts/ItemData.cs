using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public string Id => _id;
    public GameObject GameObject => _gameObject;
    [SerializeField]
    private string _id;
    [SerializeField]
    private GameObject _gameObject;

    public void Print()
    {
        Debug.Log(_id);
    }
}