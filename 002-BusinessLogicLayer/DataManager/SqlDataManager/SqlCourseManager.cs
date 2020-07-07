using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlCourseManager : SqlDataBase, ICourseRepository
	{
		public List<CourseModel> GetAllCourses()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsSql.GetAllCourses());
			}

			List<CourseModel> arrCourse = new List<CourseModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrCourse.Add(CourseModel.ToObject(ms));
			}

			return arrCourse;
		}


		public CourseModel GetOneCourseByCode(string courseCode)
		{
			DataTable dt = new DataTable();

			if (courseCode.Equals(string.Empty) || courseCode.Equals(""))
				throw new ArgumentOutOfRangeException();
			CourseModel courseModel = new CourseModel();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsSql.GetOneCourseByCode(courseCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				courseModel = CourseModel.ToObject(ms);
			}

			return courseModel;
		}

		public CourseModel AddCourse(CourseModel courseModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsSql.AddCourse(courseModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				courseModel = CourseModel.ToObject(ms);
			}

			return courseModel;
		}


		public CourseModel UpdateCourse(CourseModel courseModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsSql.UpdateCourse(courseModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				courseModel = CourseModel.ToObject(ms);
			}

			return courseModel;
		}

		public int DeleteCourse(string courseCode)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(CourseStringsSql.DeleteCourse(courseCode));
			}

			return i;
		}
	}
}
