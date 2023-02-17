using UnityEngine;
using UnityEngine.UI;

public class RecipeHint : MonoBehaviour
{
    public void SetRecipeSprite(Sprite sprite, int idx)
    {
        Recipes[idx].sprite = sprite;
        Recipes[idx].gameObject.SetActive(sprite != null);
    }
    
    public Image[] Recipes;
}
