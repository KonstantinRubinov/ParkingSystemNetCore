using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class StudentStringsMySql
	{
		static private string queryStudentsString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Students.studentId, Students.studentFacultyCode, Students.studentYear, Students.studentType From Persons INNER JOIN Students ON Persons.personId=Students.studentId;";
		static private string queryStudentsByIdString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Students.studentId, Students.studentFacultyCode, Students.studentYear, Students.studentType From Persons INNER JOIN Students ON Persons.personId=Students.studentId where Students.studentId=@studentId;";
		static private string queryStudentsPost = "INSERT INTO Persons (personId, personFirstName, personLastName, personBeforeTelephone, personTelephone, personBeforeCellphone, personCellphone, personCode) VALUES (@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode); " +
												  "INSERT INTO Students (studentId, studentType, studentYear, studentFacultyCode) VALUES (@studentId, @studentType, @studentYear, @studentFacultyCode);";
		static private string queryStudentsUpdate = "UPDATE Persons SET personId = @personId, personFirstName = @personFirstName, personLastName = @personLastName, personBeforeTelephone = @personBeforeTelephone, personTelephone = @personTelephone, personBeforeCellphone = @personBeforeCellphone, personCellphone = @personCellphone, personCode = @personCode WHERE personId = @personId; " +
														"UPDATE Students SET studentId = @studentId, studentType = @studentType, studentYear = @studentYear, studentFacultyCode = @studentFacultyCode WHERE studentId = @studentId;";
		static private string queryStudentsDelete = "DELETE FROM Students WHERE studentId = @studentId; " + "DELETE FROM Persons WHERE personId=@studentId;";

		static private string procedureStudentsString = "CALL `Parking`.`GetAllStudents`();";
		static private string procedureStudentsByIdString = "CALL `Parking`.`GetOneStudentById`(@studentId);";
		static private string procedureStudentsPost = "CALL `Parking`.`AddStudent`(@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @studentId, @studentType, @studentYear, @studentFacultyCode);";
		static private string procedureStudentsUpdate = "CALL `Parking`.`UpdateStudent`(@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @studentId, @studentType, @studentYear, @studentFacultyCode);";
		static private string procedureStudentsDelete = "CALL `Parking`.`DeleteStudent`(@studentId);";

		static public MySqlCommand GetAllStudents()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryStudentsString);
			else
				return CreateSqlCommand(procedureStudentsString);
		}

		static public MySqlCommand GetOneStudentById(string studentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentId, queryStudentsByIdString);
			else
				return CreateSqlCommand(studentId, procedureStudentsByIdString);
		}

		static public MySqlCommand AddStudent(StudentModel studentModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentModel, queryStudentsPost);
			else
				return CreateSqlCommand(studentModel, procedureStudentsPost);
		}

		static public MySqlCommand UpdateStudent(StudentModel studentModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentModel, queryStudentsUpdate);
			else
				return CreateSqlCommand(studentModel, procedureStudentsUpdate);
		}

		static public MySqlCommand DeleteStudent(string studentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentId, queryStudentsDelete);
			else
				return CreateSqlCommand(studentId, procedureStudentsDelete);
		}

		static private MySqlCommand CreateSqlCommand(StudentModel student, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);
			command.Parameters.AddWithValue("@personId", student.personId);
			command.Parameters.AddWithValue("@personFirstName", student.personFirstName);
			command.Parameters.AddWithValue("@personLastName", student.personLastName);
			command.Parameters.AddWithValue("@personBeforeTelephone", student.personBeforeTelephone);
			command.Parameters.AddWithValue("@personTelephone", student.personTelephone);
			command.Parameters.AddWithValue("@personBeforeCellphone", student.personBeforeCellphone);
			command.Parameters.AddWithValue("@personCellphone", student.personCellphone);
			command.Parameters.AddWithValue("@personCode", student.personCode);
			command.Parameters.AddWithValue("@studentId", student.studentId);
			command.Parameters.AddWithValue("@studentType", student.studentType);
			command.Parameters.AddWithValue("@studentYear", student.studentYear);
			command.Parameters.AddWithValue("@studentFacultyCode", student.studentFacultyCode);
			return command;
		}

		static private MySqlCommand CreateSqlCommand(string studentId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@studentId", studentId);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
