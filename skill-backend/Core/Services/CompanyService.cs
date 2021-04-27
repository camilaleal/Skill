using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;

namespace Core.Services
{
    public class CompanyService : ICompanyService
    {
        public readonly ICompanyRepository _repository;
        public readonly IUserService _userService;
        public readonly IJobRepository _jobRepository;

        public CompanyService(ICompanyRepository repository, IUserService userService, IJobRepository jobRepository)
        {
            _repository = repository;
            _userService = userService;
            _jobRepository = jobRepository;
        }

        public Company Get(long id)
        {
            var Company = _repository.Get(id);

            if (Company != null)
            {
                Company.JobsCount = _jobRepository.GetAll().Where(x => x.IdCompany == id).Count();
                Company.Jobs = _jobRepository.GetAll().Where(x => x.IdCompany == id).ToList();
            }

            return Company;
        }

        public List<Company> GetAll()
        {
            var Companys = _repository.GetAll();

            if (Companys != null)
            {
                foreach (var Company in Companys)
                {
                    Company.JobsCount = _jobRepository.GetAll().Where(x => x.IdCompany == Company.Id).Count();
                    Company.Jobs = _jobRepository.GetAll().Where(x => x.IdCompany == Company.Id).ToList();
                }
            }

            return Companys;
        }

        public Company Insert(Company entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(long id, Company entity)
        {
            _repository.Update(id, entity);
        }

        public void Delete(long id)
        {
            _repository.DeleteLogical(id);
        }
    }
}
