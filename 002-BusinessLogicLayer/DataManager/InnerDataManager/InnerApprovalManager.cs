using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerApprovalManager : dbAccess, IApprovalRepository
	{
		public InnerApprovalManager(string connectionString) : base(connectionString)
		{
		}

		public List<ApprovalModel> GetAllApprovals()
		{
			DataTable dt = new DataTable();
			List<ApprovalModel> apv = new List<ApprovalModel>();


			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsInner.GetAllApprovals());
			}

			foreach (DataRow ms in dt.Rows)
			{
				apv.Add(ApprovalModel.ToObject(ms));
			}
			return apv;
		}

		public ApprovalModel GetOneApprovalByCode(string approvalCode)
		{
			DataTable dt = new DataTable();
			ApprovalModel app = new ApprovalModel();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsInner.GetOneApprovalByCode(approvalCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				app = ApprovalModel.ToObject(ms);
			}
			return app;
		}

		public ApprovalModel GetOneApprovalByPersonId(string approvalPersonId)
		{
			DataTable dt = new DataTable();
			ApprovalModel app = new ApprovalModel();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsInner.GetOneApprovalByPersonId(approvalPersonId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				app = ApprovalModel.ToObject(ms);
			}
			return app;

		}

		public ApprovalModel GetOneApprovalByNumber(int approvalNumber)
		{
			DataTable dt = new DataTable();
			ApprovalModel app = new ApprovalModel();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsInner.GetOneApprovalByNumber(approvalNumber));
			}

			foreach (DataRow ms in dt.Rows)
			{
				app = ApprovalModel.ToObject(ms);
			}
			return app;
		}

		public ApprovalModel AddApproval(ApprovalModel approval)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = base.ExecuteNonQuery(ApprovalStringsInner.AddApproval(approval));
			}

			return GetOneApprovalByCode(approval.approvalCode);
		}

		public ApprovalModel UpdateApproval(ApprovalModel approval)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = base.ExecuteNonQuery(ApprovalStringsInner.UpdateApproval(approval));
			}

			return GetOneApprovalByCode(approval.approvalCode);
		}

		public int DeleteApproval(int approvalNumber)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = base.ExecuteNonQuery(ApprovalStringsInner.DeleteApproval(approvalNumber));
			}

			return i;
		}

		public int DeleteApprovalById(string approvalPersonId)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = base.ExecuteNonQuery(ApprovalStringsInner.DeleteApprovalById(approvalPersonId));
			}

			return i;
		}
	}
}
