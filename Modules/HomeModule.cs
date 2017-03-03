using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace RecipeBox
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index.cshtml"];

            Get["/venues"] = _ => {
                List<Venue> AllVenues = Venue.GetAll();
                return View["venues.cshtml", AllVenues];
            };
        //     Get["/recipes"] = _ => {
        //         List<Recipe> AllRecipes = Recipe.GetAll();
        //         return View["recipes.cshtml", AllRecipes];
        //     };
           //
        //     Get["/venues/new"] = _ => {
        //         return View["venues_form.cshtml"];
        //     };
        //     Post["/venues/new"] = _ => {
        //         Venue newVenue = new Venue(Request.Form["category-name"]);
        //         newVenue.Save();
        //         return View["venues.cshtml", Venue.GetAll()];
        //     };
           //
        //     Get["/recipes/new"] = _ => {
        //         List<Venue> AllVenues = Venue.GetAll();
        //         return View["recipes_form.cshtml", AllVenues];
        //     };
        //     Post["/recipes/new"] = _ => {
        //         Recipe newRecipe = new Recipe(Request.Form["recipe-name"], Request.Form["recipe-ingredient"], Request.Form["recipe-instruction"], Request.Form["recipe-rating"]);
        //         newRecipe.Save();
        //         return View["recipes.cshtml", Recipe.GetAll()];
        //     };
           //
        //     Get["recipes/{id}"] = parameters => {
        //         Dictionary<string, object> model = new Dictionary<string, object>();
        //         Recipe SelectedRecipe = Recipe.Find(parameters.id);
        //         List<Venue> RecipeVenues = SelectedRecipe.GetVenues();
        //         List<Venue> AllVenues = Venue.GetAll();
        //         model.Add("recipe", SelectedRecipe);
        //         model.Add("recipeVenues", RecipeVenues);
        //         model.Add("allVenues", AllVenues);
        //         return View["recipe.cshtml", model];
        //     };
        //     Get["/venues/{id}"] = parameters => {
        //         Dictionary<string, object> model = new Dictionary<string, object>();
        //         var SelectedVenue = Venue.Find(parameters.id);
        //         var VenueRecipes = SelectedVenue.GetRecipes();
        //         List<Recipe> AllRecipes = Recipe.GetAll();
        //         model.Add("category", SelectedVenue);
        //         model.Add("categoryRecipes", VenueRecipes);
        //         model.Add("allRecipes", AllRecipes);
        //         return View["category.cshtml", model];
        //     };
           //
        //     Post["/recipe/add_category"] = _ => {
        //         Venue category = Venue.Find(Request.Form["category-id"]);
        //         Recipe recipe = Recipe.Find(Request.Form["recipe-id"]);
        //         recipe.AddVenue(category);
        //         return View["category-list.cshtml", recipe.GetVenues()];
        //     };
        //     Post["/category/add_recipe"] = _ => {
        //         Venue category = Venue.Find(Request.Form["category-id"]);
        //         Recipe recipe = Recipe.Find(Request.Form["recipe-id"]);
        //         category.AddRecipe(recipe);
        //         return View["recipe-list.cshtml", category.GetRecipes()];
        //     };
           //
        //     Patch["/category/edit/{id}"] = parameters => {
        //         Venue SelectedVenue = Venue.Find(parameters.id);
        //         SelectedVenue.UpdateVenues(Request.Form["new-category-name"]);
        //         return View["venues.cshtml", Venue.GetAll()];
        //     };
        //     Patch["/recipe/edit/{id}"] = parameters => {
        //         Recipe SelectedRecipe = Recipe.Find(parameters.id);
        //         SelectedRecipe.UpdateRecipes(Request.Form["new-recipe-name"], Request.Form["new-recipe-ingredient"], Request.Form["new-recipe-instruction"], Request.Form["new-recipe-rating"]);
        //         return View["recipes.cshtml", Recipe.GetAll()];
        //     };
           //
        //     Get["/recipes/detail/{id}"] = parameters =>
        //     {
        //         Recipe recipe = Recipe.Find(parameters.id);
        //         return View["recipe-detail.cshtml", recipe];
        //     };
           //
        //     Delete["/venues/{id}"] = parameters =>
        //     {
        //         Venue targetVenue = Venue.Find(parameters.id);
        //         targetVenue.Delete();
        //         return View["venues.cshtml", Venue.GetAll()];
        //     };
        //     Delete["/recipes/{id}"] = parameters =>
        //     {
        //         Recipe targetRecipe = Recipe.Find(parameters.id);
        //         targetRecipe.Delete();
        //         return View["recipes.cshtml", Recipe.GetAll()];
        //     };
           //
        //     Post["/recipe/search/results"] = _ => {
        //        List<Recipe> FoundList = new List<Recipe>{};
        //        Recipe foundRecipe = Recipe.FindByIngredient(Request.Form["recipe-search"]);
        //        FoundList.Add(foundRecipe);
        //        return View["search.cshtml", FoundList];
        //    };
           //
        //     Post["/venues/delete"] = _ => {
        //         Venue.DeleteAll();
        //         Recipe.DeleteAll();
        //         return View["index.cshtml"];
        //     };
        //     Post["/recipes/delete"] = _ => {
        //         Recipe.DeleteAll();
        //         return View["index.cshtml"];
        //     };
        }
    }
}
