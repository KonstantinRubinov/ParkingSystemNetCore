using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlStudentManager : MySqlDataBase, IStudentRepository
	{
		public List<StudentModel> GetAllStudents()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsMySql.GetAllStudents());
			}

			List<StudentModel> arrStudent = new List<StudentModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrStudent.Add(StudentModel.ToObject(ms));
			}

			return arrStudent;
		}


		public StudentModel GetOneStudentById(string studentId)
		{
			DataTable dt = new DataTable();

			if (studentId.Equals(string.Empty) || studentId.Equals(""))
				throw new ArgumentOutOfRangeException();
			StudentModel studentModel = new StudentModel();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsMySql.GetOneStudentById(studentId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				studentModel = StudentModel.ToObject(ms);
			}

			return studentModel;
		}

		public StudentModel AddStudent(StudentModel studentModel)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsMySql.AddStudent(studentModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				studentModel = StudentModel.ToObject(ms);
			}

			return studentModel;
		}


		public StudentModel UpdateStudent(StudentModel studentModel)
		{
			DataTable dt = new DataTable();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsMySql.UpdateStudent(studentModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				studentModel = StudentModel.ToObject(ms);
			}

			return studentModel;
		}

		public int DeleteStudent(string studentId)
		{
			int i = 0;
			if (GetOneStudentById(studentId) != null)
			{
				using (MySqlCommand command = new MySqlCommand())
				{
					i = ExecuteNonQuery(StudentStringsMySql.DeleteStudent(studentId));
				}
				
			}
			return i;
		}
	}
}
