using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlApprovalManager : SqlDataBase, IApprovalRepository
	{
		public List<ApprovalModel> GetAllApprovals()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsSql.GetAllApprovals());
			}

			List<ApprovalModel> arrApproval = new List<ApprovalModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrApproval.Add(ApprovalModel.ToObject(ms));
			}

			return arrApproval;
		}


		public ApprovalModel GetOneApprovalByCode(string approvalCode)
		{
			DataTable dt = new DataTable();

			if (approvalCode.Equals(string.Empty) || approvalCode.Equals(""))
				throw new ArgumentOutOfRangeException();
			ApprovalModel approvalModel = new ApprovalModel();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsSql.GetOneApprovalByCode(approvalCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				approvalModel = ApprovalModel.ToObject(ms);
			}

			return approvalModel;
		}

		public ApprovalModel GetOneApprovalByPersonId(string personId)
		{
			DataTable dt = new DataTable();

			if (personId.Equals(string.Empty) || personId.Equals(""))
				throw new ArgumentOutOfRangeException();
			ApprovalModel approvalModel = new ApprovalModel();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsSql.GetOneApprovalByPersonId(personId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				approvalModel = ApprovalModel.ToObject(ms);
			}

			return approvalModel;
		}

		public ApprovalModel GetOneApprovalByNumber(int approvalNumber)
		{
			DataTable dt = new DataTable();

			if (approvalNumber < 1)
				throw new ArgumentOutOfRangeException();
			ApprovalModel approvalModel = new ApprovalModel();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsSql.GetOneApprovalByNumber(approvalNumber));
			}

			foreach (DataRow ms in dt.Rows)
			{
				approvalModel = ApprovalModel.ToObject(ms);
			}

			return approvalModel;
		}

		public ApprovalModel AddApproval(ApprovalModel approvalModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsSql.AddApproval(approvalModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				approvalModel = ApprovalModel.ToObject(ms);
			}

			return approvalModel;
		}


		public ApprovalModel UpdateApproval(ApprovalModel approvalModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsSql.UpdateApproval(approvalModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				approvalModel = ApprovalModel.ToObject(ms);
			}

			return approvalModel;
		}

		public int DeleteApproval(int approvalNumber)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(ApprovalStringsSql.DeleteApproval(approvalNumber));
			}

			return i;
		}

		public int DeleteApprovalById(string approvalPersonId)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(ApprovalStringsSql.DeleteApprovalById(approvalPersonId));
			}

			return i;
		}
	}
}
