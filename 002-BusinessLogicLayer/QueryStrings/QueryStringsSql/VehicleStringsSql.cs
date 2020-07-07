using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class VehicleStringsSql
	{
		static private string queryVehiclesString = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId;";
		static private string queryVehiclesNumbersString = "SELECT vehicleNumber from Vehicles;";
		static private string queryVehiclesByNumber = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId and Vehicles.vehicleNumber=@vehicleNumber;";
		static private string queryVehiclesByOwnerString = "SELECT Vehicles.vehicleNumber, Vehicles.vehicleManufacturer, Vehicles.vehicleColor, Vehicles.vehicleOwnerId, Persons.personFirstName, Persons.personLastName From Vehicles INNER JOIN Persons ON Vehicles.vehicleOwnerId=Persons.personId and Vehicles.vehicleOwnerId=@vehicleOwnerId;";
		static private string queryVehiclesPost = "INSERT INTO Vehicles (vehicleNumber, vehicleManufacturer, vehicleColor, vehicleOwnerId) VALUES (@vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId);";
		static private string queryVehiclesUpdate = "UPDATE Vehicles SET vehicleNumber = @vehicleNumber, vehicleManufacturer = @vehicleManufacturer, vehicleColor = @vehicleColor, vehicleOwnerId = @vehicleOwnerId where vehicleNumber=@vehicleNumber or vehicleOwnerId = @vehicleOwnerId;";
		static private string queryVehiclesDeleteByNumber = "DELETE FROM Vehicles WHERE vehicleNumber=@vehicleNumber;";
		static private string queryVehiclesDeleteByOwner = "DELETE FROM Vehicles WHERE vehicleOwnerId=@vehicleOwnerId;";

		static private string procedureVehiclesString = "EXEC GetAllVehicles;";
		static private string procedureVehiclesNumbersString = "EXEC GetAllVehicleNumbers;";
		static private string procedureVehiclesByNumber = "EXEC GetOneVehicleByNumber @vehicleNumber;";
		static private string procedureVehiclesByOwnerString = "EXEC GetOneVehicleByOwnerId @vehicleOwnerId;";
		static private string procedureVehiclesPost = "EXEC AddVehicle @vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId;";
		static private string procedureVehiclesUpdate = "EXEC UpdateVehicle @vehicleNumber, @vehicleManufacturer, @vehicleColor, @vehicleOwnerId;";
		static private string procedureVehiclesDeleteByNumber = "EXEC DeleteVehicleByNumber @vehicleNumber;";
		static private string procedureVehiclesDeleteByOwner = "EXEC DeleteVehicleByOwnerId @vehicleOwnerId;";

		static public SqlCommand GetAllVehicles()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryVehiclesString);
			else
				return CreateSqlCommand(procedureVehiclesString);
		}

		static public SqlCommand GetAllVehicleNumbers()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryVehiclesNumbersString);
			else
				return CreateSqlCommand(procedureVehiclesNumbersString);
		}

		static public SqlCommand GetOneVehicleByNumber(string vehicleNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(vehicleNumber, queryVehiclesByNumber);
			else
				return CreateSqlCommandNumber(vehicleNumber, procedureVehiclesByNumber);
		}

		static public SqlCommand GetOneVehicleByOwnerId(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandOwner(personId, queryVehiclesByOwnerString);
			else
				return CreateSqlCommandOwner(personId, procedureVehiclesByOwnerString);
		}

		static public SqlCommand AddVehicle(VehicleModel vehicleModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(vehicleModel, queryVehiclesPost);
			else
				return CreateSqlCommand(vehicleModel, procedureVehiclesPost);
		}

		static public SqlCommand UpdateVehicle(VehicleModel vehicleModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(vehicleModel, queryVehiclesUpdate);
			else
				return CreateSqlCommand(vehicleModel, procedureVehiclesUpdate);
		}

		static public SqlCommand DeleteVehicleByNumber(string vehicleNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(vehicleNumber, queryVehiclesDeleteByNumber);
			else
				return CreateSqlCommandNumber(vehicleNumber, procedureVehiclesDeleteByNumber);
		}

		static public SqlCommand DeleteVehicleByOwnerId(string ownerId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandOwner(ownerId, queryVehiclesDeleteByOwner);
			else
				return CreateSqlCommandOwner(ownerId, procedureVehiclesDeleteByOwner);
		}

		static private SqlCommand CreateSqlCommand(VehicleModel vehicle, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@vehicleNumber", vehicle.vehicleNumber);
			command.Parameters.AddWithValue("@vehicleManufacturer", vehicle.vehicleManufacturer);
			command.Parameters.AddWithValue("@vehicleColor", vehicle.vehicleColor);
			command.Parameters.AddWithValue("@vehicleOwnerId", vehicle.vehicleOwnerId);
			return command;
		}

		static private SqlCommand CreateSqlCommandNumber(string vehicleNumber, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@vehicleNumber", vehicleNumber);

			return command;
		}

		static private SqlCommand CreateSqlCommandOwner(string vehicleOwnerId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@vehicleOwnerId", vehicleOwnerId);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
