using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class VehicleStringsInner
	{
		static private string queryVehiclesString = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId";
		static private string queryVehiclesNumbersString = "SELECT vehicleNumber from Vehicles";
		static private string queryVehiclesByNumber = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId and Vehicles.vehicleNumber=@vehicleNumber";
		static private string queryVehiclesByOwnerString = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId and Vehicles.vehicleOwnerId=@vehicleOwnerId";
		static private string queryVehiclesPost = "INSERT INTO Vehicles (vehicleNumber, vehicleManufacturer, vehicleColor, vehicleOwnerId) VALUES (@vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId);";
		static private string queryVehiclesUpdate = "UPDATE Vehicles SET vehicleNumber = @vehicleNumber, vehicleManufacturer = @vehicleManufacturer, vehicleColor = @vehicleColor, vehicleOwnerId = @vehicleOwnerId where vehicleNumber=@vehicleNumber or vehicleOwnerId = @vehicleOwnerId;";
		static private string queryVehiclesDeleteByNumber = "DELETE FROM Vehicles WHERE vehicleNumber=@vehicleNumber";
		static private string queryVehiclesDeleteByOwner = "DELETE FROM Vehicles WHERE vehicleOwnerId=@vehicleOwnerId";

		static public OleDbCommand GetAllVehicles()
		{
			return CreateOleDbCommand(queryVehiclesString);
		}

		static public OleDbCommand GetAllVehicleNumbers()
		{
			return CreateOleDbCommand(queryVehiclesNumbersString);
		}

		static public OleDbCommand GetOneVehicleByNumber(string vehicleNumber)
		{
			return CreateOleDbCommandNumber(vehicleNumber, queryVehiclesByNumber);
		}

		static public OleDbCommand GetOneVehicleByOwnerId(string personId)
		{
			return CreateOleDbCommandOwner(personId, queryVehiclesByOwnerString);
		}

		static public OleDbCommand AddVehicle(VehicleModel vehicleModel)
		{
			return CreateOleDbCommand(vehicleModel, queryVehiclesPost);
		}

		static public OleDbCommand UpdateVehicle(VehicleModel vehicleModel)
		{
			return CreateOleDbCommand(vehicleModel, queryVehiclesUpdate);
		}

		static public OleDbCommand DeleteVehicleByNumber(string vehicleNumber)
		{
			return CreateOleDbCommandNumber(vehicleNumber, queryVehiclesDeleteByNumber);
		}

		static public OleDbCommand DeleteVehicleByOwnerId(string ownerId)
		{
			return CreateOleDbCommandOwner(ownerId, queryVehiclesDeleteByOwner);
		}

		static private OleDbCommand CreateOleDbCommand(VehicleModel vehicle, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@vehicleNumber", vehicle.vehicleNumber);
			command.Parameters.AddWithValue("@vehicleManufacturer", vehicle.vehicleManufacturer);
			command.Parameters.AddWithValue("@vehicleColor", vehicle.vehicleColor);
			command.Parameters.AddWithValue("@vehicleOwnerId", vehicle.vehicleOwnerId);
			return command;
		}

		static private OleDbCommand CreateOleDbCommandNumber(string vehicleNumber, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandOwner(string vehicleOwnerId, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@vehicleOwnerId", vehicleOwnerId);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
