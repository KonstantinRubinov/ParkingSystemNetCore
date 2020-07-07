using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class TeacherStringsMySql
	{
		static private string queryTeachersString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Teachers.teacherId, Teachers.teacherFacultyCode, Teachers.teacherStage From Persons INNER JOIN Teachers ON Persons.personId=Teachers.teacherId;";
		static private string queryTeachersByIdString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Teachers.teacherId, Teachers.teacherFacultyCode, Teachers.teacherStage From Persons INNER JOIN Teachers ON Persons.personId=Teachers.teacherId where Teachers.teacherId=@teacherId";
		static private string queryTeachersPost = "INSERT INTO Persons (personId, personFirstName, personLastName, personBeforeTelephone, personTelephone, personBeforeCellphone, personCellphone, personCode) VALUES (@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode); " +
												  "INSERT INTO Teachers (teacherId, teacherFacultyCode, teacherStage) VALUES (@teacherId, @teacherFacultyCode, @teacherStage);";
		static private string queryTeachersUpdate = "UPDATE Persons SET personId = @personId, personFirstName = @personFirstName, personLastName = @personLastName, personBeforeTelephone = @personBeforeTelephone, personTelephone = @personTelephone, personBeforeCellphone = @personBeforeCellphone, personCellphone = @personCellphone, personCode = @personCode WHERE personId = @personId; " +
													"UPDATE Teachers SET teacherId = @teacherId, teacherFacultyCode = @teacherFacultyCode, teacherStage = @teacherStage WHERE teacherId = @teacherId;";
		static private string queryTeachersDelete = "DELETE FROM Teachers WHERE teacherId=@teacherId; " + "DELETE FROM Persons WHERE personId=@teacherId;";

		static private string procedureTeachersString = "CALL `Parking`.`GetAllTeachers`();";
		static private string procedureTeachersByIdString = "CALL `Parking`.`GetAllTeachers`(@teacherId);";
		static private string procedureTeachersPost = "CALL `Parking`.`AddTeacher`(@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @teacherId, @teacherFacultyCode, @teacherStage);";
		static private string procedureTeachersUpdate = "CALL `Parking`.`UpdateTeacher`(@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @teacherId, @teacherFacultyCode, @teacherStage);";
		static private string procedureTeachersDelete = "CALL `Parking`.`DeleteTeacher`(@teacherId);";

		static public MySqlCommand GetAllTeachers()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryTeachersString);
			else
				return CreateSqlCommand(procedureTeachersString);
		}

		static public MySqlCommand GetOneTeacherById(string teacherId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherId, queryTeachersByIdString);
			else
				return CreateSqlCommand(teacherId, procedureTeachersByIdString);
		}

		static public MySqlCommand AddTeacher(TeacherModel teacherModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherModel, queryTeachersPost);
			else
				return CreateSqlCommand(teacherModel, procedureTeachersPost);
		}

		static public MySqlCommand UpdateTeacher(TeacherModel teacherModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherModel, queryTeachersUpdate);
			else
				return CreateSqlCommand(teacherModel, procedureTeachersUpdate);
		}

		static public MySqlCommand DeleteTeacher(string teacherId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(teacherId, queryTeachersDelete);
			else
				return CreateSqlCommand(teacherId, procedureTeachersDelete);
		}

		static private MySqlCommand CreateSqlCommand(TeacherModel teacher, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);
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

		static private MySqlCommand CreateSqlCommand(string teacherId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@teacherId", teacherId);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
