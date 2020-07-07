using lcpi.data.oledb;
using System;
using System.Data;
using System.Diagnostics;

namespace ParkingSystemCoreDAL
{
	public class dbAccess
	{
		#region Constructor + Members
		protected OleDbConnection _conn = null;

		public dbAccess(string strExe)
		{
			string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExe + @"\..\..\..\DataBase.accdb" + ";Persist Security Info=False;";
			_conn = new OleDbConnection(connectionString);
		}
		#endregion

		#region Protected Methods

		protected void Connect()
		{
			if (_conn.State != ConnectionState.Open)
			{
				Debug.WriteLine("Open connection");
				_conn.Open();
			}
		}

		protected void Disconnect()
		{
			Debug.WriteLine("Close connection");
			_conn.Close();
		}

		protected int ExecuteNonQuery(OleDbCommand command)
		{
			int i = 0;
			lock (_conn)
			{
				Connect();
				command.Connection = _conn;
				try
				{
					Debug.WriteLine("Create NonQuery: " + i);
					i = command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Create NonQuery :" + ex.Message);
				}
				finally
				{
					Disconnect();
				}
			}
			return i;
		}

		protected int ExecuteScalarIntQuery(OleDbCommand command)
		{
			int ret = -1;
			lock (_conn)
			{
				Connect();
				command.Connection = _conn;
				try
				{
					ret = (int)command.ExecuteScalar();
					Debug.WriteLine("Scalar Scalar: " + ret);
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Create Scalar :" + ex.Message);
				}
				finally
				{
					Disconnect();
				}
			}
			return ret;
		}

		protected DataTable GetMultipleQuery(OleDbCommand command)
		{
			DataSet dataset = new DataSet();
			DataTable dt = new DataTable();
			lock (_conn)
			{
				Connect();
				command.Connection = _conn;
				try
				{
					OleDbDataAdapter adapter = new OleDbDataAdapter();
					adapter.SelectCommand = command;
					adapter.Fill(dataset);
					Debug.WriteLine("Create deta adapter");
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Create deta adapter Exception: " + ex.Message);
				}
				finally
				{
					Disconnect();
				}
			}

			try
			{
				dt = dataset.Tables[0];
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Create data table Exception: " + ex.Message);
			}

			return dt;



		}


		#endregion
	}
}
