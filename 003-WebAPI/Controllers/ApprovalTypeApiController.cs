using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class ApprovalTypeApiController : ControllerBase
	{
		private IApprovalTypesRepository approvalTypesRepository;

		public ApprovalTypeApiController(IApprovalTypesRepository _approvalTypesRepository)
		{
			approvalTypesRepository = _approvalTypesRepository;
		}

		[HttpGet("approvalTypes")]
		public IActionResult GetAllApprovalTypes()
		{
			try
			{
				List<ApprovalTypeModel> allApprovalTypes = approvalTypesRepository.GetAllApprovalTypes();
				return Ok(allApprovalTypes);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("approvalTypes/{approvalCode}")]
		public IActionResult GetOneApprovalTypeByCode(string approvalCode)
		{
			try
			{
				ApprovalTypeModel approvalTypeModel = approvalTypesRepository.GetOneApprovalTypeByCode(approvalCode);
				return Ok(approvalTypeModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("approvalTypes")]
		public IActionResult AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			try
			{
				if (approvalTypeModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				ApprovalTypeModel addedApprovalType = approvalTypesRepository.AddApprovalType(approvalTypeModel);
				return StatusCode(StatusCodes.Status201Created, addedApprovalType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPut("approvalTypes/{approvalCode}")]
		public IActionResult UpdateApprovalType(string approvalCode, ApprovalTypeModel approvalTypeModel)
		{
			try
			{
				if (approvalTypeModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				approvalTypeModel.approvalCode = approvalCode;
				ApprovalTypeModel updatedApprovalType = approvalTypesRepository.UpdateApprovalType(approvalTypeModel);
				return Ok(updatedApprovalType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("approvalTypes/{approvalCode}")]
		public IActionResult DeleteApprovalType(string approvalCode)
		{
			try
			{
				int i = approvalTypesRepository.DeleteApprovalType(approvalCode);
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