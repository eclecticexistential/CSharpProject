using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Models
{
    public class AddIngredientList
    {
        public AddIngredientList()
        {
            using (var _groceryRepoItems = new GroceryContext())
            {
                var inventory = _groceryRepoItems.GroceryItems.ToArray();
                var recipeList = _groceryRepoItems.ListOfRecipes.ToArray();
                if (recipeList.Length == 1)
                {
                    List<Items> listOfPotatoSoupItems = new List<Items> { };
                    List<string> potatoSoupIds = new List<string> { "Potato Soup", "Potato", "Milk", "Butter", "Pepper", "Salt", "Bacon", "Celery", "Onion", "Vegetable Broth" };
                    var potatoSoup = recipeList.SingleOrDefault(x => x.RecipeName == potatoSoupIds[0]);
                    if(potatoSoup.Item.Count == 0)
                    {
                        foreach (var ingredient in potatoSoupIds)
                        {
                            var addThis = inventory.SingleOrDefault(x => x.ItemName == ingredient);
                            listOfPotatoSoupItems.Add(addThis);
                        }
                        potatoSoup.Item = listOfPotatoSoupItems;
                        _groceryRepoItems.SaveChanges();
                    }
                }
            }
        }
        public void AddIngredients(List<string> ingredientList)
        {
            string recipeName = ingredientList[0];
            RecipeItems newRecipe = new RecipeItems()
            {
                RecipeName = recipeName
            };
            using (var _groceryRepoItems = new GroceryContext())
            {
                _groceryRepoItems.ListOfRecipes.Add(newRecipe);
                var inventory = _groceryRepoItems.GroceryItems.ToArray();
                var recipeList = _groceryRepoItems.ListOfRecipes.ToArray();
                var oneRecipe = recipeList.SingleOrDefault(x => x.RecipeName == ingredientList[0]);
                List<Items> updateList = new List<Items> { };
                foreach (var ingredient in ingredientList)
                {
                    var addThis = inventory.SingleOrDefault(x => x.ItemName == ingredient);
                    updateList.Add(addThis);
                }
                oneRecipe.Item = updateList;
                _groceryRepoItems.SaveChanges();
            }
        }
        }
}