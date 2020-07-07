using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	public class SqlFacultyManager : SqlDataBase, IFacultyRepository
	{
		public List<FacultyModel> GetAllFaculties()
		{
			DataTable dt = new DataTable();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsSql.GetAllFaculties());
			}

			List<FacultyModel> arrFaculty = new List<FacultyModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrFaculty.Add(FacultyModel.ToObject(ms));
			}

			return arrFaculty;
		}


		public FacultyModel GetOneFacultyByCode(string facultyCode)
		{
			DataTable dt = new DataTable();

			if (facultyCode.Equals(string.Empty) || facultyCode.Equals(""))
				throw new ArgumentOutOfRangeException();
			FacultyModel facultyModel = new FacultyModel();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsSql.GetOneFacultyByCode(facultyCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				facultyModel = FacultyModel.ToObject(ms);
			}

			return facultyModel;
		}

		public FacultyModel AddFaculty(FacultyModel facultyModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsSql.AddFaculty(facultyModel));
			}

			foreach (DataRow ms in dt.Rows)
			{
				facultyModel = FacultyModel.ToObject(ms);
			}

			return facultyModel;
		}


		public FacultyModel UpdateFaculty(FacultyModel facultyModel)
		{
			DataTable dt = new DataTable();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsSql.UpdateFaculty(facultyModel));
			}
			foreach (DataRow ms in dt.Rows)
			{
				facultyModel = FacultyModel.ToObject(ms);
			}

			return facultyModel;
		}

		public int DeleteFaculty(string facultyCode)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(FacultyStringsSql.DeleteFaculty(facultyCode));
			}

			return i;
		}
	}
}
