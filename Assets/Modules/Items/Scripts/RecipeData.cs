using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Data/RecipeData")]
public class RecipeData : ScriptableObject
{
    public IReadOnlyList<string> RequiredItems => _requiredItems;
    public string Result => _result;

    public bool CanCraft(List<string> items)
    {
        if (items.Count != _requiredItems.Count)
            return false;

        return OverlapsItems(items);
    }

    public bool OverlapsItems(List<string> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (_requiredItems[i] != items[i])
                return false;
        }

        return true;
    }

    [SerializeField]
    private List<string> _requiredItems;
    [SerializeField]
    private string _result;
}