using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class VehicleModel
	{
		private string _vehicleNumber;
		private string _vehicleManufacturer;
		private string _vehicleColor;
		private string _vehicleOwnerId;
		private string _vehicleOwnerName;

		[DataMember]
		public string vehicleNumber
		{
			set
			{
				_vehicleNumber = value;
			}

			get
			{
				return _vehicleNumber;
			}
		}

		[DataMember]
		public string vehicleManufacturer
		{
			set
			{
				_vehicleManufacturer = value;
			}

			get
			{
				return _vehicleManufacturer;
			}
		}

		[DataMember]
		public string vehicleColor
		{
			set
			{
				_vehicleColor = value;
			}

			get
			{
				return _vehicleColor;
			}
		}

		[DataMember]
		[PossibleID]
		public string vehicleOwnerId
		{
			set
			{
				_vehicleOwnerId = value;
			}

			get
			{
				return _vehicleOwnerId;
			}
		}

		[DataMember]
		public string vehicleOwnerName
		{
			set
			{
				_vehicleOwnerName = value;
			}

			get
			{
				return _vehicleOwnerName;
			}
		}

		public VehicleModel(string Number, string Creator, string Color, string OwnerName, string OwnerId)
		{
			vehicleNumber = Number;
			vehicleManufacturer = Creator;
			vehicleColor = Color;
			vehicleOwnerName = OwnerName;
			vehicleOwnerId = OwnerId;
		}

		public VehicleModel(string Number)
		{
			vehicleNumber = Number;
		}

		public VehicleModel()
		{
		}

		public override string ToString()
		{
			return
				vehicleNumber + " " +
				vehicleManufacturer + " " +
				vehicleColor + " " +
				vehicleOwnerId + " " +
				vehicleOwnerName;
		}


		public static VehicleModel ToObject(DataRow reader)
		{
			VehicleModel vehicleModel = new VehicleModel();
			vehicleModel.vehicleNumber = reader[0].ToString();
			vehicleModel.vehicleManufacturer = reader[1].ToString();
			vehicleModel.vehicleColor = reader[2].ToString();
			vehicleModel.vehicleOwnerId = reader[3].ToString();
			vehicleModel.vehicleOwnerName = reader[4].ToString() + " " + reader[5].ToString();

			Debug.WriteLine("VehicleModel:" + vehicleModel.ToString());
			return vehicleModel;
		}
	}
}
