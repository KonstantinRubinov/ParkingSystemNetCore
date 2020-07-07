using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface IVehicleRepository
	{
		List<string> GetAllVehicleNumbers();
		List<VehicleModel> GetAllVehicles();
		VehicleModel GetOneVehicleByNumber(string vehicleNumber);
		VehicleModel GetOneVehicleByOwnerId(string personId);
		VehicleModel AddVehicle(VehicleModel vehicleModel);
		VehicleModel UpdateVehicle(VehicleModel vehicleModel);
		int DeleteVehicleByNumber(string vehicleNumber);
		int DeleteVehicleByOwnerId(string ownerId);
	}
}
