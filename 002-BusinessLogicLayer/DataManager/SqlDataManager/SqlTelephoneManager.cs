using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlTelephoneManager : SqlDataBase, ITelephoneRepository
	{
		public List<TelephoneModel> GetAllTelephones()
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsSql.GetAllTelephones());
			}

			List<TelephoneModel> arrTelephone = new List<TelephoneModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrTelephone.Add(TelephoneModel.ToObject(ms));
			}
			return arrTelephone;
		}


		public TelephoneModel GetOneBeforeTelephone(string beforeTelephone)
		{
			DataTable dt = new DataTable();

			if (beforeTelephone.Equals(string.Empty) || beforeTelephone.Equals(""))
				throw new ArgumentOutOfRangeException();
			TelephoneModel telephoneModel = new TelephoneModel();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsSql.GetOneBeforeTelephone(beforeTelephone));
			}

			foreach (DataRow ms in dt.Rows)
			{
				telephoneModel = TelephoneModel.ToObject(ms);
			}
			return telephoneModel;
		}

		public TelephoneModel AddTelephone(TelephoneModel telephoneModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsSql.AddTelephone(telephoneModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				telephoneModel = TelephoneModel.ToObject(ms);
			}
			return telephoneModel;
		}


		public TelephoneModel UpdateTelephone(TelephoneModel telephoneModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsSql.UpdateTelephone(telephoneModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				telephoneModel = TelephoneModel.ToObject(ms);
			}
			return telephoneModel;
		}

		public int DeleteTelephone(string beforeTelephone)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(TelephoneStringsSql.DeleteTelephone(beforeTelephone));
			}

			return i;
		}
	}
}
