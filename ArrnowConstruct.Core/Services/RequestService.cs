using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Exceptions;
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
            return await repo.All<Request>()
                .Where(r => r.ClientId == id
                && r.Client.User.IsActive == true
                && r.Constructor.User.IsActive == true 
                && r.IsActive == true)
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
            return await repo.All<Request>()
                .Where(r => r.IsActive == true && r.Status == "Waiting")
                .Where(r => r.ConstructorId == id && r.Constructor.User.IsActive == true && r.Client.User.IsActive == true)
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

            if (constructorId == -1)
            {
                throw new NullReferenceException(GlobalExceptions.ConstructorDoesNotExistExceptionMessage);
            }

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
            var request = await repo.All<Request>()
                .Include(r => r.RoomsTypes)
                .FirstOrDefaultAsync(r => r.Id == requestId &&
                r.Constructor.User.IsActive == true &&
                r.Client.User.IsActive);

            if (request == null || request.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            var requestCategories = request.RoomsTypes.ToList();
            while (requestCategories.Any())
            {
                request.RoomsTypes.Remove(requestCategories[0]);
                requestCategories.RemoveAt(0);
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
             .FirstOrDefaultAsync();


            if (request == null)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            return request;
        }

        public async Task Delete(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            if (request == null)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            if (request.IsActive == false)
            {
                throw new ArgumentException(GlobalExceptions.RequestAlreadyDeleted);
            }

            request.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<string> GetStatus(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            if (request == null)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

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
              .FirstOrDefaultAsync();


            if (request == null)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            return request;
        }

        public async Task Reject(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            if (request == null || request.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            if (request.Status == "Rejected")
            {
                throw new ArgumentException(GlobalExceptions.RequestAlreadyRejected);
            }

            request.Status = "Rejected";

            await repo.SaveChangesAsync();
        }

        public async Task Confirm(int requestId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            if (request == null || request.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            if (request.Status == "Confirmed")
            {
                throw new ArgumentException(GlobalExceptions.RequestAlreadyConfirmed);
            }

            request.Status = "Confirmed";

            await repo.SaveChangesAsync();
        }

        public async Task<bool> HasClient(int requestId, string userId)
        {
            var request = await repo.GetByIdAsync<Request>(requestId);

            if (request == null || request.IsActive == false)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            var clientId = await clientService.GetClientId(userId);

            return request.ClientId == clientId;
        }

        public async Task<int> GetRequestsConstructorId(int id)
        {
            var request = await repo.GetByIdAsync<Request>(id);

            if (request == null)
            {
                throw new NullReferenceException(GlobalExceptions.RequestDoesNotExistExceptionMessage);
            }

            return request.ConstructorId;
        }
    }
}
