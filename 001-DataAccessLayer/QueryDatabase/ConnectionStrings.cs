namespace ParkingSystemCoreDAL
{
	static public class ConnectionStrings
	{
		static private string sqlConnectionString = "Data Source =.; Initial Catalog = Parking; Integrated Security = True";
		static private string mySqlConnectionString = "server=localhost; user id = root; persistsecurityinfo=True; password=Rk14101981; database=Parking; UseAffectedRows=True";

		static public string ConnectionString = "mongodb://localhost:27017";
		static public string DatabaseName = "Parking";
		static public string ApprovalsCollectionName = "Approvals";
		static public string ApprovalTypesCollectionName = "ApprovalTypes";
		static public string CellphonesCollectionName = "Cellphones";
		static public string CourseCollectionName = "Courses";
		static public string FacultyCollectionName = "Faculties";
		static public string PersonCollectionName = "Persons";
		static public string StudentCollectionName = "Students";
		static public string TeacherCollectionName = "Teachers";
		static public string TelephoneCollectionName = "Telephones";
		static public string VehicleCollectionName = "Vehicles";

		static public string GetSqlConnection()
		{
			return sqlConnectionString;
		}

		static public string GetMySqlConnection()
		{
			return mySqlConnectionString;
		}
	}
}
