using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class ThreeObjectsModel
	{
		private PersonModel _personModel;
		private VehicleModel _vehicleModel;
		private ApprovalModel _approvalModel;

		[DataMember]
		public PersonModel personModel
		{
			set
			{
				_personModel = value;
			}

			get
			{
				return _personModel;
			}
		}

		[DataMember]
		public VehicleModel vehicleModel
		{
			set
			{
				_vehicleModel = value;
			}

			get
			{
				return _vehicleModel;
			}
		}

		[DataMember]
		public ApprovalModel approvalModel
		{
			set
			{
				_approvalModel = value;
			}

			get
			{
				return _approvalModel;
			}
		}

		public ThreeObjectsModel(PersonModel person2, VehicleModel vehicle2, ApprovalModel approval2)
		{
			personModel = person2;
			vehicleModel = vehicle2;
			approvalModel = approval2;
		}

		public ThreeObjectsModel()
		{

		}
	}
}
