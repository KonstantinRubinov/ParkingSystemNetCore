using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class CourseApiController : ControllerBase
	{
		private ICourseRepository courseRepository;

		public CourseApiController(ICourseRepository _courseRepository)
		{
			courseRepository = _courseRepository;
		}

		[HttpGet("courses")]
		public IActionResult GetAllCourses()
		{
			try
			{
				List<CourseModel> allCourses = courseRepository.GetAllCourses();
				return Ok(allCourses);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("courses/{courseCode}")]
		public IActionResult GetOneCourseByCode(string courseCode)
		{
			try
			{
				CourseModel courseModel = courseRepository.GetOneCourseByCode(courseCode);
				return Ok(courseModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("courses")]
		public IActionResult AddCourse(CourseModel courseModel)
		{
			try
			{
				if (courseModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				CourseModel addedCourse = courseRepository.AddCourse(courseModel);
				return StatusCode(StatusCodes.Status201Created, addedCourse);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("courses/{courseCode}")]
		public IActionResult UpdateCourse(string courseCode, CourseModel courseModel)
		{
			try
			{
				if (courseModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				courseModel.courseCode = courseCode;
				CourseModel updatedCourse = courseRepository.UpdateCourse(courseModel);
				return Ok(updatedCourse);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("courses/{courseCode}")]
		public IActionResult DeleteCourse(string courseCode)
		{
			try
			{
				int i = courseRepository.DeleteCourse(courseCode);
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
