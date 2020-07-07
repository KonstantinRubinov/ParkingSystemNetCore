using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlFacultyManager : MySqlDataBase, IFacultyRepository
	{
		public List<FacultyModel> GetAllFaculties()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsMySql.GetAllFaculties());
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsMySql.GetOneFacultyByCode(facultyCode));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsMySql.AddFaculty(facultyModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(FacultyStringsMySql.UpdateFaculty(facultyModel));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(FacultyStringsMySql.DeleteFaculty(facultyCode));
			}
			
			return i;
		}
	}
}
