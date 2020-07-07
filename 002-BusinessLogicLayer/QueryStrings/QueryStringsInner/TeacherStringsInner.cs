using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class TeacherStringsInner
	{
		static private string queryTeachersString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Teachers.teacherId, Teachers.teacherFacultyCode, Teachers.teacherStage From Persons INNER JOIN Teachers ON Persons.personId=Teachers.teacherId;";
		static private string queryTeachersByIdString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Teachers.teacherId, Teachers.teacherFacultyCode, Teachers.teacherStage From Persons INNER JOIN Teachers ON Persons.personId=Teachers.teacherId where Teachers.teacherId=@teacherId";
		static private string queryTeachersPost = "INSERT INTO Persons (personId, personFirstName, personLastName, personBeforeTelephone, personTelephone, personBeforeCellphone, personCellphone, personCode) VALUES (@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode); " +
												  "INSERT INTO Teachers (teacherId, teacherFacultyCode, teacherStage) VALUES (@teacherId, @teacherFacultyCode, @teacherStage);";
		static private string queryTeachersUpdate = "UPDATE Persons SET personId = @personId, personFirstName = @personFirstName, personLastName = @personLastName, personBeforeTelephone = @personBeforeTelephone, personTelephone = @personTelephone, personBeforeCellphone = @personBeforeCellphone, personCellphone = @personCellphone, personCode = @personCode WHERE personId = @personId; " +
													"UPDATE Teachers SET teacherId = @teacherId, teacherFacultyCode = @teacherFacultyCode, teacherStage = @teacherStage WHERE teacherId = @teacherId;";
		static private string queryTeachersDelete = "DELETE FROM Teachers WHERE teacherId=@teacherId; " + "DELETE FROM Persons WHERE personId=@teacherId;";

		static public OleDbCommand GetAllTeachers()
		{
			return CreateOleDbCommand(queryTeachersString);
		}

		static public OleDbCommand GetOneTeacherById(string teacherId)
		{
			return CreateOleDbCommand(teacherId, queryTeachersByIdString);
		}

		static public OleDbCommand AddTeacher(TeacherModel teacherModel)
		{
			return CreateOleDbCommand(teacherModel, queryTeachersPost);
		}

		static public OleDbCommand UpdateTeacher(TeacherModel teacherModel)
		{
			return CreateOleDbCommand(teacherModel, queryTeachersUpdate);
		}

		static public OleDbCommand DeleteTeacher(string teacherId)
		{
			return CreateOleDbCommand(teacherId, queryTeachersDelete);
		}

		static private OleDbCommand CreateOleDbCommand(TeacherModel teacher, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);
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

		static private OleDbCommand CreateOleDbCommand(string teacherId, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@teacherId", teacherId);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
