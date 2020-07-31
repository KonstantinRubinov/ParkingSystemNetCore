using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class TeacherApiController : ControllerBase
	{
		private ITeacherRepository teacherRepository;

		public TeacherApiController(ITeacherRepository _teacherRepository)
		{
			teacherRepository = _teacherRepository;
		}

		[HttpGet("teachers")]
		public IActionResult GetAllTeachers()
		{
			try
			{
				List<TeacherModel> allTeachers = teacherRepository.GetAllTeachers();
				return Ok(allTeachers);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("teachers/{teacherId}")]
		public IActionResult GetOneTeacherById(string teacherId)
		{
			try
			{
				TeacherModel teacherModel = teacherRepository.GetOneTeacherById(teacherId);
				return Ok(teacherModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("teachers")]
		public IActionResult AddTeacher(TeacherModel teacherModel)
		{
			try
			{
				if (teacherModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				TeacherModel addedTeacher = teacherRepository.AddTeacher(teacherModel);
				return StatusCode(StatusCodes.Status201Created, addedTeacher);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("teachers/{teacherId}")]
		public IActionResult UpdateTeacher(string teacherId, TeacherModel teacherModel)
		{
			try
			{
				if (teacherModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				teacherModel.teacherId = teacherId;
				TeacherModel updatedTeacher = teacherRepository.UpdateTeacher(teacherModel);
				return Ok(updatedTeacher);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("teachers/{teacherId}")]
		public IActionResult DeleteTeacher(string teacherId)
		{
			try
			{
				int i = teacherRepository.DeleteTeacher(teacherId);
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
