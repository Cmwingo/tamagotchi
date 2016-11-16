using Nancy;
using TravelLog.Objects;
using System.Collections.Generic;

namespace TravelLog
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/places"] = _ => {
        List<Place> allPlaces = Place.GetAll();
        return View["places.cshtml", allPlaces];
      };
      Get["/places/{id}"] = parameters => {
        Place place = Place.Find(parameters.id);
        return View["/place.cshtml", place];
      };
      Get["/places/new"] = _ => {
        return View["place_form.cshtml"];
      };
      Post["/places"] = _ => {
        Place newPlace = new Place (Request.Form["new-place-name"], Request.Form["new-place-description"], Request.Form["new-place-photo"]);
        List<Place> allPlaces = Place.GetAll();
        return View["places.cshtml", allPlaces];
      };
    }
  }
}
