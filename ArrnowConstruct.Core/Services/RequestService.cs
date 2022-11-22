using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Models.Request;
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

        public RequestService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> ConstructorWithEmailExists(string email)
        {
            var user = await repo.AllReadonly<User>()
                .FirstOrDefaultAsync(u => u.Email == email);

            if(user != null)
            {
                Constructor constructor = await repo.All<Constructor>()
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

                if(constructor != null)
                {
                    return constructor.Id;
                }
            }

            return -1;
        }

        public async Task<int> Create(AddRequestViewModel model, int clientId)
        {
            int constructorId = await this.ConstructorWithEmailExists(model.ConstructorEmail);


            var request = new Request()
            {
                RoomsCount = model.RoomsCount,
                Area = model.Area,
                RequiredDate = DateTime.ParseExact(model.RequiredDate, "yyyy-MM-dd",CultureInfo.CurrentCulture).ToString("yyyy-MM-dd"),
                Budget = model.Budget,
                Status = "Waiting",
                ClientId = clientId,
                ConstructorId = constructorId,
                //RoomsTypes = model.CategoryId
            };

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();

            return request.Id;
        }
    }
}
