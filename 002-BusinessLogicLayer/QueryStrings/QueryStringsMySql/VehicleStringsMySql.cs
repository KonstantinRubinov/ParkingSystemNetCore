using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class VehicleStringsMySql
	{
		static private string queryVehiclesString = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId;";
		static private string queryVehiclesNumbersString = "SELECT vehicleNumber from Vehicles;";
		static private string queryVehiclesByNumber = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId and Vehicles.vehicleNumber=@vehicleNumber;";
		static private string queryVehiclesByOwnerString = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId and Vehicles.vehicleOwnerId=@vehicleOwnerId;";
		static private string queryVehiclesPost = "INSERT INTO Vehicles (vehicleNumber, vehicleManufacturer, vehicleColor, vehicleOwnerId) VALUES (@vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId);";
		static private string queryVehiclesUpdate = "UPDATE Vehicles SET vehicleNumber = @vehicleNumber, vehicleManufacturer = @vehicleManufacturer, vehicleColor = @vehicleColor, vehicleOwnerId = @vehicleOwnerId where vehicleNumber=@vehicleNumber or vehicleOwnerId = @vehicleOwnerId;";
		static private string queryVehiclesDeleteByNumber = "DELETE FROM Vehicles WHERE vehicleNumber=@vehicleNumber;";
		static private string queryVehiclesDeleteByOwner = "DELETE FROM Vehicles WHERE vehicleOwnerId=@vehicleOwnerId;";

		static private string procedureVehiclesString = "CALL `Parking`.`GetAllVehicles`();";
		static private string procedureVehiclesNumbersString = "CALL `Parking`.`GetAllVehicleNumbers`();";
		static private string procedureVehiclesByNumber = "CALL `Parking`.`GetOneVehicleByNumber`(@vehicleNumber);";
		static private string procedureVehiclesByOwnerString = "CALL `Parking`.`GetOneVehicleByOwnerId`(@vehicleOwnerId);";
		static private string procedureVehiclesPost = "CALL `Parking`.`AddVehicle`(@vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId);";
		static private string procedureVehiclesUpdate = "CALL `Parking`.`UpdateVehicle`(@vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId);";
		static private string procedureVehiclesDeleteByNumber = "CALL `Parking`.`DeleteVehicleByNumber`(@vehicleNumber);";
		static private string procedureVehiclesDeleteByOwner = "CALL `Parking`.`DeleteVehicleByOwnerId`(@vehicleOwnerId);";

		static public MySqlCommand GetAllVehicles()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryVehiclesString);
			else
				return CreateSqlCommand(procedureVehiclesString);
		}

		static public MySqlCommand GetAllVehicleNumbers()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryVehiclesNumbersString);
			else
				return CreateSqlCommand(procedureVehiclesNumbersString);
		}

		static public MySqlCommand GetOneVehicleByNumber(string vehicleNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(vehicleNumber, queryVehiclesByNumber);
			else
				return CreateSqlCommandNumber(vehicleNumber, procedureVehiclesByNumber);
		}

		static public MySqlCommand GetOneVehicleByOwnerId(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandOwner(personId, queryVehiclesByOwnerString);
			else
				return CreateSqlCommandOwner(personId, procedureVehiclesByOwnerString);
		}

		static public MySqlCommand AddVehicle(VehicleModel vehicleModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(vehicleModel, queryVehiclesPost);
			else
				return CreateSqlCommand(vehicleModel, procedureVehiclesPost);
		}

		static public MySqlCommand UpdateVehicle(VehicleModel vehicleModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(vehicleModel, queryVehiclesUpdate);
			else
				return CreateSqlCommand(vehicleModel, procedureVehiclesUpdate);
		}

		static public MySqlCommand DeleteVehicleByNumber(string vehicleNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(vehicleNumber, queryVehiclesDeleteByNumber);
			else
				return CreateSqlCommandNumber(vehicleNumber, procedureVehiclesDeleteByNumber);
		}

		static public MySqlCommand DeleteVehicleByOwnerId(string ownerId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandOwner(ownerId, queryVehiclesDeleteByOwner);
			else
				return CreateSqlCommandOwner(ownerId, procedureVehiclesDeleteByOwner);
		}

		static private MySqlCommand CreateSqlCommand(VehicleModel vehicle, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@vehicleNumber", vehicle.vehicleNumber);
			command.Parameters.AddWithValue("@vehicleManufacturer", vehicle.vehicleManufacturer);
			command.Parameters.AddWithValue("@vehicleColor", vehicle.vehicleColor);
			command.Parameters.AddWithValue("@vehicleOwnerId", vehicle.vehicleOwnerId);
			return command;
		}

		static private MySqlCommand CreateSqlCommandNumber(string vehicleNumber, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);

			return command;
		}

		static private MySqlCommand CreateSqlCommandOwner(string vehicleOwnerId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@vehicleOwnerId", vehicleOwnerId);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
