using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlCourseManager : MySqlDataBase, ICourseRepository
	{
		public List<CourseModel> GetAllCourses()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsMySql.GetAllCourses());
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsMySql.GetOneCourseByCode(courseCode));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsMySql.AddCourse(courseModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(CourseStringsMySql.UpdateCourse(courseModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(CourseStringsMySql.DeleteCourse(courseCode));
			}
			
			return i;
		}
	}
}
