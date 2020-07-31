using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class ThreeObjectsApiController : ControllerBase
	{
		private IThreeObjectsRepository threeObjectsRepository;

		public ThreeObjectsApiController(IThreeObjectsRepository _threeObjectsRepository)
		{
			threeObjectsRepository = _threeObjectsRepository;
		}

		[HttpGet("threeObjects")]
		public IActionResult GetAllThreeObjects()
		{
			try
			{
				List<ThreeObjectsModel> allThreeObjects = threeObjectsRepository.GetAllThreeObjects();
				return Ok(allThreeObjects);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("threeObjects/{personId}")]
		public IActionResult GetAllThreeObjectsByPersonId(string personId)
		{
			try
			{
				ThreeObjectsModel threeObjectsModel = threeObjectsRepository.GetAllThreeObjectsByPersonId(personId);
				return Ok(threeObjectsModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("threeObjects")]
		public IActionResult AddThreeObjects(ThreeObjectsModel threeObjectsModel)
		{
			try
			{
				if (threeObjectsModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				ThreeObjectsModel addedThreeObjects = threeObjectsRepository.AddThreeObjects(threeObjectsModel);
				return StatusCode(StatusCodes.Status201Created, addedThreeObjects);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("threeObjects/{personId}")]
		public IActionResult UpdateThreeObjects(string personId, ThreeObjectsModel threeObjectsModel)
		{
			try
			{
				if (threeObjectsModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				threeObjectsModel.personModel.personId = personId;
				threeObjectsModel.approvalModel.approvalPersonId = personId;
				threeObjectsModel.vehicleModel.vehicleOwnerId = personId;
				ThreeObjectsModel updatedThreeObjects = threeObjectsRepository.UpdateThreeObjects(threeObjectsModel);
				return Ok(updatedThreeObjects);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("threeObjects/{personId}")]
		public IActionResult DeleteThreeObjects(string personId)
		{
			try
			{
				int i = threeObjectsRepository.DeleteThreeObjects(personId);
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
