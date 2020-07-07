using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class CellphoneApiController : ControllerBase
	{
		private ICellphoneRepository cellphoneRepository;

		public CellphoneApiController(ICellphoneRepository _cellphoneRepository)
		{
			cellphoneRepository = _cellphoneRepository;
		}

		[HttpGet("cellphones")]
		public IActionResult GetAllCellphones()
		{
			try
			{
				List<CellphoneModel> allCellphones = cellphoneRepository.GetAllCellphones();
				return Ok(allCellphones);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("cellphones/{beforeCellphone}")]
		public IActionResult GetOneBeforeCellphone(string beforeCellphone)
		{
			try
			{
				CellphoneModel cellphoneModel = cellphoneRepository.GetOneBeforeCellphone(beforeCellphone);
				return Ok(cellphoneModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("cellphones")]
		public IActionResult AddCellphone(CellphoneModel cellphoneModel)
		{
			try
			{
				if (cellphoneModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				CellphoneModel addedCellphone = cellphoneRepository.AddCellphone(cellphoneModel);
				return StatusCode(StatusCodes.Status201Created, addedCellphone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("cellphones/{beforeCellphone}")]
		public IActionResult UpdateCellphone(string beforeCellphone, CellphoneModel cellphoneModel)
		{
			try
			{
				if (cellphoneModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				cellphoneModel.beforeCellphone = beforeCellphone;
				CellphoneModel updatedCellphone = cellphoneRepository.UpdateCellphone(cellphoneModel);
				return Ok(updatedCellphone);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("cellphones/{beforeCellphone}")]
		public IActionResult DeleteCellphone(string beforeCellphone)
		{
			try
			{
				int i = cellphoneRepository.DeleteCellphone(beforeCellphone);
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
