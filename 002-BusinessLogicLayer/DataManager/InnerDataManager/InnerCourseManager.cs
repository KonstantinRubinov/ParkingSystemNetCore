using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerCourseManager : dbAccess, ICourseRepository
	{
		public InnerCourseManager(string connectionString) : base(connectionString)
		{
		}

		public List<CourseModel> GetAllCourses()
		{
			DataTable dt = new DataTable();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(CourseStringsInner.GetAllCourses());
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

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(CourseStringsInner.GetOneCourseByCode(courseCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				courseModel = CourseModel.ToObject(ms);
			}

			return courseModel;
		}

		public CourseModel AddCourse(CourseModel courseModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(CourseStringsInner.AddCourse(courseModel));
			}

			return GetOneCourseByCode(courseModel.courseCode);
		}


		public CourseModel UpdateCourse(CourseModel courseModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(CourseStringsInner.UpdateCourse(courseModel));
			}

			return GetOneCourseByCode(courseModel.courseCode);
		}

		public int DeleteCourse(string courseCode)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(CourseStringsInner.DeleteCourse(courseCode));
			}

			return i;
		}
	}
}
