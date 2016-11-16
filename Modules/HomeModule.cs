using Nancy;
using Tamagotchi.Objects;
using System.Collections.Generic;

namespace Tamagotchi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/pets"] = _ => {
        List<Pet> allPets = Pet.GetAll();
        return View["pets.cshtml", allPets];
      };
      Get["/pets/{id}"] = parameters => {
        Pet pet = Pet.Find(parameters.id);
        if(pet.GetStatus() == "dead")
        {
          return View["/pet_dead.cshtml",pet];
        }
        else
        {
          return View["/pet.cshtml", pet];
        }
      };
      Get["/tamagotchi/new"] = _ => {
        return View["tamagotchi_form.cshtml"];
      };
      Post["/pets"] = _ => {
        Pet newPet = new Pet (Request.Form["new-pet-name"]);
        List<Pet> allPets = Pet.GetAll();
        return View["pets.cshtml", allPets];
      };
      Post["/pets/{id}/{action}"] = parameters => {
        Pet pet = Pet.Find(parameters.id);
        if(pet.GetStatus() == "dead")
        {
          return View["/pet_dead.cshtml", pet];
        }
        else if(parameters.action == "feed")
        {
          pet.Feed();
          return View["/pet_feed.cshtml", pet];
        }
        else if(parameters.action == "play")
        {
          pet.Play();
          return View["/pet_play.cshtml", pet];
        }
        else
        {
          pet.Sleep();
          return View["/pet_sleep.cshtml", pet];
        }
      };
      Post["/pets/{id}/bury"] = parameters => {
        Pet pet = Pet.Find(parameters.id);
        pet.Bury();
        List<Pet> allPets = Pet.GetAll();
        return View["pets.cshtml", allPets];
      };
    }
  }
}
