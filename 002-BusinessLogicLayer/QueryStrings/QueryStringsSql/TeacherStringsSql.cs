using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class TeacherStringsSql
	{
		static private string queryTeachersString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Teachers.teacherId, Teachers.teacherFacultyCode, Teachers.teacherStage From Persons INNER JOIN Teachers ON Persons.personId=Teachers.teacherId;";
		static private string queryTeachersByIdString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Teachers.teacherId, Teachers.teacherFacultyCode, Teachers.teacherStage From Persons INNER JOIN Teachers ON Persons.personId=Teachers.teacherId where Teachers.teacherId=@teacherId";
		static private string queryTeachersPost = "INSERT INTO Persons (personId, personFirstName, personLastName, personBeforeTelephone, personTelephone, personBeforeCellphone, personCellphone, personCode) VALUES (@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode); " +
												  "INSERT INTO Teachers (teacherId, teacherFacultyCode, teacherStage) VALUES (@teacherId, @teacherFacultyCode, @teacherStage);";
		static private string queryTeachersUpdate = "UPDATE Persons SET personId = @personId, personFirstName = @personFirstName, personLastName = @personLastName, personBeforeTelephone = @personBeforeTelephone, personTelephone = @personTelephone, personBeforeCellphone = @personBeforeCellphone, personCellphone = @personCellphone, personCode = @personCode WHERE personId = @personId; " +
													"UPDATE Teachers SET teacherId = @teacherId, teacherFacultyCode = @teacherFacultyCode, teacherStage = @teacherStage WHERE teacherId = @teacherId;";
		static private string queryTeachersDelete = "DELETE FROM Teachers WHERE teacherId=@teacherId; " + "DELETE FROM Persons WHERE personId=@teacherId;";

		static private string procedureTeachersString = "EXEC GetAllTeachers;";
		static private string procedureTeachersByIdString = "EXEC GetAllTeachers @teacherId";
		static private string procedureTeachersPost = "EXEC AddTeacher @personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @teacherId, @teacherFacultyCode, @teacherStage;";
		static private string procedureTeachersUpdate = "EXEC UpdateTeacher @personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @teacherId, @teacherFacultyCode, @teacherStage;";
		static private string procedureTeachersDelete = "EXEC DeleteTeacher @teacherId;";

		static public SqlCommand GetAllTeachers()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryTeachersString);
			else
				return CreateSqlCommand(procedureTeachersString);
		}

		static public SqlCommand GetOneTeacherById(string teacherId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherId, queryTeachersByIdString);
			else
				return CreateSqlCommand(teacherId, procedureTeachersByIdString);
		}

		static public SqlCommand AddTeacher(TeacherModel teacherModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherModel, queryTeachersPost);
			else
				return CreateSqlCommand(teacherModel, procedureTeachersPost);
		}

		static public SqlCommand UpdateTeacher(TeacherModel teacherModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherModel, queryTeachersUpdate);
			else
				return CreateSqlCommand(teacherModel, procedureTeachersUpdate);
		}

		static public SqlCommand DeleteTeacher(string teacherId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherId, queryTeachersDelete);
			else
				return CreateSqlCommand(teacherId, procedureTeachersDelete);
		}

		static private SqlCommand CreateSqlCommand(TeacherModel teacher, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
			command.Parameters.AddWithValue("@personId", teacher.personId);
			command.Parameters.AddWithValue("@personFirstName", teacher.personFirstName);
			command.Parameters.AddWithValue("@personLastName", teacher.personLastName);
			command.Parameters.AddWithValue("@personBeforeTelephone", teacher.personBeforeTelephone);
			command.Parameters.AddWithValue("@personTelephone", teacher.personTelephone);
			command.Parameters.AddWithValue("@personBeforeCellphone", teacher.personBeforeCellphone);
			command.Parameters.AddWithValue("@personCellphone", teacher.personCellphone);
			command.Parameters.AddWithValue("@personCode", teacher.personCode);
			command.Parameters.AddWithValue("@teacherId", teacher.teacherId);
			command.Parameters.AddWithValue("@teacherFacultyCode", teacher.teacherFacultyCode);
			command.Parameters.AddWithValue("@teacherStage", teacher.teacherStage);
			return command;
		}

		static private SqlCommand CreateSqlCommand(string teacherId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@teacherId", teacherId);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
