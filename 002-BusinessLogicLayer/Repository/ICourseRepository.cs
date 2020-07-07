using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface ICourseRepository
	{
		List<CourseModel> GetAllCourses();
		CourseModel GetOneCourseByCode(string courseCode);
		CourseModel AddCourse(CourseModel courseModel);
		CourseModel UpdateCourse(CourseModel courseModel);
		int DeleteCourse(string courseCode);
	}
}
