using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystemCoreBLL
{
	public class ParkingDatabaseSettings: IParkingDatabaseSettings
	{
		public string ApprovalsCollectionName { get; set; }
		public string ApprovalTypesCollectionName { get; set; }
		public string CellphonesCollectionName { get; set; }
		public string CourseCollectionName { get; set; }
		public string FacultyCollectionName { get; set; }
		public string PersonCollectionName { get; set; }
		public string StudentCollectionName { get; set; }
		public string TeacherCollectionName { get; set; }
		public string TelephoneCollectionName { get; set; }
		public string VehicleCollectionName { get; set; }

		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
