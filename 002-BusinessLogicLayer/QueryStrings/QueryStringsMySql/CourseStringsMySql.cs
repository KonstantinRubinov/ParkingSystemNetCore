using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class CourseStringsMySql
	{
		static private string queryCoursesString = "SELECT * from Courses;";
		static private string queryCoursesByCodeString = "SELECT * from Courses where courseCode=@courseCode;";
		static private string queryCoursesByNameString = "SELECT * from Courses where courseName=@courseName;";
		static private string queryCoursesPost = "INSERT INTO Courses (courseCode, courseName) VALUES (@courseCode, @courseName);" + queryCoursesByCodeString;
		static private string queryCoursesUpdate = "UPDATE Courses SET courseCode = @courseCode, courseName = @courseName where courseCode=@courseCode;" + queryCoursesByCodeString;
		static private string queryCoursesDelete = "DELETE FROM Courses WHERE courseCode=@courseCode;";

		static private string procedureCoursesString = "CALL `Parking`.`GetAllCourses`();";
		static private string procedureCoursesByCodeString = "CALL `Parking`.`GetOneCourseByCode`(@courseCode);";
		static private string procedureCoursesByNameString = "CALL `Parking`.`GetOneCourseByName`(@courseName);";
		static private string procedureCoursesPost = "CALL `Parking`.`AddCourse`(@courseCode, @courseName);";
		static private string procedureCoursesUpdate = "CALL `Parking`.`UpdateCourse`(@courseCode, @courseName);";
		static private string procedureCoursesDelete = "CALL `Parking`.`DeleteCourse`(@courseCode);";

		static public MySqlCommand GetAllCourses()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryCoursesString);
			else
				return CreateSqlCommand(procedureCoursesString);
		}

		static public MySqlCommand GetOneCourseByCode(string courseCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(courseCode, queryCoursesByCodeString);
			else
				return CreateSqlCommandCode(courseCode, procedureCoursesByCodeString);
		}

		static public MySqlCommand GetOneCourseByName(string courseName)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(courseName, queryCoursesByNameString);
			else
				return CreateSqlCommandName(courseName, procedureCoursesByNameString);
		}

		static public MySqlCommand AddCourse(CourseModel courseModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(courseModel, queryCoursesPost);
			else
				return CreateSqlCommand(courseModel, procedureCoursesPost);
		}

		static public MySqlCommand UpdateCourse(CourseModel courseModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(courseModel, queryCoursesUpdate);
			else
				return CreateSqlCommand(courseModel, procedureCoursesUpdate);
		}

		static public MySqlCommand DeleteCourse(string courseCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(courseCode, queryCoursesDelete);
			else
				return CreateSqlCommandCode(courseCode, procedureCoursesDelete);
		}

		static private MySqlCommand CreateSqlCommand(CourseModel course, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@courseCode", course.courseCode);
			command.Parameters.AddWithValue("@courseName", course.courseName);

			return command;
		}

		static private MySqlCommand CreateSqlCommandCode(string courseCode, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@courseCode", courseCode);

			return command;
		}

		static private MySqlCommand CreateSqlCommandName(string courseName, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@courseName", courseName);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
