using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class FacultyStringsSql
	{
		static private string queryFacultysString = "SELECT * from Facultys;";
		static private string queryFacultysByCodeString = "SELECT * from Facultys where facultyCode=@facultyCode;";
		static private string queryFacultysByNameString = "SELECT * from Facultys where facultyName=@facultyName;";
		static private string queryFacultysByHeadString = "SELECT * from Facultys where facultyHead=@facultyHead;";
		static private string queryFacultysPost = "INSERT INTO Facultys (facultyCode, facultyName, facultyHead) VALUES (@facultyCode, @facultyName, @facultyHead);" + queryFacultysByCodeString;
		static private string queryFacultysUpdate = "UPDATE Facultys SET facultyCode = @facultyCode, facultyName = @facultyName, facultyHead = @facultyHead where facultyCode=@facultyCode;" + queryFacultysByCodeString;
		static private string queryFacultysDelete = "DELETE FROM Facultys WHERE facultyCode=@facultyCode;";

		static private string procedureFacultysString = "EXEC GetAllFaculties;";
		static private string procedureFacultysByCodeString = "EXEC GetOneFacultyByCode @facultyCode;";
		static private string procedureFacultysByNameString = "EXEC GetOneFacultyByName @facultyName;";
		static private string procedureFacultysByHeadString = "EXEC GetOneFacultyByHead @facultyHead;";
		static private string procedureFacultysPost = "EXEC AddFaculty @facultyCode, @facultyName, @facultyHead;";
		static private string procedureFacultysUpdate = "EXEC UpdateFaculty @facultyCode, @facultyName, @facultyHead;";
		static private string procedureFacultysDelete = "EXEC GetOneFacultyByHead @facultyCode;";

		static public SqlCommand GetAllFaculties()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryFacultysString);
			else
				return CreateSqlCommand(procedureFacultysString);
		}

		static public SqlCommand GetOneFacultyByCode(string facultyCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(facultyCode, queryFacultysByCodeString);
			else
				return CreateSqlCommandCode(facultyCode, procedureFacultysByCodeString);
		}

		static public SqlCommand GetOneFacultyByName(string facultyName)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(facultyName, queryFacultysByNameString);
			else
				return CreateSqlCommandName(facultyName, procedureFacultysByNameString);
		}

		static public SqlCommand GetOneFacultyByHead(string facultyHead)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(facultyHead, queryFacultysByHeadString);
			else
				return CreateSqlCommandName(facultyHead, procedureFacultysByHeadString);
		}

		static public SqlCommand AddFaculty(FacultyModel facultyModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(facultyModel, queryFacultysPost);
			else
				return CreateSqlCommand(facultyModel, procedureFacultysPost);
		}

		static public SqlCommand UpdateFaculty(FacultyModel facultyModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(facultyModel, queryFacultysUpdate);
			else
				return CreateSqlCommand(facultyModel, procedureFacultysUpdate);
		}

		static public SqlCommand DeleteFaculty(string facultyCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(facultyCode, queryFacultysDelete);
			else
				return CreateSqlCommandCode(facultyCode, procedureFacultysDelete);
		}

		static private SqlCommand CreateSqlCommand(FacultyModel faculty, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyCode", faculty.facultyCode);
			command.Parameters.AddWithValue("@facultyName", faculty.facultyName);
			command.Parameters.AddWithValue("@facultyHead", faculty.facultyHead);

			return command;
		}

		static private SqlCommand CreateSqlCommandCode(string facultyCode, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyCode", facultyCode);

			return command;
		}

		static private SqlCommand CreateSqlCommandName(string facultyName, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyName", facultyName);

			return command;
		}

		static private SqlCommand CreateSqlCommandHead(string facultyHead, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@facultyHead", facultyHead);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
