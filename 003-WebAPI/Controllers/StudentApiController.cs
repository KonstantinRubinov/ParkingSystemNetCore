using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class StudentApiController : ControllerBase
	{
		private IStudentRepository studentRepository;

		public StudentApiController(IStudentRepository _studentRepository)
		{
			studentRepository = _studentRepository;
		}

		[HttpGet("students")]
		public IActionResult GetAllStudents()
		{
			try
			{
				List<StudentModel> allStudents = studentRepository.GetAllStudents();
				return Ok(allStudents);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("students/{studentId}")]
		public IActionResult GetOneStudentById(string studentId)
		{
			try
			{
				StudentModel studentModel = studentRepository.GetOneStudentById(studentId);
				return Ok(studentModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("students")]
		public IActionResult AddStudent(StudentModel studentModel)
		{
			try
			{
				if (studentModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				StudentModel addedStudent = studentRepository.AddStudent(studentModel);
				return StatusCode(StatusCodes.Status201Created, addedStudent);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("students/{studentId}")]
		public IActionResult UpdateStudent(string studentId, StudentModel studentModel)
		{
			try
			{
				if (studentModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				studentModel.studentId = studentId;
				StudentModel updatedStudent = studentRepository.UpdateStudent(studentModel);
				return Ok(updatedStudent);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("students/{studentId}")]
		public IActionResult DeleteStudent(string studentId)
		{
			try
			{
				int i = studentRepository.DeleteStudent(studentId);
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
	}
}
