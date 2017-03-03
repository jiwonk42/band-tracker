using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
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
            Get["/bands"] = _ => {
                List<Band> AllBands = Band.GetAll();
                return View["bands.cshtml", AllBands];
            };

            Get["/venues/new"] = _ => {
                return View["venues_form.cshtml"];
            };
            Post["/venues/new"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                return View["venues.cshtml", Venue.GetAll()];
            };

            Get["/bands/new"] = _ => {
                List<Venue> AllVenues = Venue.GetAll();
                return View["bands_form.cshtml", AllVenues];
            };
            Post["/bands/new"] = _ => {
                Band newBand = new Band(Request.Form["band-name"], Request.Form["band-ingredient"], Request.Form["band-instruction"], Request.Form["band-rating"]);
                newBand.Save();
                return View["bands.cshtml", Band.GetAll()];
            };
           //
        //     Get["bands/{id}"] = parameters => {
        //         Dictionary<string, object> model = new Dictionary<string, object>();
        //         Band SelectedBand = Band.Find(parameters.id);
        //         List<Venue> BandVenues = SelectedBand.GetVenues();
        //         List<Venue> AllVenues = Venue.GetAll();
        //         model.Add("band", SelectedBand);
        //         model.Add("bandVenues", BandVenues);
        //         model.Add("allVenues", AllVenues);
        //         return View["band.cshtml", model];
        //     };
        //     Get["/venues/{id}"] = parameters => {
        //         Dictionary<string, object> model = new Dictionary<string, object>();
        //         var SelectedVenue = Venue.Find(parameters.id);
        //         var VenueBands = SelectedVenue.GetBands();
        //         List<Band> AllBands = Band.GetAll();
        //         model.Add("category", SelectedVenue);
        //         model.Add("categoryBands", VenueBands);
        //         model.Add("allBands", AllBands);
        //         return View["category.cshtml", model];
        //     };
           //
        //     Post["/band/add_category"] = _ => {
        //         Venue category = Venue.Find(Request.Form["category-id"]);
        //         Band band = Band.Find(Request.Form["band-id"]);
        //         band.AddVenue(category);
        //         return View["category-list.cshtml", band.GetVenues()];
        //     };
        //     Post["/category/add_band"] = _ => {
        //         Venue category = Venue.Find(Request.Form["category-id"]);
        //         Band band = Band.Find(Request.Form["band-id"]);
        //         category.AddBand(band);
        //         return View["band-list.cshtml", category.GetBands()];
        //     };
           //
        //     Patch["/category/edit/{id}"] = parameters => {
        //         Venue SelectedVenue = Venue.Find(parameters.id);
        //         SelectedVenue.UpdateVenues(Request.Form["new-category-name"]);
        //         return View["venues.cshtml", Venue.GetAll()];
        //     };
        //     Patch["/band/edit/{id}"] = parameters => {
        //         Band SelectedBand = Band.Find(parameters.id);
        //         SelectedBand.UpdateBands(Request.Form["new-band-name"], Request.Form["new-band-ingredient"], Request.Form["new-band-instruction"], Request.Form["new-band-rating"]);
        //         return View["bands.cshtml", Band.GetAll()];
        //     };
           //
        //     Get["/bands/detail/{id}"] = parameters =>
        //     {
        //         Band band = Band.Find(parameters.id);
        //         return View["band-detail.cshtml", band];
        //     };
           //
        //     Delete["/venues/{id}"] = parameters =>
        //     {
        //         Venue targetVenue = Venue.Find(parameters.id);
        //         targetVenue.Delete();
        //         return View["venues.cshtml", Venue.GetAll()];
        //     };
        //     Delete["/bands/{id}"] = parameters =>
        //     {
        //         Band targetBand = Band.Find(parameters.id);
        //         targetBand.Delete();
        //         return View["bands.cshtml", Band.GetAll()];
        //     };
           //
        //     Post["/band/search/results"] = _ => {
        //        List<Band> FoundList = new List<Band>{};
        //        Band foundBand = Band.FindByIngredient(Request.Form["band-search"]);
        //        FoundList.Add(foundBand);
        //        return View["search.cshtml", FoundList];
        //    };
           //
        //     Post["/venues/delete"] = _ => {
        //         Venue.DeleteAll();
        //         Band.DeleteAll();
        //         return View["index.cshtml"];
        //     };
        //     Post["/bands/delete"] = _ => {
        //         Band.DeleteAll();
        //         return View["index.cshtml"];
        //     };
        }
    }
}
