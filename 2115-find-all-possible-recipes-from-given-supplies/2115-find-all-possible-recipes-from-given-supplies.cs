public class Solution {
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        var possibleRecipes = new List<string>();
        // 재료 혹은 레시피를 만들 수 있는지 여부를 추적하는 Dictionary
        var canMake = new Dictionary<string, bool>();
        // 레시피 이름을 ingredients 리스트의 인덱스로 매핑하는 Dictionary
        var recipeToIndex = new Dictionary<string, int>();

        // 초기 supplies는 모두 사용 가능하도록 표시
        foreach (var supply in supplies) {
            canMake[supply] = true;
        }

        // 레시피와 인덱스 매핑 생성
        for (int idx = 0; idx < recipes.Length; idx++) {
            recipeToIndex[recipes[idx]] = idx;
        }

        // DFS를 사용하여 각 레시피를 만들 수 있는지 확인
        foreach (var recipe in recipes) {
            CheckRecipe(recipe, ingredients, new HashSet<string>(), canMake, recipeToIndex);
            if (canMake.ContainsKey(recipe) && canMake[recipe]) {
                possibleRecipes.Add(recipe);
            }
        }

        return possibleRecipes;
    }

    private void CheckRecipe(
        string recipe,
        IList<IList<string>> ingredients,
        HashSet<string> visited,
        Dictionary<string, bool> canMake,
        Dictionary<string, int> recipeToIndex
    ) {
        // 이미 해당 재료/레시피를 만들 수 있는지 확인한 경우 바로 반환
        if (canMake.ContainsKey(recipe) && canMake[recipe])
            return;

        // 유효한 레시피가 아니거나 사이클이 감지된 경우
        if (!recipeToIndex.ContainsKey(recipe) || visited.Contains(recipe)) {
            canMake[recipe] = false;
            return;
        }

        visited.Add(recipe);

        // 필요한 모든 재료를 만들 수 있는지 확인
        var neededIngredients = ingredients[recipeToIndex[recipe]];
        foreach (var ingredient in neededIngredients) {
            CheckRecipe(ingredient, ingredients, visited, canMake, recipeToIndex);
            if (!canMake.ContainsKey(ingredient) || !canMake[ingredient]) {
                canMake[recipe] = false;
                return;
            }
        }

        // 모든 재료를 만들 수 있으면 해당 레시피도 만들 수 있음
        canMake[recipe] = true;
    }
}
