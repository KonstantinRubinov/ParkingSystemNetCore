using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlCellphoneManager : SqlDataBase, ICellphoneRepository
	{
		public List<CellphoneModel> GetAllCellphones()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsSql.GetAllCellphones());
			}

			List<CellphoneModel> arrCellphone = new List<CellphoneModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrCellphone.Add(CellphoneModel.ToObject(ms));
			}

			return arrCellphone;
		}


		public CellphoneModel GetOneBeforeCellphone(string beforeCellphone)
		{
			DataTable dt = new DataTable();

			if (beforeCellphone.Equals(string.Empty) || beforeCellphone.Equals(""))
				throw new ArgumentOutOfRangeException();
			CellphoneModel cellphoneModel = new CellphoneModel();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsSql.GetOneBeforeCellphone(beforeCellphone));
			}

			foreach (DataRow ms in dt.Rows)
			{
				cellphoneModel = CellphoneModel.ToObject(ms);
			}

			return cellphoneModel;
		}

		public CellphoneModel AddCellphone(CellphoneModel cellphoneModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsSql.AddCellphone(cellphoneModel));
			}

			foreach (DataRow ms in dt.Rows)
			{
				cellphoneModel = CellphoneModel.ToObject(ms);
			}

			return cellphoneModel;
		}


		public CellphoneModel UpdateCellphone(CellphoneModel cellphoneModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsSql.UpdateCellphone(cellphoneModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				cellphoneModel = CellphoneModel.ToObject(ms);
			}

			return cellphoneModel;
		}

		public int DeleteCellphone(string beforeCellphone)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(CellphoneStringsSql.DeleteCellphone(beforeCellphone));
			}

			return i;
		}
	}
}
