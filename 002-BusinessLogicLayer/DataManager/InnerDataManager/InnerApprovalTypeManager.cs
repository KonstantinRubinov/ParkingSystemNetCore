using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerApprovalTypeManager : dbAccess, IApprovalTypesRepository
	{
		public InnerApprovalTypeManager(string connectionString) : base(connectionString)
		{
		}

		public List<ApprovalTypeModel> GetAllApprovalTypes()
		{
			DataTable dt = new DataTable();
			List<ApprovalTypeModel> arrApprovalType = new List<ApprovalTypeModel>();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsInner.GetAllApprovalTypes());
			}
			foreach (DataRow ms in dt.Rows)
			{
				arrApprovalType.Add(ApprovalTypeModel.ToObject(ms));
			}
			return arrApprovalType;
		}

		public ApprovalTypeModel GetOneApprovalTypeByCode(string approvalCode)
		{
			DataTable dt = new DataTable();
			ApprovalTypeModel approvalModelType = new ApprovalTypeModel();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsInner.GetOneApprovalTypeByCode(approvalCode));
			}
			foreach (DataRow ms in dt.Rows)
			{
				approvalModelType = ApprovalTypeModel.ToObject(ms);
			}
			return approvalModelType;
		}

		public ApprovalTypeModel AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(ApprovalTypeStringsInner.AddApprovalType(approvalTypeModel));
			}

			return GetOneApprovalTypeByCode(approvalTypeModel.approvalCode);
		}

		public ApprovalTypeModel UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(ApprovalTypeStringsInner.UpdateApprovalType(approvalTypeModel));
			}

			return GetOneApprovalTypeByCode(approvalTypeModel.approvalCode);
		}

		public int DeleteApprovalType(string approvalCode)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(ApprovalTypeStringsInner.DeleteApprovalType(approvalCode));
			}

			return i;
		}
	}
}
