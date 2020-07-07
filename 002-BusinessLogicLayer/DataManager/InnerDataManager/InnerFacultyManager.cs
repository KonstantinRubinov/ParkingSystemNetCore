using lcpi.data.oledb;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class InnerFacultyManager : dbAccess, IFacultyRepository
	{
		public InnerFacultyManager(string connectionString) : base(connectionString)
		{
		}


		public List<FacultyModel> GetAllFaculties()
		{
			DataTable dt = new DataTable();

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(FacultyStringsInner.GetAllFaculties());
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

			using (OleDbCommand command = new OleDbCommand())
			{
				dt = GetMultipleQuery(FacultyStringsInner.GetOneFacultyByCode(facultyCode));
			}

			foreach (DataRow ms in dt.Rows)
			{
				facultyModel = FacultyModel.ToObject(ms);
			}

			return facultyModel;
		}

		public FacultyModel AddFaculty(FacultyModel facultyModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(FacultyStringsInner.AddFaculty(facultyModel));
			}

			return GetOneFacultyByCode(facultyModel.facultyCode);
		}


		public FacultyModel UpdateFaculty(FacultyModel facultyModel)
		{
			int i = -1;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(FacultyStringsInner.UpdateFaculty(facultyModel));
			}

			return GetOneFacultyByCode(facultyModel.facultyCode);
		}

		public int DeleteFaculty(string facultyCode)
		{
			int i = 0;
			using (OleDbCommand command = new OleDbCommand())
			{
				i = ExecuteNonQuery(FacultyStringsInner.DeleteFaculty(facultyCode));
			}

			return i;
		}
	}
}
