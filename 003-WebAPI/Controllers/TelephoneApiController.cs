using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class TelephoneApiController : ControllerBase
	{
		private ITelephoneRepository telephoneRepository;

		public TelephoneApiController(ITelephoneRepository _telephoneRepository)
		{
			telephoneRepository = _telephoneRepository;
		}

		[HttpGet("telephones")]
		public IActionResult GetAllTelephones()
		{
			try
			{
				List<TelephoneModel> allTelephones = telephoneRepository.GetAllTelephones();
				return Ok(allTelephones);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("telephones/{beforeTelephone}")]
		public IActionResult GetOneBeforeTelephone(string beforeTelephone)
		{
			try
			{
				TelephoneModel telephoneModel = telephoneRepository.GetOneBeforeTelephone(beforeTelephone);
				return Ok(telephoneModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("telephones")]
		public IActionResult AddTelephone(TelephoneModel telephoneModel)
		{
			try
			{
				if (telephoneModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				TelephoneModel addedTelephone = telephoneRepository.AddTelephone(telephoneModel);
				return StatusCode(StatusCodes.Status201Created, addedTelephone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("telephones/{beforeTelephone}")]
		public IActionResult UpdateTelephone(string beforeTelephone, TelephoneModel telephoneModel)
		{
			try
			{
				if (telephoneModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				telephoneModel.beforeTelephone = beforeTelephone;
				TelephoneModel updatedTelephone = telephoneRepository.UpdateTelephone(telephoneModel);
				return Ok(updatedTelephone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("telephones/{beforeTelephone}")]
		public IActionResult DeleteTelephone(string beforeTelephone)
		{
			try
			{
				int i = telephoneRepository.DeleteTelephone(beforeTelephone);
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
