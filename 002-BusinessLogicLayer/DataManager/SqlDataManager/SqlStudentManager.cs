using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlStudentManager : SqlDataBase, IStudentRepository
	{
		public List<StudentModel> GetAllStudents()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsSql.GetAllStudents());
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsSql.GetOneStudentById(studentId));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsSql.AddStudent(studentModel));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(StudentStringsSql.UpdateStudent(studentModel));
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
				using (SqlCommand command = new SqlCommand())
				{
					i = ExecuteNonQuery(StudentStringsSql.DeleteStudent(studentId));
				}

			}
			return i;
		}
	}
}
