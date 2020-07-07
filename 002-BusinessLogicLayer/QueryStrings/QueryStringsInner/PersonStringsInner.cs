using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class PersonStringsInner
	{
		static private string queryPersonsString = "SELECT * from Persons";
		static private string queryPersonsIdString = "SELECT personId from Persons";
		static private string queryPersonsByIdString = "SELECT * from Persons where personId=@personId";
		static private string queryPersonsDelete = "DELETE FROM Persons WHERE personId=@personId";
		static private string queryPersonsIfExists = "SELECT COUNT(1) FROM Persons WHERE personId = @personId;";


		static public OleDbCommand GetAllPersons()
		{
			return CreateOleDbCommand(queryPersonsString);
		}

		static public OleDbCommand GetAllPersonsId()
		{
			return CreateOleDbCommand(queryPersonsIdString);
		}

		static public OleDbCommand GetOnePersonById(string personId)
		{
			return CreateOleDbCommand(personId, queryPersonsByIdString);
		}

		static public OleDbCommand DeletePerson(string personId)
		{
			return CreateOleDbCommand(personId, queryPersonsDelete);
		}

		static public OleDbCommand checkIfIdExists(string personId)
		{
			return CreateOleDbCommand(personId, queryPersonsIfExists);
		}



		static private OleDbCommand CreateOleDbCommand(string personId, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@personId", personId);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
