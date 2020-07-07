using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class StudentStringsSql
	{
		static private string queryStudentsString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Students.studentId, Students.studentFacultyCode, Students.studentYear, Students.studentType From Persons INNER JOIN Students ON Persons.personId=Students.studentId;";
		static private string queryStudentsByIdString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Students.studentId, Students.studentFacultyCode, Students.studentYear, Students.studentType From Persons INNER JOIN Students ON Persons.personId=Students.studentId where Students.studentId=@studentId;";
		static private string queryStudentsPost = "INSERT INTO Persons (personId, personFirstName, personLastName, personBeforeTelephone, personTelephone, personBeforeCellphone, personCellphone, personCode) VALUES (@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode); " +
												  "INSERT INTO Students (studentId, studentType, studentYear, studentFacultyCode) VALUES (@studentId, @studentType, @studentYear, @studentFacultyCode);";
		static private string queryStudentsUpdate = "UPDATE Persons SET personId = @personId, personFirstName = @personFirstName, personLastName = @personLastName, personBeforeTelephone = @personBeforeTelephone, personTelephone = @personTelephone, personBeforeCellphone = @personBeforeCellphone, personCellphone = @personCellphone, personCode = @personCode WHERE personId = @personId; " +
														"UPDATE Students SET studentId = @studentId, studentType = @studentType, studentYear = @studentYear, studentFacultyCode = @studentFacultyCode WHERE studentId = @studentId;";
		static private string queryStudentsDelete = "DELETE FROM Students WHERE studentId = @studentId; " + "DELETE FROM Persons WHERE personId=@studentId;";

		static private string procedureStudentsString = "EXEC GetAllStudents;";
		static private string procedureStudentsByIdString = "EXEC GetOneStudentById @studentId;";
		static private string procedureStudentsPost = "EXEC AddStudent @personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @studentId, @studentType, @studentYear, @studentFacultyCode;";
		static private string procedureStudentsUpdate = "EXEC UpdateStudent @personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode, @studentId, @studentType, @studentYear, @studentFacultyCode;";
		static private string procedureStudentsDelete = "EXEC DeleteStudent @studentId;";

		static public SqlCommand GetAllStudents()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryStudentsString);
			else
				return CreateSqlCommand(procedureStudentsString);
		}

		static public SqlCommand GetOneStudentById(string studentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentId, queryStudentsByIdString);
			else
				return CreateSqlCommand(studentId, procedureStudentsByIdString);
		}

		static public SqlCommand AddStudent(StudentModel studentModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentModel, queryStudentsPost);
			else
				return CreateSqlCommand(studentModel, procedureStudentsPost);
		}

		static public SqlCommand UpdateStudent(StudentModel studentModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentModel, queryStudentsUpdate);
			else
				return CreateSqlCommand(studentModel, procedureStudentsUpdate);
		}

		static public SqlCommand DeleteStudent(string studentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(studentId, queryStudentsDelete);
			else
				return CreateSqlCommand(studentId, procedureStudentsDelete);
		}

		static private SqlCommand CreateSqlCommand(StudentModel student, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);
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

		static private SqlCommand CreateSqlCommand(string studentId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@studentId", studentId);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
