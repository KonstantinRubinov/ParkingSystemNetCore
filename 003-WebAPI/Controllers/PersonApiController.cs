using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class PersonApiController : ControllerBase
	{
		private IPersonRepository personRepository;
		private IStudentRepository studentRepository;
		private ITeacherRepository teacherRepository;

		public PersonApiController(IPersonRepository _personRepository, IStudentRepository _studentRepository, ITeacherRepository _teacherRepository)
		{
			personRepository = _personRepository;
			studentRepository = _studentRepository;
			teacherRepository = _teacherRepository;
		}

		[HttpGet("persons")]
		public IActionResult GetAllPerson()
		{
			try
			{
				List<PersonModel> allPersons = personRepository.GetAllPersons();
				return Ok(allPersons);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}


		[HttpGet("persons/id")]
		public IActionResult GetAllPersonsId()
		{
			try
			{
				List<PersonModel> allPersonsId = personRepository.GetAllPersonsId();
				return Ok(allPersonsId);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}



		[HttpDelete("persons/{personId}")]
		public IActionResult DeletePerson(string personId)
		{
			try
			{
				int i = personRepository.DeletePerson(personId);
				if (i > 0)
				{
					return NoContent();
				}
				return StatusCode(StatusCodes.Status500InternalServerError);

			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("persons/{personId}")]
		public IActionResult GetOnePersonById(string personId)
		{
			try
			{
				PersonModel personModel = studentRepository.GetOneStudentById(personId);
				if (personModel == null)
				{
					personModel = teacherRepository.GetOneTeacherById(personId);
				}
				if (personModel == null)
				{
					return NotFound("The person record couldn't be found.");
				}
				return Ok(personModel);
			}

			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}
	}
}
