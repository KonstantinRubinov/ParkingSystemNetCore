using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlTeacherManager : MySqlDataBase, ITeacherRepository
	{
		public List<TeacherModel> GetAllTeachers()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsMySql.GetAllTeachers());
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsMySql.GetOneTeacherById(teacherId));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsMySql.AddTeacher(teacherModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TeacherStringsMySql.UpdateTeacher(teacherModel));
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
				using (MySqlCommand command = new MySqlCommand())
				{
					i = ExecuteNonQuery(TeacherStringsMySql.DeleteTeacher(teacherId));
				}
				
			}
			return i;
		}
	}
}
