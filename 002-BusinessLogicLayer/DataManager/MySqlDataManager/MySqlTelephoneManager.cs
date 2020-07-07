using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlTelephoneManager : MySqlDataBase, ITelephoneRepository
	{
		public List<TelephoneModel> GetAllTelephones()
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsMySql.GetAllTelephones());
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsMySql.GetOneBeforeTelephone(beforeTelephone));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsMySql.AddTelephone(telephoneModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsMySql.UpdateTelephone(telephoneModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(TelephoneStringsMySql.DeleteTelephone(beforeTelephone));
			}
			
			return i;
		}
	}
}
