using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlApprovalTypeManager : SqlDataBase, IApprovalTypesRepository
	{

		public List<ApprovalTypeModel> GetAllApprovalTypes()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsSql.GetAllApprovalTypes());
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsSql.GetOneApprovalTypeByCode(approvalCode));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsSql.AddApprovalType(approvalTypeModel));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ApprovalTypeStringsSql.UpdateApprovalType(approvalTypeModel));
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
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(ApprovalTypeStringsSql.DeleteApprovalType(approvalCode));
			}

			return i;
		}
	}
}
