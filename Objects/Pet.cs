using System.Collections.Generic;

namespace Tamagotchi.Objects
{
  public class Pet
  {
    private string _petName;
    private int _food;
    private int _play;
    private int _sleep;
    private int _id;
    private static List<Pet> _instances = new List<Pet> {};

    public Pet (string petName, int food = 100, int play = 80, int sleep = 100)
    {
      _petName = petName;
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
