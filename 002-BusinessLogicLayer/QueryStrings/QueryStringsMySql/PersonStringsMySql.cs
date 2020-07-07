using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class PersonStringsMySql
	{
		static private string queryPersonsString = "SELECT * from Persons;";
		static private string queryPersonsIdString = "SELECT personId from Persons;";
		static private string queryPersonsByIdString = "SELECT * from Persons where personId=@personId;";
		static private string queryPersonsDelete = "DELETE FROM Persons WHERE personId=@personId;";
		static private string queryPersonsIfExists = "SELECT COUNT(1) FROM Persons WHERE personId = @personId;";

		static private string procedurePersonsString = "CALL `Parking`.`GetAllPersons`();";
		static private string procedurePersonsIdString = "CALL `Parking`.`GetAllPersonsId`();";
		static private string procedurePersonsByIdString = "CALL `Parking`.`GetOnePersonById`(@personId);";
		static private string procedurePersonsDelete = "CALL `Parking`.`DeletePerson`(@personId);";
		static private string procedurePersonsIfExists = "CALL `Parking`.`checkIfIdExists`(@personId);";

		static public MySqlCommand GetAllPersons()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryPersonsString);
			else
				return CreateSqlCommand(procedurePersonsString);
		}

		static public MySqlCommand GetAllPersonsId()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryPersonsIdString);
			else
				return CreateSqlCommand(procedurePersonsIdString);
		}

		static public MySqlCommand GetOnePersonById(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(personId, queryPersonsByIdString);
			else
				return CreateSqlCommand(personId, procedurePersonsByIdString);
		}

		static public MySqlCommand DeletePerson(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(personId, queryPersonsDelete);
			else
				return CreateSqlCommand(personId, procedurePersonsDelete);
		}

		static public MySqlCommand checkIfIdExists(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(personId, queryPersonsIfExists);
			else
				return CreateSqlCommand(personId, procedurePersonsIfExists);
		}

		static private MySqlCommand CreateSqlCommand(string personId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@personId", personId);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
