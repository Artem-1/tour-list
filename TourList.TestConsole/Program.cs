using System;
using System.Linq;
using TourList.Data;
using TourList.Data.Repositories;
using TourList.Dto;
using TourList.Service.Implementation;
using TourList.Service.Interfaces;

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
      var client1 = new ClientDto() { Id = Guid.NewGuid(), Name = "Alexandr" };
      var client2 = new ClientDto() { Id = Guid.NewGuid(), Name = "Roman" };

      var ex1 = new ExcursionDto() { Id = Guid.NewGuid(), Name = "Kiyv" };
      var ex2 = new ExcursionDto() { Id = Guid.NewGuid(), Name = "Kharkiv" };

      var tour1 = new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 01), Client = client1, Excursion = ex1 };
      var tour2 = new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 01), Client = client2, Excursion = ex1 };
      var tour3 = new TourDto() { Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 01), Client = client1, Excursion = ex2 };

      tourService.Create(tour1);
      tourService.Create(tour2);
      tourService.Create(tour3);

      db.SaveChanges();
    }

    static void Main(string[] args)
    {
      using (var db = new TourListContext())
      {
        var unitwork = new RepositoryInject(db);

        tourService = new TourService(unitwork);
        clientService = new ClientService(unitwork);
        excursionService = new ExcursionService(unitwork);
        sightService = new ExcursionSightService(unitwork);

        //CreateData(db);

        foreach (var tour in tourService.GetAll())
          Console.WriteLine($"{tour.Date}\t {tour.Client.Name}\t {tour.Excursion.Name}");

        Console.WriteLine(new string('=', 40));

        foreach (var client in clientService.GetAll())
          Console.WriteLine($"{client.Name}, {client.Id}");

        Console.WriteLine(new string('=', 40));

        foreach (var ex in excursionService.GetAll())
          Console.WriteLine($"{ex.Name}, {ex.Id}");
      }
    }
  }
}
