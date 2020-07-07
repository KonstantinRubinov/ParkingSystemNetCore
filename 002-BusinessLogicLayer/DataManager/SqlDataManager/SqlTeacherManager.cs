using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlTeacherManager : SqlDataBase, ITeacherRepository
	{
		public List<TeacherModel> GetAllTeachers()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsSql.GetAllTeachers());
			}

			List<TeacherModel> arrTeacher = new List<TeacherModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrTeacher.Add(TeacherModel.ToObject(ms));
			}
			return arrTeacher;
		}


		public TeacherModel GetOneTeacherById(string teacherId)
		{
			DataTable dt = new DataTable();

			if (teacherId.Equals(string.Empty) || teacherId.Equals(""))
				throw new ArgumentOutOfRangeException();
			TeacherModel teacherModel = new TeacherModel();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsSql.GetOneTeacherById(teacherId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				teacherModel = TeacherModel.ToObject(ms);
			}

			return teacherModel;
		}

		public TeacherModel AddTeacher(TeacherModel teacherModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsSql.AddTeacher(teacherModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				teacherModel = TeacherModel.ToObject(ms);
			}

			return teacherModel;
		}


		public TeacherModel UpdateTeacher(TeacherModel teacherModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsSql.UpdateTeacher(teacherModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				teacherModel = TeacherModel.ToObject(ms);
			}

			return teacherModel;
		}

		public int DeleteTeacher(string teacherId)
		{
			int i = 0;
			if (GetOneTeacherById(teacherId) != null)
			{
				using (SqlCommand command = new SqlCommand())
				{
					i = ExecuteNonQuery(TeacherStringsSql.DeleteTeacher(teacherId));
				}

			}
			return i;
		}
	}
}
