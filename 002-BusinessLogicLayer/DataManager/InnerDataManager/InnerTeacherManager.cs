using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerTeacherManager : dbAccess, ITeacherRepository
	{
		public InnerTeacherManager(string connectionString) : base(connectionString)
		{
		}

		public List<TeacherModel> GetAllTeachers()
		{
			DataTable dt = new DataTable();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(TeacherStringsInner.GetAllTeachers());
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(TeacherStringsInner.GetOneTeacherById(teacherId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				teacherModel = TeacherModel.ToObject(ms);
			}

			return teacherModel;
		}

		public TeacherModel AddTeacher(TeacherModel teacherModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(TeacherStringsInner.AddTeacher(teacherModel));
			}

			return GetOneTeacherById(teacherModel.teacherId);
		}


		public TeacherModel UpdateTeacher(TeacherModel teacherModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(TeacherStringsInner.UpdateTeacher(teacherModel));
			}

			return GetOneTeacherById(teacherModel.teacherId);
		}

		public int DeleteTeacher(string teacherId)
		{
			int i = 0;
			if (GetOneTeacherById(teacherId) != null)
			{
				using (OleDbCommand command = new OleDbCommand())
				{
					i = ExecuteNonQuery(TeacherStringsInner.DeleteTeacher(teacherId));
				}

			}
			return i;
		}
	}
}
