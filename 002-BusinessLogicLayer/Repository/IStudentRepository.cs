using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface IStudentRepository
	{
		List<StudentModel> GetAllStudents();
		StudentModel GetOneStudentById(string studentId);
		StudentModel AddStudent(StudentModel studentModel);
		StudentModel UpdateStudent(StudentModel studentModel);
		int DeleteStudent(string studentId);
	}
}
