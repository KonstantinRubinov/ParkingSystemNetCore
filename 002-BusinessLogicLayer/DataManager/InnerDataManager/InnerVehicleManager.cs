using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerVehicleManager : dbAccess, IVehicleRepository
	{
		public InnerVehicleManager(string connectionString) : base(connectionString)
		{
		}

		public List<string> GetAllVehicleNumbers()
		{
			DataTable dt = new DataTable();
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(VehicleStringsInner.GetAllVehicleNumbers());
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(VehicleStringsInner.GetAllVehicles());
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(VehicleStringsInner.GetOneVehicleByNumber(vehicleNumber));
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(VehicleStringsInner.GetOneVehicleByOwnerId(personId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				vehicleModel = VehicleModel.ToObject(ms);
			}
			return vehicleModel;
		}

		public VehicleModel AddVehicle(VehicleModel vehicleModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(VehicleStringsInner.AddVehicle(vehicleModel));
			}

			return GetOneVehicleByNumber(vehicleModel.vehicleNumber);
		}


		public VehicleModel UpdateVehicle(VehicleModel vehicleModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(VehicleStringsInner.UpdateVehicle(vehicleModel));
			}

			return GetOneVehicleByNumber(vehicleModel.vehicleNumber);
		}

		public int DeleteVehicleByNumber(string vehicleNumber)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(VehicleStringsInner.DeleteVehicleByNumber(vehicleNumber));
			}

			return i;
		}

		public int DeleteVehicleByOwnerId(string ownerId)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(VehicleStringsInner.DeleteVehicleByOwnerId(ownerId));
			}

			return i;
		}
	}
}
