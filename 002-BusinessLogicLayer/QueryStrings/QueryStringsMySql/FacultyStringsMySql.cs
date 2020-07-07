using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class FacultyStringsMySql
	{
		static private string queryFacultysString = "SELECT * from Facultys;";
		static private string queryFacultysByCodeString = "SELECT * from Facultys where facultyCode=@facultyCode;";
		static private string queryFacultysByNameString = "SELECT * from Facultys where facultyName=@facultyName;";
		static private string queryFacultysByHeadString = "SELECT * from Facultys where facultyHead=@facultyHead;";
		static private string queryFacultysPost = "INSERT INTO Facultys (facultyCode, facultyName, facultyHead) VALUES (@facultyCode, @facultyName, @facultyHead);" + queryFacultysByCodeString;
		static private string queryFacultysUpdate = "UPDATE Facultys SET facultyCode = @facultyCode, facultyName = @facultyName, facultyHead = @facultyHead where facultyCode=@facultyCode;" + queryFacultysByCodeString;
		static private string queryFacultysDelete = "DELETE FROM Facultys WHERE facultyCode=@facultyCode;";

		static private string procedureFacultysString = "CALL `Parking`.`GetAllFaculties`();";
		static private string procedureFacultysByCodeString = "CALL `Parking`.`GetOneFacultyByCode`(@facultyCode);";
		static private string procedureFacultysByNameString = "CALL `Parking`.`GetOneFacultyByName`(@facultyName);";
		static private string procedureFacultysByHeadString = "CALL `Parking`.`GetOneFacultyByHead`(@facultyHead);";
		static private string procedureFacultysPost = "CALL `Parking`.`AddFaculty`(@facultyCode, @facultyName, @facultyHead);";
		static private string procedureFacultysUpdate = "CALL `Parking`.`UpdateFaculty`(@facultyCode, @facultyName, @facultyHead);";
		static private string procedureFacultysDelete = "CALL `Parking`.`GetOneFacultyByHead`(@facultyCode);";

		static public MySqlCommand GetAllFaculties()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryFacultysString);
			else
				return CreateSqlCommand(procedureFacultysString);
		}

		static public MySqlCommand GetOneFacultyByCode(string facultyCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(facultyCode, queryFacultysByCodeString);
			else
				return CreateSqlCommandCode(facultyCode, procedureFacultysByCodeString);
		}

		static public MySqlCommand GetOneFacultyByName(string facultyName)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(facultyName, queryFacultysByNameString);
			else
				return CreateSqlCommandName(facultyName, procedureFacultysByNameString);
		}

		static public MySqlCommand GetOneFacultyByHead(string facultyHead)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(facultyHead, queryFacultysByHeadString);
			else
				return CreateSqlCommandName(facultyHead, procedureFacultysByHeadString);
		}

		static public MySqlCommand AddFaculty(FacultyModel facultyModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(facultyModel, queryFacultysPost);
			else
				return CreateSqlCommand(facultyModel, procedureFacultysPost);
		}

		static public MySqlCommand UpdateFaculty(FacultyModel facultyModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(facultyModel, queryFacultysUpdate);
			else
				return CreateSqlCommand(facultyModel, procedureFacultysUpdate);
		}

		static public MySqlCommand DeleteFaculty(string facultyCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(facultyCode, queryFacultysDelete);
			else
				return CreateSqlCommandCode(facultyCode, procedureFacultysDelete);
		}

		static private MySqlCommand CreateSqlCommand(FacultyModel faculty, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyCode", faculty.facultyCode);
			command.Parameters.AddWithValue("@facultyName", faculty.facultyName);
			command.Parameters.AddWithValue("@facultyHead", faculty.facultyHead);

			return command;
		}

		static private MySqlCommand CreateSqlCommandCode(string facultyCode, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyCode", facultyCode);

			return command;
		}

		static private MySqlCommand CreateSqlCommandName(string facultyName, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyName", facultyName);

			return command;
		}

		static private MySqlCommand CreateSqlCommandHead(string facultyHead, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyHead", facultyHead);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
