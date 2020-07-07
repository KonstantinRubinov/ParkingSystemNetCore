using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class PersonStringsSql
	{
		static private string queryPersonsString = "SELECT * from Persons;";
		static private string queryPersonsIdString = "SELECT personId from Persons;";
		static private string queryPersonsByIdString = "SELECT * from Persons where personId=@personId;";
		static private string queryPersonsDelete = "DELETE FROM Persons WHERE personId=@personId;";
		static private string queryPersonsIfExists = "SELECT COUNT(1) FROM Persons WHERE personId = @personId;";

		static private string procedurePersonsString = "EXEC GetAllPersons;";
		static private string procedurePersonsIdString = "EXEC GetAllPersonsId;";
		static private string procedurePersonsByIdString = "EXEC GetOnePersonById @personId;";
		static private string procedurePersonsDelete = "EXEC DeletePerson @personId;";
		static private string procedurePersonsIfExists = "EXEC checkIfIdExists @personId;";

		static public SqlCommand GetAllPersons()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryPersonsString);
			else
				return CreateSqlCommand(procedurePersonsString);
		}

		static public SqlCommand GetAllPersonsId()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryPersonsIdString);
			else
				return CreateSqlCommand(procedurePersonsIdString);
		}

		static public SqlCommand GetOnePersonById(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(personId, queryPersonsByIdString);
			else
				return CreateSqlCommand(personId, procedurePersonsByIdString);
		}

		static public SqlCommand DeletePerson(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(personId, queryPersonsDelete);
			else
				return CreateSqlCommand(personId, procedurePersonsDelete);
		}

		static public SqlCommand checkIfIdExists(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(personId, queryPersonsIfExists);
			else
				return CreateSqlCommand(personId, procedurePersonsIfExists);
		}

		static private SqlCommand CreateSqlCommand(string personId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@personId", personId);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
