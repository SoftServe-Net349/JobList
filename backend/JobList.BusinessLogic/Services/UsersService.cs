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

namespace JobList.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UsersService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int TotalRecords
        {
            get { return _uow.UsersRepository.TotalRecords; }
        }

        public Task<int> CountAsync(Expression<Func<User, bool>> predicate = null)
        {
            return _uow.UsersRepository.CountAsync(predicate);
        }

        public async Task<UserDTO> CreateEntityAsync(UserRequest modelRequest)
        {
            if (await _uow.UsersRepository.ExistAsync(u => u.Email == modelRequest.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "This email already exists!");
            }

            var entity = _mapper.Map<UserRequest, User>(modelRequest);

            entity = await _uow.UsersRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<User, UserDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.UsersRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<UserDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.UsersRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.City)
                                .Include(o => o.FavoriteVacancies)
                                .Include(o => o.Role));

            var dtos = _mapper.Map<List<User>, List<UserDTO>>(entities);

            return dtos;
        }

        public async Task<UserDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.UsersRepository.GetEntityAsync(id,
                 include: r => r.Include(o => o.City)
                                .Include(o => o.FavoriteVacancies)
                                .Include(o => o.Role));

            if (entity == null) return null;

            var dto = _mapper.Map<User, UserDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<UserDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery paginationUrlQuery = null)
        {
            var entities = await _uow.UsersRepository.GetRangeAsync(
                include: u => u.Include(c => c.City),
                paginationUrlQuery: paginationUrlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<User>, List<UserDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<UserDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null)
        {
            List<User> entities = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                entities = await _uow.UsersRepository.GetRangeAsync(
                    filter: e => e.Email.ToLower().Contains(searchString.ToLower()),
                    include: e => e.Include(c => c.City).Include(o => o.FavoriteVacancies).Include(o => o.Resumes),
                    sorting: GetSortField(sortingUrlQuery.SortField),
                    sortOrder: sortingUrlQuery.SortOrder,
                    paginationUrlQuery: paginationUrlQuery);
            }
            else
            {
                entities = await _uow.UsersRepository.GetRangeAsync(
                    include: e => e.Include(c => c.City).Include(o => o.FavoriteVacancies).Include(o => o.Resumes),
                    sorting: GetSortField(sortingUrlQuery.SortField),
                    sortOrder: sortingUrlQuery.SortOrder,
                    paginationUrlQuery: paginationUrlQuery);
            }

            var dtos = _mapper.Map<List<User>, List<UserDTO>>(entities);

            return dtos;
        }


        private Expression<Func<User, string>> GetSortField(string field)
        {
            switch (field)
            {
                case "Birthdate":
                    return e => e.BirthData.ToString();
                case "Email":
                    return e => e.Email;

                default: return null;
            }
        }


        public async Task<bool> UpdateEntityByIdAsync(UserRequest modelRequest, int id)
        {
            var entity = _mapper.Map<UserRequest, User>(modelRequest);
            entity.Id = id;

            var updated = await _uow.UsersRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
