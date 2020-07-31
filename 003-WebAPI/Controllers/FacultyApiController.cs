using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class FacultyApiController : ControllerBase
	{
		private IFacultyRepository facultyRepository;

		public FacultyApiController(IFacultyRepository _facultyRepository)
		{
			facultyRepository = _facultyRepository;
		}

		[HttpGet("faculties")]
		public IActionResult GetAllFaculties()
		{
			try
			{
				List<FacultyModel> allFaculties = facultyRepository.GetAllFaculties();
				return Ok(allFaculties);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("faculties/{facultyCode}")]
		public IActionResult GetOneFacultyByCode(string facultyCode)
		{
			try
			{
				FacultyModel facultyModel = facultyRepository.GetOneFacultyByCode(facultyCode);
				return Ok(facultyModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("faculties")]
		public IActionResult AddFaculty(FacultyModel facultyModel)
		{
			try
			{
				if (facultyModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				FacultyModel addedFaculty = facultyRepository.AddFaculty(facultyModel);
				return StatusCode(StatusCodes.Status201Created, addedFaculty);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("faculties/{facultyCode}")]
		public IActionResult UpdateFaculty(string facultyCode, FacultyModel facultyModel)
		{
			try
			{
				if (facultyModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				facultyModel.facultyCode = facultyCode;
				FacultyModel updatedFaculty = facultyRepository.UpdateFaculty(facultyModel);
				return Ok(updatedFaculty);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("faculties/{facultyCode}")]
		public IActionResult DeleteFaculty(string facultyCode)
		{
			try
			{
				int i = facultyRepository.DeleteFaculty(facultyCode);
				return NoContent();
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}
	}
}
