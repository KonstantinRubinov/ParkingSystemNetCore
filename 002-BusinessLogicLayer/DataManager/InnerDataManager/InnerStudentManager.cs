using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerStudentManager : dbAccess, IStudentRepository
	{
		public InnerStudentManager(string connectionString) : base(connectionString)
		{
		}

		public List<StudentModel> GetAllStudents()
		{
			DataTable dt = new DataTable();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(StudentStringsInner.GetAllStudents());
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
			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(StudentStringsInner.GetOneStudentById(studentId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				studentModel = StudentModel.ToObject(ms);
			}

			return studentModel;
		}

		public StudentModel AddStudent(StudentModel studentModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(StudentStringsInner.AddStudent(studentModel));
			}

			return GetOneStudentById(studentModel.studentId);
		}


		public StudentModel UpdateStudent(StudentModel studentModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(StudentStringsInner.UpdateStudent(studentModel));
			}

			return GetOneStudentById(studentModel.studentId);
		}

		public int DeleteStudent(string studentId)
		{
			int i = 0;
			if (GetOneStudentById(studentId) != null)
			{
				using (OleDbCommand command = new OleDbCommand())
				{
					i = ExecuteNonQuery(StudentStringsInner.DeleteStudent(studentId));
				}

			}
			return i;
		}
	}
}
