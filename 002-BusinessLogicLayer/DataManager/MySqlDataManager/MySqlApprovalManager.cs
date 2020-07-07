using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlApprovalManager : MySqlDataBase, IApprovalRepository
	{
		public List<ApprovalModel> GetAllApprovals()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsMySql.GetAllApprovals());
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsMySql.GetOneApprovalByCode(approvalCode));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsMySql.GetOneApprovalByPersonId(personId));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsMySql.GetOneApprovalByNumber(approvalNumber));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsMySql.AddApproval(approvalModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalStringsMySql.UpdateApproval(approvalModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(ApprovalStringsMySql.DeleteApproval(approvalNumber));
			}
			
			return i;
		}

		public int DeleteApprovalById(string approvalPersonId)
		{
			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(ApprovalStringsMySql.DeleteApprovalById(approvalPersonId));
			}
			
			return i;
		}
	}
}
