using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using JobList.Common.Extensions;
using JobList.Common.UrlQuery;
using System.Security.Cryptography;

namespace JobList.BusinessLogic.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EmployeesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int TotalRecords
        {
            get { return _uow.EmployeesRepository.TotalRecords; }
        }

        public Task<int> CountAsync(Expression<Func<Employee, bool>> predicate = null)
        {
            return _uow.EmployeesRepository.CountAsync(predicate);
        }

        public async Task<EmployeeDTO> CreateEntityAsync(EmployeeRequest modelRequest)
        {
            if (await _uow.EmployeesRepository.ExistAsync(u => u.Email == modelRequest.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "This email already exists!");
            }

            var entity = _mapper.Map<EmployeeRequest, Employee>(modelRequest);
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var hashedPassword = new Rfc2898DeriveBytes(modelRequest.Password, salt, 1000);
            byte[] bytesFromHashedPassw = hashedPassword.GetBytes(20);
            byte[] arrayOfHashedBytes = new byte[36];
            Array.Copy(salt, 0, arrayOfHashedBytes, 0, 16);
            Array.Copy(bytesFromHashedPassw, 0, arrayOfHashedBytes, 16, 20);
            entity.Password = Convert.ToBase64String(arrayOfHashedBytes);

            entity = await _uow.EmployeesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Employee, EmployeeDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.EmployeesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.EmployeesRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.City)
                                .Include(o => o.FavoriteVacancies)
                                .Include(o => o.Role));

            var dtos = _mapper.Map<List<Employee>, List<EmployeeDTO>>(entities);

            return dtos;
        }

        public async Task<EmployeeDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.EmployeesRepository.GetEntityAsync(id,
                 include: r => r.Include(o => o.City)
                                .Include(o => o.FavoriteVacancies)
                                .Include(o => o.Role));

            if (entity == null) return null;

            var dto = _mapper.Map<Employee, EmployeeDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery paginationUrlQuery = null)
        {
            var entities = await _uow.EmployeesRepository.GetRangeAsync(
                include: u => u.Include(c => c.City),
                paginationUrlQuery: paginationUrlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Employee>, List<EmployeeDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetFilteredEntitiesAsync(SearchingUrlQuery searchingUrlQuery, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null)
        {
            Expression<Func<Employee, bool>> filter = e => true;

            if (!string.IsNullOrEmpty(searchingUrlQuery.SearchString))
            {
                filter = filter.And(GetSearchField(searchingUrlQuery));
            }

            var entities = await _uow.EmployeesRepository.GetRangeAsync(
                filter: filter,
                include: e => e.Include(c => c.City).Include(o => o.FavoriteVacancies).Include(o => o.Resumes),
                sorting: GetSortField(sortingUrlQuery.SortField),
                sortOrder: sortingUrlQuery.SortOrder,
                paginationUrlQuery: paginationUrlQuery);


            var dtos = _mapper.Map<List<Employee>, List<EmployeeDTO>>(entities);

            return dtos;
        }

        private Expression<Func<Employee, string>> GetSortField(string field)
        {
            switch (field)
            {
                case "birthDate":
                    return e => e.BirthDate.ToString();
                case "email":
                    return e => e.Email;

                default: return null;
            }
        }

        private Expression<Func<Employee, bool>> GetSearchField(SearchingUrlQuery searchingUrlQuery)
        {
            switch (searchingUrlQuery.SearchField)
            {
                case "firstName":
                    return e => e.FirstName.Contains(searchingUrlQuery.SearchString);
                case "lastName":
                    return e => e.LastName.Contains(searchingUrlQuery.SearchString);
                case "email":
                    return e => e.Email.Contains(searchingUrlQuery.SearchString);

                default: return null;
            }
        }

        public async Task<bool> ExistAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _uow.EmployeesRepository.ExistAsync(predicate);
        }

        public async Task<bool> UpdateEntityByIdAsync(EmployeeUpdateRequest modelRequest, int id)
        {
            var entity = _mapper.Map<EmployeeUpdateRequest, Employee>(modelRequest);
            entity.Id = id;

            var updated = await _uow.EmployeesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<bool> ResetPasswordEntityByIdAsync(EmployeeResetPasswordRequest modelRequest, int id)
        {
            var entity = await _uow.EmployeesRepository.GetFirstOrDefaultAsync(
                filter: u => u.Id == id,
                  include: r => r.Include(o => o.Role));

            byte[] hashPasswordFromDB = Convert.FromBase64String(entity.Password);
            byte[] salt = new byte[16];
            Array.Copy(hashPasswordFromDB, 0, salt, 0, 16);
            var hashRequestPassword = new Rfc2898DeriveBytes(modelRequest.CurrentPassword, salt, 1000);
            byte[] bytesFromHashRequest = hashRequestPassword.GetBytes(20);
            bool flag = false;
            for (int i = 0; i < 20; i++)
            {
                if (hashPasswordFromDB[i + 16] == bytesFromHashRequest[i])
                {
                    flag = true;
                }
                else break;

            }
            if (flag==true)
            {
                byte[] newSalt;
                new RNGCryptoServiceProvider().GetBytes(newSalt = new byte[16]);
                var hashedPassword = new Rfc2898DeriveBytes(modelRequest.NewPassword, newSalt, 1000);
                byte[] bytesFromHashedPassw = hashedPassword.GetBytes(20);
                byte[] arrayOfHashedBytes = new byte[36];
                Array.Copy(newSalt, 0, arrayOfHashedBytes, 0, 16);
                Array.Copy(bytesFromHashedPassw, 0, arrayOfHashedBytes, 16, 20);
                entity.Password = Convert.ToBase64String(arrayOfHashedBytes);
               
            }
            if(flag==false)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Recent Password doesnt match");
            }
   
            var result = await _uow.SaveAsync();
            return result;
            
        }
    }
}
