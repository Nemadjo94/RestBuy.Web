using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestBuy.Application.Services.Queries;
using RestBuy.Application.Services.Repos;
using RestBuy.Application.ViewModel;

namespace RestBuy.Application.Services.Core
{
    public class RestBuyRegistrationService : IRegistrationService
    {
        readonly IUserRepo userRepo;
        readonly IUoW uow;

        public RestBuyRegistrationService(IUoW uow, IUserRepo userRepo)
        {
            this.userRepo = userRepo;
            this.uow = uow;
        }


        public async Task RegisterUser(NewUserViewModel newUserViewModel, CancellationToken token = default)
        {
            var v = new ValidationContext(newUserViewModel);
            Validator.ValidateObject(newUserViewModel, v);

            var userList = await this.userRepo.ListAsync(
                new UserExistsQuery(newUserViewModel.Username));

            if(userList.Count > 0)
            {
                throw new ValidationException("This user name already exists");
            }
            else
            {
                var user = newUserViewModel.CreateUser();
                await this.userRepo.AddAsync(user, token);
                await uow.SaveChangesAsync(token);
            }
        }
    }
}
