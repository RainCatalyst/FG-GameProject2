using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Data/RecipeData")]
public class RecipeData : ScriptableObject
{
    public IReadOnlyList<string> RequiredItems => _requiredItems;
    public string Result => _result;

    [SerializeField]
    private List<string> _requiredItems;
    [SerializeField]
    private string _result;
}