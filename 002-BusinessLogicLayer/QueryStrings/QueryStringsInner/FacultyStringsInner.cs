using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class FacultyStringsInner
	{
		static private string queryFacultysString = "SELECT * from Facultys";
		static private string queryFacultysByCodeString = "SELECT * from Facultys where facultyCode=@facultyCode";
		static private string queryFacultysByNameString = "SELECT * from Facultys where facultyName=@facultyName";
		static private string queryFacultysByHeadString = "SELECT * from Facultys where facultyHead=@facultyHead";
		static private string queryFacultysPost = "INSERT INTO Facultys (facultyCode, facultyName, facultyHead) VALUES (@facultyCode, @facultyName, @facultyHead);" + queryFacultysByCodeString;
		static private string queryFacultysUpdate = "UPDATE Facultys SET facultyCode = @facultyCode, facultyName = @facultyName, facultyHead = @facultyHead where facultyCode=@facultyCode;" + queryFacultysByCodeString;
		static private string queryFacultysDelete = "DELETE FROM Facultys WHERE facultyCode=@facultyCode";


		static public OleDbCommand GetAllFaculties()
		{
			return CreateOleDbCommand(queryFacultysString);
		}

		static public OleDbCommand GetOneFacultyByCode(string facultyCode)
		{
			return CreateOleDbCommandCode(facultyCode, queryFacultysByCodeString);
		}

		static public OleDbCommand GetOneFacultyByName(string facultyName)
		{
			return CreateOleDbCommandName(facultyName, queryFacultysByNameString);
		}

		static public OleDbCommand GetOneFacultyByHead(string facultyHead)
		{
			return CreateOleDbCommandName(facultyHead, queryFacultysByHeadString);
		}

		static public OleDbCommand AddFaculty(FacultyModel facultyModel)
		{
			return CreateOleDbCommand(facultyModel, queryFacultysPost);
		}

		static public OleDbCommand UpdateFaculty(FacultyModel facultyModel)
		{
			return CreateOleDbCommand(facultyModel, queryFacultysUpdate);
		}

		static public OleDbCommand DeleteFaculty(string facultyCode)
		{
			return CreateOleDbCommandCode(facultyCode, queryFacultysDelete);
		}



		static private OleDbCommand CreateOleDbCommand(FacultyModel faculty, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@facultyCode", faculty.facultyCode);
			command.Parameters.AddWithValue("@facultyName", faculty.facultyName);
			command.Parameters.AddWithValue("@facultyHead", faculty.facultyHead);

			return command;
		}



		static private OleDbCommand CreateOleDbCommandCode(string facultyCode, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@facultyCode", facultyCode);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandName(string facultyName, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@facultyName", facultyName);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandHead(string facultyHead, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@facultyHead", facultyHead);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
