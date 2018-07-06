using System;
using System.Linq;
using TourList.Dto;
using TourList.RepoService;
using TourList.RepoService.Interfaces;
using TourList.RepoService.Repositories;

namespace TourList.TestConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var db = new TourListContext())
      {
        ITourRepository tourRepo = new TourRepository(db);
        IClientRepository clientRepo = new ClientRepository(db);

        tourRepo.Create(new TourDto(){ Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 01)});
        tourRepo.Create(new TourDto(){ Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 21)});
        tourRepo.Create(new TourDto(){ Id = Guid.NewGuid(), Date = new DateTime(2018, 08, 14)});

        clientRepo.Create(new ClientDto(){ Id = Guid.NewGuid(), Name = "Andrey"});
        clientRepo.Create(new ClientDto(){ Id = Guid.NewGuid(), Name = "Alexey"});
        clientRepo.Create(new ClientDto(){ Id = Guid.NewGuid(), Name = "Artem"});
        clientRepo.Create(new ClientDto(){ Id = Guid.NewGuid(), Name = "Denys"});
        clientRepo.Create(new ClientDto(){ Id = Guid.NewGuid(), Name = "Ivan"});
        clientRepo.Create(new ClientDto(){ Id = Guid.NewGuid(), Name = "Sergey"});

        //db.SaveChanges();

        var tour = tourRepo.GetAll().FirstOrDefault(t => t.Date == new DateTime(2018, 08, 01));
        var client = clientRepo.GetAll().FirstOrDefault(c => c.Name == "Artem");
        
        tourRepo.AddClient(tour.Id, client.Id);
        db.SaveChanges();
      }
        
    }
  }
}
