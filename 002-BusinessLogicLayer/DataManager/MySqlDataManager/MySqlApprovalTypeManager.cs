using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlApprovalTypeManager : MySqlDataBase, IApprovalTypesRepository
	{
		public List<ApprovalTypeModel> GetAllApprovalTypes()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsMySql.GetAllApprovalTypes());
			}

			List<ApprovalTypeModel> arrApprovalType = new List<ApprovalTypeModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrApprovalType.Add(ApprovalTypeModel.ToObject(ms));
			}

			return arrApprovalType;
		}


		public ApprovalTypeModel GetOneApprovalTypeByCode(string approvalCode)
		{
			DataTable dt = new DataTable();

			if (approvalCode.Equals(string.Empty) || approvalCode.Equals(""))
				throw new ArgumentOutOfRangeException();
			ApprovalTypeModel approvalModelType = new ApprovalTypeModel();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsMySql.GetOneApprovalTypeByCode(approvalCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				approvalModelType = ApprovalTypeModel.ToObject(ms);
			}

			return approvalModelType;
		}

		public ApprovalTypeModel AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsMySql.AddApprovalType(approvalTypeModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				approvalTypeModel = ApprovalTypeModel.ToObject(ms);
			}

			return approvalTypeModel;
		}


		public ApprovalTypeModel UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsMySql.UpdateApprovalType(approvalTypeModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				approvalTypeModel = ApprovalTypeModel.ToObject(ms);
			}

			return approvalTypeModel;
		}

		public int DeleteApprovalType(string approvalCode)
		{
			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(ApprovalTypeStringsMySql.DeleteApprovalType(approvalCode));
			}
			
			return i;
		}
	}
}
