using System.Collections.Generic;

namespace Tamagotchi.Objects
{
  public class Pet
  {
    private string _petName;
    private string _status;
    private int _food;
    private int _play;
    private int _sleep;
    private int _id;
    private static List<Pet> _instances = new List<Pet> {};

    public Pet (string petName, int food = 100, int play = 80, int sleep = 100)
    {
      _petName = petName;
      _status = "alive";
      _food = food;
      _play = play;
      _sleep = sleep;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetPetName()
    {
      return _petName;
    }
    public void SetPetName(string newPetName)
    {
      _petName = newPetName;
    }
    public string GetStatus()
    {
      return _status;
    }
    public int GetFood()
    {
      return _food;
    }
    public void SetFood(int newFood)
    {
      _food = newFood;
    }
    public int GetPlay()
    {
      return _play;
    }
    public void SetPlay(int newPlay)
    {
      _play = newPlay;
    }
    public int GetSleep()
    {
      return _sleep;
    }
    public void SetSleep(int newSleep)
    {
      _sleep = newSleep;
    }
    public int Play()
    {
      Pet.TimePass();
      if(_play <= 75)
      {
        _play += 25;
      }
      else
      {
        _play = 100;
      }
      return _play;
    }
    public int Sleep()
    {
      Pet.TimePass();
      if(_sleep <= 75)
      {
        _sleep += 25;
      }
      else
      {
        _sleep = 100;
      }
      return _sleep;
    }
    public int Feed()
    {
      Pet.TimePass();
      if(_food <= 75)
      {
        _food += 25;
      }
      else
      {
        _food = 100;
      }
      return _food;
    }
    public int GetId()
    {
      return _id;
    }
    public void Bury()
    {
      _instances.Remove(this);
    }
    public static void TimePass()
    {
      foreach(var pet in _instances)
      {
        pet._food -= 5;
        pet._sleep -= 5;
        pet._play -=5;
        if(pet._food <= 0)
        {
          pet._status = "dead";
        }
        if(pet._sleep <= 0)
        {
          pet._status = "dead";
        }
        if(pet._play <= 0)
        {
          pet._status = "dead";
        }
        if(pet._status == "dead")
        {
          pet._food = 0;
          pet._sleep = 0;
          pet._play = 0;
        }
      }
    }
    public static List<Pet> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
