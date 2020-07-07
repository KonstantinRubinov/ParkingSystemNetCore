using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface IApprovalRepository
	{
		List<ApprovalModel> GetAllApprovals();
		ApprovalModel GetOneApprovalByCode(string approvalCode);
		ApprovalModel GetOneApprovalByPersonId(string personId);
		ApprovalModel GetOneApprovalByNumber(int approvalNumber);
		ApprovalModel AddApproval(ApprovalModel approvalModel);
		ApprovalModel UpdateApproval(ApprovalModel approvalModel);
		int DeleteApproval(int approvalNumber);
		int DeleteApprovalById(string approvalPersonId);
	}
}
