using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class VehicleApiController : ControllerBase
	{
		private IVehicleRepository vehicleRepository;

		public VehicleApiController(IVehicleRepository _vehicleRepository)
		{
			vehicleRepository = _vehicleRepository;
		}

		[HttpGet("vehicles/number")]
		public IActionResult GetAllVehicleNumbers()
		{
			try
			{
				List<string> allVehicleNumbers = vehicleRepository.GetAllVehicleNumbers();
				return Ok(allVehicleNumbers);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("vehicles")]
		public IActionResult GetAllVehicles()
		{
			try
			{
				List<VehicleModel> allVehicles = vehicleRepository.GetAllVehicles();
				return Ok(allVehicles);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("vehicles/{number}")]
		public IActionResult GetOneVehicleByNumber(string vehicleNumber)
		{
			try
			{
				VehicleModel vehicleModel = vehicleRepository.GetOneVehicleByNumber(vehicleNumber);
				return Ok(vehicleModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("vehicles")]
		public IActionResult AddVehicle(VehicleModel vehicleModel)
		{
			try
			{
				if (vehicleModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				VehicleModel addedVehicle = vehicleRepository.AddVehicle(vehicleModel);
				return StatusCode(StatusCodes.Status201Created, addedVehicle);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("vehicles/{number}")]
		public IActionResult UpdateVehicle(string vehicleNumber, VehicleModel vehicleModel)
		{
			try
			{
				if (vehicleModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				vehicleModel.vehicleNumber = vehicleNumber;
				VehicleModel updatedVehicle = vehicleRepository.UpdateVehicle(vehicleModel);
				return Ok(updatedVehicle);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("vehicles/{number}")]
		public IActionResult DeleteVehicle(string vehicleNumber)
		{
			try
			{
				int i = vehicleRepository.DeleteVehicleByNumber(vehicleNumber);
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
