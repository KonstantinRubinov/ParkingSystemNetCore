using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingSystemCoreBLL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCore
{
	[Route("api")]
	[ApiController]
	public class ApprovalApiController : ControllerBase
	{
		private IApprovalRepository approvalRepository;

		public ApprovalApiController(IApprovalRepository _approvalRepository)
		{
			approvalRepository = _approvalRepository;
		}

		[HttpGet("approvals")]
		public IActionResult GetAllApprovals()
		{
			try
			{
				List<ApprovalModel> allApprovals = approvalRepository.GetAllApprovals();
				return Ok(allApprovals);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpGet("approvals/{approvalCode}")]
		public IActionResult GetOneApprovalByCode(string approvalCode)
		{
			try
			{
				ApprovalModel approvalModel = approvalRepository.GetOneApprovalByCode(approvalCode);
				return Ok(approvalModel);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpPost("approvals")]
		public IActionResult AddApproval(ApprovalModel approvalModel)
		{
			try
			{
				if (approvalModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				ApprovalModel addedApproval = approvalRepository.AddApproval(approvalModel);
				return StatusCode(StatusCodes.Status201Created, addedApproval);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}


		[HttpPut("approvals/{approvalCode}")]
		public IActionResult UpdateApproval(int approvalNumber, ApprovalModel approvalModel)
		{
			try
			{
				if (approvalModel == null)
				{
					return BadRequest("Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return BadRequest(errors);
				}

				approvalModel.approvalNumber = approvalNumber;
				ApprovalModel updatedApproval = approvalRepository.UpdateApproval(approvalModel);
				return Ok(updatedApproval);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, errors);
			}
		}

		[HttpDelete("approvals/{approvalNumber}")]
		public IActionResult DeleteApproval(int approvalNumber)
		{
			try
			{
				int i = approvalRepository.DeleteApproval(approvalNumber);
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