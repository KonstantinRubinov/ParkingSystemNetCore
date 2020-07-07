namespace ParkingSystemCoreBLL
{
	public interface IParkingDatabaseSettings
	{
		string ApprovalsCollectionName { get; set; }
		string ApprovalTypesCollectionName { get; set; }
		string CellphonesCollectionName { get; set; }
		string CourseCollectionName { get; set; }
		string FacultyCollectionName { get; set; }
		string PersonCollectionName { get; set; }
		string StudentCollectionName { get; set; }
		string TeacherCollectionName { get; set; }
		string TelephoneCollectionName { get; set; }
		string VehicleCollectionName { get; set; }

		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
