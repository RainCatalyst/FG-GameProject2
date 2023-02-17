using UnityEngine;
using UnityEngine.UI;

public class RecipeHint : MonoBehaviour
{
    public void SetRecipeSprite(Sprite sprite, int idx)
    {
        Recipes[idx].sprite = sprite;

        for (int i = 0; i < 2; i++)
        {
            Recipes[idx].gameObject.SetActive(Recipes[i].sprite != null);
            
        }
        
        for (int i = 0; i < 2; i++)
        {
            if (Recipes[1 - idx].gameObject.activeSelf && Recipes[1 - idx].sprite == Recipes[idx].sprite)
                Recipes[idx].gameObject.SetActive(false);
        }
    }
    
    public Image[] Recipes;
}
