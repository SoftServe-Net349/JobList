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
using System.Linq;
using System.Threading.Tasks;

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

        public int Count { get { return _uow.UsersRepository.Count; } }


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

        public async Task<IEnumerable<UserDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null)
        {
            var entities = await _uow.UsersRepository.GetAllEntitiesAsync(
                include: r => r.Include(o => o.City)
                    .Include(o => o.FavoriteVacancies)
                    .Include(o => o.Resumes));


            if (!string.IsNullOrEmpty(searchString))
            {
                entities = entities.Select(e => e)
                    .Where(d => d.Email.ToLower()
                    .Contains(searchString.ToLower()))
                    .ToList();
            }


            if (!string.IsNullOrEmpty(sortingUrlQuery.SortField))
            {
                switch (sortingUrlQuery.SortField)
                {
                    case "email":
                        if (sortingUrlQuery.SortOrder)
                            entities = entities.OrderBy(e => e.Email).ToList();
                        else
                            entities = entities.OrderByDescending(e => e.Email).ToList();
                        break;

                    case "birthdate":
                        if (sortingUrlQuery.SortOrder)
                            entities = entities.OrderBy(e => e.BirthData).ToList();
                        else
                            entities = entities.OrderByDescending(e => e.BirthData).ToList();
                        break;

                    default: break;
                }
            }

            var dtos = _mapper.Map<List<User>, List<UserDTO>>(entities);

            return dtos;
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
