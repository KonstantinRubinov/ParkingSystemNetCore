using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class CourseStringsSql
	{
		static private string queryCoursesString = "SELECT * from Courses;";
		static private string queryCoursesByCodeString = "SELECT * from Courses where courseCode=@courseCode;";
		static private string queryCoursesByNameString = "SELECT * from Courses where courseName=@courseName;";
		static private string queryCoursesPost = "INSERT INTO Courses (courseCode, courseName) VALUES (@courseCode, @courseName);" + queryCoursesByCodeString;
		static private string queryCoursesUpdate = "UPDATE Courses SET courseCode = @courseCode, courseName = @courseName where courseCode=@courseCode;" + queryCoursesByCodeString;
		static private string queryCoursesDelete = "DELETE FROM Courses WHERE courseCode=@courseCode;";

		static private string procedureCoursesString = "EXEC GetAllCourses;";
		static private string procedureCoursesByCodeString = "EXEC GetOneCourseByCode @courseCode;";
		static private string procedureCoursesByNameString = "EXEC GetOneCourseByName @courseName;";
		static private string procedureCoursesPost = "EXEC AddCourse @courseCode, @courseName;";
		static private string procedureCoursesUpdate = "EXEC UpdateCourse @courseCode, @courseName;";
		static private string procedureCoursesDelete = "EXEC DeleteCourse @courseCode;";

		static public SqlCommand GetAllCourses()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryCoursesString);
			else
				return CreateSqlCommand(procedureCoursesString);
		}

		static public SqlCommand GetOneCourseByCode(string courseCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(courseCode, queryCoursesByCodeString);
			else
				return CreateSqlCommandCode(courseCode, procedureCoursesByCodeString);
		}

		static public SqlCommand GetOneCourseByName(string courseName)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(courseName, queryCoursesByNameString);
			else
				return CreateSqlCommandName(courseName, procedureCoursesByNameString);
		}

		static public SqlCommand AddCourse(CourseModel courseModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(courseModel, queryCoursesPost);
			else
				return CreateSqlCommand(courseModel, procedureCoursesPost);
		}

		static public SqlCommand UpdateCourse(CourseModel courseModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(courseModel, queryCoursesUpdate);
			else
				return CreateSqlCommand(courseModel, procedureCoursesUpdate);
		}

		static public SqlCommand DeleteCourse(string courseCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(courseCode, queryCoursesDelete);
			else
				return CreateSqlCommandCode(courseCode, procedureCoursesDelete);
		}

		static private SqlCommand CreateSqlCommand(CourseModel course, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@courseCode", course.courseCode);
			command.Parameters.AddWithValue("@courseName", course.courseName);

			return command;
		}

		static private SqlCommand CreateSqlCommandCode(string courseCode, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@courseCode", courseCode);

			return command;
		}

		static private SqlCommand CreateSqlCommandName(string courseName, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@courseName", courseName);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
