using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourceAPI.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourceAPI.Controllers
{  
    
    [ApiController]
    [Route("api/Authers")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;
         public AuthorsController(ICourseLibraryRepository courseLibraryRepository , IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
        }

        [HttpGet()]      
        public ActionResult<IEnumerable<AuthorDto>> GetAuthers()
        {
            var authersFormRepo = _courseLibraryRepository.GetAuthors();
            // var authers = new List<AuthorDto>();
            //foreach (var item in authersFormRepo)
            //{
            //    authers.Add(new AuthorDto()
            //    {
            //        Id = item.Id,
            //        Name = $" {item.FirstName} {item.LastName} "  
            //    }); 
            //}

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authersFormRepo));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _courseLibraryRepository.GetAuthor(authorId);
            if (author == null)
                return NotFound();
            else
            return Ok(_mapper.Map<AuthorDto>( author));
        }
        
      
    }
}