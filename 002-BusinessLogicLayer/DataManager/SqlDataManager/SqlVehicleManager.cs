using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlVehicleManager : SqlDataBase, IVehicleRepository
	{
		public List<string> GetAllVehicleNumbers()
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsSql.GetAllVehicleNumbers());
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsSql.GetAllVehicles());
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsSql.GetOneVehicleByNumber(vehicleNumber));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsSql.GetOneVehicleByOwnerId(personId));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsSql.AddVehicle(vehicleModel));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(VehicleStringsSql.UpdateVehicle(vehicleModel));
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
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(VehicleStringsSql.DeleteVehicleByNumber(vehicleNumber));
			}

			return i;
		}

		public int DeleteVehicleByOwnerId(string ownerId)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(VehicleStringsSql.DeleteVehicleByOwnerId(ownerId));
			}

			return i;
		}
	}
}
