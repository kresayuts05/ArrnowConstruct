using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Models.Request;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository repo;
        private readonly ICategoryService categoryService;
        private readonly IConstructorService constructorService;
        private readonly IClientService clientService;

        public RequestService(
            IRepository _repo,
            ICategoryService _categoryService,
            IConstructorService _constructorService,
            IClientService _clientService)
        {
            repo = _repo;
            categoryService = _categoryService; 
            constructorService = _constructorService;
            clientService = _clientService;
        }

        public async Task<IEnumerable<RequestViewModel>> AllRequestsByClientId(int id)
        {
            //   var user = await clientService.GetUserByClientId(id);

            return await repo.All<Request>()
                .Where(r => r.IsActive == true)
                .Where(r => r.ClientId == id)
                .OrderByDescending(r => r.Id)
                .Select(r => new RequestViewModel
                {
                    Id = r.Id,
                    RoomsCount = r.RoomsCount,
                    Area = r.Area,
                    RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                    Status = r.Status,
                    Budget = r.Budget,
                    RoomsTypes = new List<CategoryModel>
                    (r.RoomsTypes.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name }).ToList()),
                    Client = new ClientModel()
                    {
                        ClientId = r.ClientId,
                        User = new UserModel()
                        {
                            Email = r.Client.User.Email,
                            Address = $"Country: {r.Client.User.Address},{Environment.NewLine} City: {r.Client.User.Address},{Environment.NewLine} Street: {r.Client.User.Address}"
                        }
                    },
                    Constructor = new ConstructorModel()
                    {
                        ConstructorId = r.ConstructorId,
                        User = new UserModel()
                        {
                            Email = r.Constructor.User.Email
                        }
                    },
                    IsActive = r.IsActive
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RequestViewModel>> AllRequestsForConstructorById(int id)
        {
            //   var user = await clientService.GetUserByClientId(id);

            return await repo.All<Request>()
                .Where(r => r.IsActive == true && r.Status == "Waiting")
                .Where(r => r.ConstructorId == id)
                .OrderByDescending(r => r.Id)
                .Select(r => new RequestViewModel
                {
                    Id = r.Id,
                    RoomsCount = r.RoomsCount,
                    Area = r.Area,
                    RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                    Status = r.Status,
                    Budget = r.Budget,
                    RoomsTypes = new List<CategoryModel>
                    (r.RoomsTypes.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name }).ToList()),
                    Client = new ClientModel()
                    {
                        ClientId = r.ClientId,
                        User = new UserModel()
                        {
                            Email = r.Client.User.Email,
                            Address = $"Country: {r.Client.User.Address},{Environment.NewLine} City: {r.Client.User.Address},{Environment.NewLine} Street: {r.Client.User.Address}"
                        }
                    },
                    Constructor = new ConstructorModel()
                    {
                        ConstructorId = r.ConstructorId,
                        User = new UserModel()
                        {
                            Email = r.Constructor.User.Email
                        }
                    },
                    IsActive = r.IsActive
                })
                .ToListAsync();
        }

        public async Task Create(AddRequestViewModel model, int clientId)
        {
            int constructorId = await constructorService.ConstructorWithEmailExists(model.ConstructorEmail);
            var categories = await categoryService.CategoriesById(model.CategoryId);

            var request = new Request()
            {
                RoomsCount = model.RoomsCount,
                Area = model.Area,
                RequiredDate = DateTime.ParseExact(model.RequiredDate, "yyyy-MM-dd", CultureInfo.CurrentCulture),
                Budget = model.Budget,
                Status = "Waiting",
                ClientId = clientId,
                ConstructorId = constructorId,
                RoomsTypes = categories.ToList(),
                IsActive = true
            };

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();
        }

        public async Task Edit(int requestId, AddRequestViewModel model)
        {
          //  var request = await repo.GetByIdAsync<Request>(requestId);

            var request = await repo.All<Request>()
                .Include(r => r.RoomsTypes)
                .Where(r => r.Id == requestId)
                .FirstAsync();

            foreach (var categ in request.RoomsTypes)
            {
                request.RoomsTypes.Remove(categ);
            }

            await repo.SaveChangesAsync();

            var categories = await categoryService.CategoriesById(model.CategoryId);

            request.RoomsCount = model.RoomsCount;
            request.Area = model.Area;
            request.RequiredDate = DateTime.ParseExact(model.RequiredDate, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            request.Budget = model.Budget;
            request.RoomsTypes = categories.ToList();

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Request>()
                .AnyAsync(r => r.Id == id && r.Status == "Waiting" && r.IsActive == true);
        }

        public async Task<AddRequestViewModel> RequestById(int id)
        {
            var request = await repo.All<Request>()
             .Where(r => r.IsActive == true)
             .Where(r => r.Id == id)
             .Select(r => new AddRequestViewModel()
             {
                 Id = r.Id,
                 ClientId = r.ClientId,
                 RoomsCount = r.RoomsCount,
                 Area = r.Area,
                 RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                 Budget = r.Budget,
                 ConstructorEmail = r.Constructor.User.Email,
                 RoomsTypes = new List<CategoryModel>
                 (r.RoomsTypes.Select(r => new CategoryModel() { Id = r.Id, Name = r.Name }).ToList()),
                 IsActive = r.IsActive
             })
             .FirstAsync();

            return request;
        }


        public async Task Delete(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            request.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<string> GetStatus(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            return request.Status;
        }

        public async Task<RequestViewModel> GetDetailsRequest(int id)
        {
            var request = await repo.All<Request>()
              .Where(r => r.IsActive == true && r.Status == "Waiting")
              .Where(r => r.Id == id)
              .Select(r => new RequestViewModel()
              {
                  Id = r.Id,
                  RoomsCount = r.RoomsCount,
                  Area = r.Area,
                  RequiredDate = r.RequiredDate.ToString("yyyy-MM-dd"),
                  Budget = r.Budget,
                  CategoryId = r.RoomsTypes.Select(c => c.Id).ToList(),
                  RoomsTypes = r.RoomsTypes.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name }).ToList(),
                  Client = new ClientModel()
                  {
                      ClientId = r.ClientId,
                      User = new UserModel()
                      {
                          Email = r.Client.User.Email,
                          Address = $"Country: {r.Client.User.Address},{Environment.NewLine} City: {r.Client.User.Address},{Environment.NewLine} Street: {r.Client.User.Address}"
                      }
                  },
                  Constructor = new ConstructorModel()
                  {
                      ConstructorId = r.ConstructorId,
                      User = new UserModel()
                      {
                          Email = r.Constructor.User.Email
                      }
                  },
                  IsActive = r.IsActive
              })
              .FirstAsync();

            return request;
        }

        public async Task Reject(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            request.Status = "Rejected";

            await repo.SaveChangesAsync();
        }

        public async Task Confirm(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            request.Status = "Confirmed";

            await repo.SaveChangesAsync();
        }

        public async Task<bool> HasClient(int requestId, string userId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);
            var clientId = await clientService.GetClientId(userId);

            return request.ClientId == clientId;
        }

        public async Task<int> GetRequestsConstructorId(int id)
        {
            var request = await repo.GetByIdAsync<Request>(id);

            return request.ConstructorId;
        }
    }
}
