using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerTelephoneManager : dbAccess, ITelephoneRepository
	{
		public InnerTelephoneManager(string connectionString) : base(connectionString)
		{
		}

		public List<TelephoneModel> GetAllTelephones()
		{
			DataTable dt = new DataTable();
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsInner.GetAllTelephones());
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(TelephoneStringsInner.GetOneBeforeTelephone(beforeTelephone));
			}

			foreach (DataRow ms in dt.Rows)
			{
				telephoneModel = TelephoneModel.ToObject(ms);
			}
			return telephoneModel;
		}

		public TelephoneModel AddTelephone(TelephoneModel telephoneModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(TelephoneStringsInner.AddTelephone(telephoneModel));
			}

			return GetOneBeforeTelephone(telephoneModel.beforeTelephone);
		}


		public TelephoneModel UpdateTelephone(TelephoneModel telephoneModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(TelephoneStringsInner.UpdateTelephone(telephoneModel));
			}
			return GetOneBeforeTelephone(telephoneModel.beforeTelephone);
		}

		public int DeleteTelephone(string beforeTelephone)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(TelephoneStringsInner.DeleteTelephone(beforeTelephone));
			}

			return i;
		}
	}
}
