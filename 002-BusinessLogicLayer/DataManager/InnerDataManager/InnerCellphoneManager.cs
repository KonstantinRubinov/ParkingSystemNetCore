using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerCellphoneManager : dbAccess, ICellphoneRepository
	{
		public InnerCellphoneManager(string connectionString) : base(connectionString)
		{
		}

		public List<CellphoneModel> GetAllCellphones()
		{
			DataTable dt = new DataTable();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsInner.GetAllCellphones());
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(CellphoneStringsInner.GetOneBeforeCellphone(beforeCellphone));
			}

			foreach (DataRow ms in dt.Rows)
			{
				cellphoneModel = CellphoneModel.ToObject(ms);
			}

			return cellphoneModel;
		}

		public CellphoneModel AddCellphone(CellphoneModel cellphoneModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(CellphoneStringsInner.AddCellphone(cellphoneModel));
			}

			return GetOneBeforeCellphone(cellphoneModel.beforeCellphone);
		}


		public CellphoneModel UpdateCellphone(CellphoneModel cellphoneModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(CellphoneStringsInner.UpdateCellphone(cellphoneModel));
			}

			return GetOneBeforeCellphone(cellphoneModel.beforeCellphone);
		}

		public int DeleteCellphone(string beforeCellphone)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(CellphoneStringsInner.DeleteCellphone(beforeCellphone));
			}

			return i;
		}
	}
}
