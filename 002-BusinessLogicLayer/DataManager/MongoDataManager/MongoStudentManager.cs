using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystemCoreBLL
{
	public class MongoStudentManager : IStudentRepository
	{
		private readonly IMongoCollection<PersonModel> _persons;
		private readonly IMongoCollection<StudentModel> _students;

		public MongoStudentManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(settings.PersonCollectionName);
			_students = database.GetCollection<StudentModel>(settings.StudentCollectionName);
		}

		public MongoStudentManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(ConnectionStrings.PersonCollectionName);
			_students = database.GetCollection<StudentModel>(ConnectionStrings.StudentCollectionName);
		}

		public List<StudentModel> GetAllStudents()
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join students in _students.AsQueryable() on persons.personId equals students.studentId

			select new StudentModel
			{
				personId = persons.personId,
				personFirstName = persons.personFirstName,
				personLastName = persons.personLastName,
				personBeforeTelephone = persons.personBeforeTelephone,
				personTelephone = persons.personTelephone,
				personBeforeCellphone = persons.personBeforeCellphone,
				personCellphone = persons.personCellphone,
				personCode = persons.personCode,
				studentId = students.studentId,
				studentType = students.studentType,
				studentYear = students.studentYear,
				studentFacultyCode = students.studentFacultyCode
			};

			return resultQuary.ToList();
		}


		public StudentModel GetOneStudentById(string studentId)
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join students in _students.AsQueryable() on persons.personId equals students.studentId
			where (persons.personId.Equals(studentId))
			select new StudentModel
			{
				personId = persons.personId,
				personFirstName = persons.personFirstName,
				personLastName = persons.personLastName,
				personBeforeTelephone = persons.personBeforeTelephone,
				personTelephone = persons.personTelephone,
				personBeforeCellphone = persons.personBeforeCellphone,
				personCellphone = persons.personCellphone,
				personCode = persons.personCode,
				studentId = students.studentId,
				studentType = students.studentType,
				studentYear = students.studentYear,
				studentFacultyCode = students.studentFacultyCode
			};

			return resultQuary.SingleOrDefault();
		}


		public StudentModel AddStudent(StudentModel studentModel)
		{
			if (_persons.Find<PersonModel>(Builders<PersonModel>.Filter.Eq(person => person.personId, studentModel.studentId)).FirstOrDefault() == null)
			{
				PersonModel personModel = new PersonModel(studentModel.personId, studentModel.personFirstName, studentModel.personLastName, studentModel.personBeforeTelephone, studentModel.personTelephone, studentModel.personBeforeCellphone, studentModel.personCellphone, studentModel.personCode);
				_persons.InsertOne(personModel);
				_students.InsertOne(studentModel);
			}

			StudentModel tmpStudentModel = GetOneStudentById(studentModel.studentId);
			return tmpStudentModel;
		}


		public StudentModel UpdateStudent(StudentModel studentModel)
		{
			PersonModel personModel = new PersonModel(studentModel.personId, studentModel.personFirstName, studentModel.personLastName, studentModel.personBeforeTelephone, studentModel.personTelephone, studentModel.personBeforeCellphone, studentModel.personCellphone, studentModel.personCode);
			_persons.ReplaceOne(person => person.personId.Equals(studentModel.studentId), personModel);
			_students.ReplaceOne(student => student.studentId.Equals(studentModel.studentId), studentModel);
			StudentModel tmpStudentModel = GetOneStudentById(studentModel.studentId);
			return tmpStudentModel;
		}


		public int DeleteStudent(string studentId)
		{
			_persons.DeleteOne(person => person.personId.Equals(studentId));
			_students.DeleteOne(student => student.studentId.Equals(studentId));
			return 1;
		}
	}
}
