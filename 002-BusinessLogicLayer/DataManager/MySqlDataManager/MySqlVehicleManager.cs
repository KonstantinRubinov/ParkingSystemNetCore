using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlVehicleManager : MySqlDataBase, IVehicleRepository
	{
		public List<string> GetAllVehicleNumbers()
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsMySql.GetAllVehicleNumbers());
			}

			List<VehicleModel> arrVehicle = new List<VehicleModel>();
			foreach (DataRow ms in dt.Rows)
			{
				arrVehicle.Add(VehicleModel.ToObject(ms));
			}

			List<string> vehicleNumbers = new List<string>();
			foreach (var vehicle in arrVehicle)
			{
				vehicleNumbers.Add(vehicle.vehicleNumber);
			}

			return vehicleNumbers;
		}

		public List<VehicleModel> GetAllVehicles()
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsMySql.GetAllVehicles());
			}

			List<VehicleModel> arrVehicle = new List<VehicleModel>();
			foreach (DataRow ms in dt.Rows)
			{
				arrVehicle.Add(VehicleModel.ToObject(ms));
			}

			return arrVehicle;
		}


		public VehicleModel GetOneVehicleByNumber(string vehicleNumber)
		{
			DataTable dt = new DataTable();

			if (vehicleNumber.Equals(string.Empty) || vehicleNumber.Equals(""))
				throw new ArgumentOutOfRangeException();
			VehicleModel vehicleModel = new VehicleModel();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsMySql.GetOneVehicleByNumber(vehicleNumber));
			}

			foreach (DataRow ms in dt.Rows)
			{
				vehicleModel = VehicleModel.ToObject(ms);
			}
			return vehicleModel;
		}

		public VehicleModel GetOneVehicleByOwnerId(string personId)
		{
			DataTable dt = new DataTable();

			if (personId.Equals(string.Empty) || personId.Equals(""))
				throw new ArgumentOutOfRangeException();
			VehicleModel vehicleModel = new VehicleModel();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsMySql.GetOneVehicleByOwnerId(personId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				vehicleModel = VehicleModel.ToObject(ms);
			}
			return vehicleModel;
		}

		public VehicleModel AddVehicle(VehicleModel vehicleModel)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsMySql.AddVehicle(vehicleModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				vehicleModel = VehicleModel.ToObject(ms);
			}
			return vehicleModel;
		}


		public VehicleModel UpdateVehicle(VehicleModel vehicleModel)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsMySql.UpdateVehicle(vehicleModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				vehicleModel = VehicleModel.ToObject(ms);
			}
			return vehicleModel;
		}

		public int DeleteVehicleByNumber(string vehicleNumber)
		{
			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(VehicleStringsMySql.DeleteVehicleByNumber(vehicleNumber));
			}
			
			return i;
		}

		public int DeleteVehicleByOwnerId(string ownerId)
		{
			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(VehicleStringsMySql.DeleteVehicleByOwnerId(ownerId));
			}
			
			return i;
		}
	}
}
