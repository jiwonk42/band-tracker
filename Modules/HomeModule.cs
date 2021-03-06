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
                Band newBand = new Band(Request.Form["band-name"], Request.Form["band-genre"], Request.Form["band-song"]);
                newBand.Save();
                return View["bands.cshtml", Band.GetAll()];
            };

            Get["/venues/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                var SelectedVenue = Venue.Find(parameters.id);
                var VenueBands = SelectedVenue.GetBands();
                List<Band> AllBands = Band.GetAll();
                model.Add("venue", SelectedVenue);
                model.Add("venueBands", VenueBands);
                model.Add("allBands", AllBands);
                return View["venue.cshtml", model];
            };
            Get["bands/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                Band SelectedBand = Band.Find(parameters.id);
                List<Venue> BandVenues = SelectedBand.GetVenues();
                List<Venue> AllVenues = Venue.GetAll();
                model.Add("band", SelectedBand);
                model.Add("bandVenues", BandVenues);
                model.Add("allVenues", AllVenues);
                return View["band.cshtml", model];
            };

            Post["/band/add_venue"] = _ => {
                Venue venue = Venue.Find(Request.Form["venue-id"]);
                Band band = Band.Find(Request.Form["band-id"]);
                band.AddVenue(venue);
                return View["venue-list.cshtml", band.GetVenues()];
            };
            Post["/venue/add_band"] = _ => {
                Venue venue = Venue.Find(Request.Form["venue-id"]);
                Band band = Band.Find(Request.Form["band-id"]);
                venue.AddBand(band);
                return View["band-list.cshtml", venue.GetBands()];
            };

            Patch["/venue/edit/{id}"] = parameters => {
                Venue SelectedVenue = Venue.Find(parameters.id);
                SelectedVenue.UpdateVenues(Request.Form["new-venue-name"]);
                return View["venues.cshtml", Venue.GetAll()];
            };

            Get["/bands/detail/{id}"] = parameters =>
            {
                Band band = Band.Find(parameters.id);
                return View["band-detail.cshtml", band];
            };

            Delete["/venues/{id}"] = parameters =>
            {
                Venue targetVenue = Venue.Find(parameters.id);
                targetVenue.Delete();
                return View["venues.cshtml", Venue.GetAll()];
            };
            Delete["/bands/{id}"] = parameters =>
            {
                Band targetBand = Band.Find(parameters.id);
                targetBand.Delete();
                return View["bands.cshtml", Band.GetAll()];
            };

            Post["/venues/delete"] = _ => {
                Venue.DeleteAll();
                return View["index.cshtml"];
            };
            Post["/bands/delete"] = _ => {
                Band.DeleteAll();
                return View["index.cshtml"];
            };
        }
    }
}
