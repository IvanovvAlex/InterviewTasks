using Azure;
using Azure.Core;
using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JsonSerializerOptions _serializerOptions;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Company> Create(string request)
        {
            Company company = JsonSerializer.Deserialize<Company>(request, _serializerOptions);

            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.CommitAsync();
            return company;
        }

        public async Task Delete(string id)
        {
            Company company = await GetById(id);
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _unitOfWork.Companies.GetAllAsync();
        }

        public async Task<Company> GetById(string id)
        {
            return await _unitOfWork.Companies.GetByIdAsync(id);
        }

        public async Task<Company> Update(string request)
        {
            Company company = JsonSerializer.Deserialize<Company>(request, _serializerOptions);

            await _unitOfWork.Companies.Update(company);
            await _unitOfWork.CommitAsync();
            return company;
        }
    }
}
