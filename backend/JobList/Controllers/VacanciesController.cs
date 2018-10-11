using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : Controller
    {
        private IVacanciesService _vacanciesService;

        public VacanciesController(IVacanciesService vacanciesService)
        {
            _vacanciesService = vacanciesService;
        }

        // GET: /vacancies
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _vacanciesService.GetRangeOfEntitiesAsync(urlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = urlQuery.PageNumber,
                PageSize = urlQuery.PageSize,
                TotalRecords = _vacanciesService.Count
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [HttpGet("search")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get(string search, string city, [FromQuery]PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _vacanciesService.GetAllEntitiesAsync();

            if (dtos == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(search))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.Name.ToLower()
                    .Contains(search.ToLower()));
            }
            if(!string.IsNullOrEmpty(city))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.City.Name == city);
            }

            if(urlQuery != null)
            {
                int count = dtos.Count();
                dtos = dtos.Skip(urlQuery.PageSize * (urlQuery.PageNumber - 1))
                    .Take(urlQuery.PageSize);

                var pageInfo = new PageInfo()
                {
                    PageNumber = urlQuery.PageNumber,
                    PageSize = urlQuery.PageSize,
                    TotalRecords = count
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }
        [HttpGet("filter")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetVacanciesByFilter([FromQuery]Vacancy vacancy)
        {
            var dtos = await _vacanciesService.GetAllEntitiesAsync();

            if (dtos == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(vacancy.workArea))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.WorkArea.Name == vacancy.workArea);
            }
            if (!(vacancy.namesOfCompanies == null))
            {
                dtos = from x in dtos
                       where vacancy.namesOfCompanies.Contains(x.Recruiter.Company.Name)
                       select x;
            }
            if (!(vacancy == null))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.IsChecked == vacancy.isChecked);
            }
            if (!string.IsNullOrEmpty(vacancy.typeOfEmployment))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.FullPartTime == vacancy.typeOfEmployment);
            }
            if(!(vacancy == null))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.Salary >= vacancy.salary);
            }
            if (!string.IsNullOrEmpty(vacancy.city))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.City.Name == vacancy.city);
            }
            

            return Ok(dtos);
        }

        [HttpGet("recruiter/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetVacanciesByRecruiterId(int id)
        {
            var dtos = await _vacanciesService.GetVacanciesByRectuiterId(id);
            if (!dtos.Any())
            {
                return NoContent();
            }
            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<VacancyDTO>> GetById(int id)
        {
            var dto = await _vacanciesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /vacancies
        [HttpPost]
        public virtual async Task<ActionResult<VacancyDTO>> Create([FromBody] VacancyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _vacanciesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /vacancies/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]VacancyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _vacanciesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /vacancies/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _vacanciesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
    public class Vacancy
    {
        public string workArea { get; set; }
        public string[] namesOfCompanies { get; set; }
        public bool isChecked { get; set; }
        public string typeOfEmployment { get; set; }
        public decimal salary { get; set; }
        public string city { get; set; }
    }
}
