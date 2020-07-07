using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class StudentStringsInner
	{
		static private string queryStudentsString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Students.studentId, Students.studentFacultyCode, Students.studentYear, Students.studentType From Persons INNER JOIN Students ON Persons.personId=Students.studentId;";
		static private string queryStudentsByIdString = "SELECT Persons.personId, Persons.personFirstName, Persons.personLastName, Persons.personBeforeTelephone, Persons.personTelephone, Persons.personBeforeCellphone, Persons.personCellphone, Persons.personCode, Students.studentId, Students.studentFacultyCode, Students.studentYear, Students.studentType From Persons INNER JOIN Students ON Persons.personId=Students.studentId where Students.studentId=@studentId";
		static private string queryStudentsPost = "INSERT INTO Persons (personId, personFirstName, personLastName, personBeforeTelephone, personTelephone, personBeforeCellphone, personCellphone, personCode) VALUES (@personId, @personFirstName, @personLastName, @personBeforeTelephone, @personTelephone, @personBeforeCellphone, @personCellphone, @personCode); " +
												  "INSERT INTO Students (studentId, studentType, studentYear, studentFacultyCode) VALUES (@studentId, @studentType, @studentYear, @studentFacultyCode);";
		static private string queryStudentsUpdate = "UPDATE Persons SET personId = @personId, personFirstName = @personFirstName, personLastName = @personLastName, personBeforeTelephone = @personBeforeTelephone, personTelephone = @personTelephone, personBeforeCellphone = @personBeforeCellphone, personCellphone = @personCellphone, personCode = @personCode WHERE personId = @personId; " +
														"UPDATE Students SET studentId = @studentId, studentType = @studentType, studentYear = @studentYear, studentFacultyCode = @studentFacultyCode WHERE studentId = @studentId;";
		static private string queryStudentsDelete = "DELETE FROM Students WHERE studentId=@studentId; " + "DELETE FROM Persons WHERE personId=@studentId;";

		static public OleDbCommand GetAllStudents()
		{
			return CreateOleDbCommand(queryStudentsString);
		}

		static public OleDbCommand GetOneStudentById(string studentId)
		{
			return CreateOleDbCommand(studentId, queryStudentsByIdString);
		}

		static public OleDbCommand AddStudent(StudentModel studentModel)
		{
			return CreateOleDbCommand(studentModel, queryStudentsPost);
		}

		static public OleDbCommand UpdateStudent(StudentModel studentModel)
		{
			return CreateOleDbCommand(studentModel, queryStudentsUpdate);
		}

		static public OleDbCommand DeleteStudent(string studentId)
		{
			return CreateOleDbCommand(studentId, queryStudentsDelete);
		}

		static private OleDbCommand CreateOleDbCommand(StudentModel student, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);
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

		static private OleDbCommand CreateOleDbCommand(string studentId, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@studentId", studentId);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
