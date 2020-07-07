using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface IFacultyRepository
	{
		List<FacultyModel> GetAllFaculties();
		FacultyModel GetOneFacultyByCode(string facultyCode);
		FacultyModel AddFaculty(FacultyModel facultyModel);
		FacultyModel UpdateFaculty(FacultyModel facultyModel);
		int DeleteFaculty(string facultyCode);
	}
}
