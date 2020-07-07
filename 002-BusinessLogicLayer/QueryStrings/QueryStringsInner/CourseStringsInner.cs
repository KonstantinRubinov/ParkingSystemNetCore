using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class CourseStringsInner
	{
		static private string queryCoursesString = "SELECT * from Courses";
		static private string queryCoursesByCodeString = "SELECT * from Courses where courseCode=@courseCode";
		static private string queryCoursesByNameString = "SELECT * from Courses where courseName=@courseName";
		static private string queryCoursesPost = "INSERT INTO Courses (courseCode, courseName) VALUES (@courseCode, @courseName);" + queryCoursesByCodeString;
		static private string queryCoursesUpdate = "UPDATE Courses SET courseCode = @courseCode, courseName = @courseName where courseCode=@courseCode;" + queryCoursesByCodeString;
		static private string queryCoursesDelete = "DELETE FROM Courses WHERE courseCode=@courseCode";


		static public OleDbCommand GetAllCourses()
		{
			return CreateOleDbCommand(queryCoursesString);
		}

		static public OleDbCommand GetOneCourseByCode(string courseCode)
		{
			return CreateOleDbCommandCode(courseCode, queryCoursesByCodeString);
		}

		static public OleDbCommand GetOneCourseByName(string courseName)
		{
			return CreateOleDbCommandName(courseName, queryCoursesByNameString);
		}

		static public OleDbCommand AddCourse(CourseModel courseModel)
		{
			return CreateOleDbCommand(courseModel, queryCoursesPost);
		}

		static public OleDbCommand UpdateCourse(CourseModel courseModel)
		{
			return CreateOleDbCommand(courseModel, queryCoursesUpdate);
		}

		static public OleDbCommand DeleteCourse(string courseCode)
		{
			return CreateOleDbCommandCode(courseCode, queryCoursesDelete);
		}



		static private OleDbCommand CreateOleDbCommand(CourseModel course, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@courseCode", course.courseCode);
			command.Parameters.AddWithValue("@courseName", course.courseName);

			return command;
		}



		static private OleDbCommand CreateOleDbCommandCode(string courseCode, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@courseCode", courseCode);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandName(string courseName, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@courseName", courseName);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
