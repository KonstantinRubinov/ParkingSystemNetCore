using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface IThreeObjectsRepository
	{
		List<ThreeObjectsModel> GetAllThreeObjects();
		ThreeObjectsModel GetAllThreeObjectsByPersonId(string personId);
		ThreeObjectsModel GetAllThreeObjectsByVehicleNumber(string vehicleNumber);
		ThreeObjectsModel AddThreeObjects(ThreeObjectsModel threeObjectsModel);
		ThreeObjectsModel UpdateThreeObjects(ThreeObjectsModel threeObjectsModel);
		int DeleteThreeObjects(string personId);
	}
}
