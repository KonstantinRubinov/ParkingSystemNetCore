using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface IApprovalTypesRepository
	{
		List<ApprovalTypeModel> GetAllApprovalTypes();
		ApprovalTypeModel GetOneApprovalTypeByCode(string approvalCode);
		ApprovalTypeModel AddApprovalType(ApprovalTypeModel approvalTypeModel);
		ApprovalTypeModel UpdateApprovalType(ApprovalTypeModel approvalTypeModel);
		int DeleteApprovalType(string approvalCode);
	}
}
