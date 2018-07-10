using System;
using System.Linq;
using TourList.Dto;
using TourList.Service;
using TourList.Service.Interfaces;
using TourList.Service.Implementation;
using TourList.Data;
using TourList.Data.Interfaces;
using TourList.Data.Repositories;

namespace TourList.TestConsole
{
  class Program
  {
    static ITourService tourService;
    static IClientService clientService;
    static IExcursionService excursionService;
    static IExcursionSightService sightService;

    static void CreateData(TourListContext db)
    {
      clientService.Create(new ClientDto() { Id = Guid.NewGuid(), Name = "Andrey" });
      clientService.Create(new ClientDto() { Id = Guid.NewGuid(), Name = "Alexey" });
      clientService.Create(new ClientDto() { Id = Guid.NewGuid(), Name = "Artem" });
      clientService.Create(new ClientDto() { Id = Guid.NewGuid(), Name = "Denys" });
      clientService.Create(new ClientDto() { Id = Guid.NewGuid(), Name = "Ivan" });
      clientService.Create(new ClientDto() { Id = Guid.NewGuid(), Name = "Sergey" });

      excursionService.Create(new ExcursionDto() { Id = Guid.NewGuid(), Name = "Kiyv" });
      excursionService.Create(new ExcursionDto() { Id = Guid.NewGuid(), Name = "Kharkiv" });
      excursionService.Create(new ExcursionDto() { Id = Guid.NewGuid(), Name = "Lviv" });

      db.SaveChanges();

      var client1 = clientService.GetAll().FirstOrDefault(c => c.Name == "Artem");
      var client2 = clientService.GetAll().FirstOrDefault(c => c.Name == "Denys");
      var client3 = clientService.GetAll().FirstOrDefault(c => c.Name == "Sergey");

      var ex1 = excursionService.GetAll().FirstOrDefault(c => c.Name == "Kiyv");
      var ex2 = excursionService.GetAll().FirstOrDefault(c => c.Name == "Lviv");

      tourService.Create(new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 01), Client = client1, Excursion = ex1 });
      tourService.Create(new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 07, 23), Client = client2, Excursion = ex2 });
      tourService.Create(new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 09, 04), Client = client1, Excursion = ex2 });
      tourService.Create(new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 07, 15), Client = client3, Excursion = ex1 });

      db.SaveChanges();
    }

    static void Main(string[] args)
    {
      using (var db = new TourListContext())
      {
        tourService = new TourService(new TourRepository(db));
        clientService = new ClientService(new ClientRepository(db));
        excursionService = new ExcursionService(new ExcursionRepository(db));
        sightService = new ExcursionSightService(new ExcursionSightRepository(db));

        //CreateData(db);

        foreach (var tour in tourService.GetAll())
          Console.WriteLine($"{tour.Date}\t {tour.Client.Name}\t {tour.Excursion.Name}");

        Console.WriteLine(new string('=', 20));
      }

    }
  }
}
