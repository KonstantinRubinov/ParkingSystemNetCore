using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlCellphoneManager : MySqlDataBase, ICellphoneRepository
	{
		public List<CellphoneModel> GetAllCellphones()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsMySql.GetAllCellphones());
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsMySql.GetOneBeforeCellphone(beforeCellphone));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsMySql.AddCellphone(cellphoneModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsMySql.UpdateCellphone(cellphoneModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(CellphoneStringsMySql.DeleteCellphone(beforeCellphone));
			}
			
			return i;
		}
	}
}
