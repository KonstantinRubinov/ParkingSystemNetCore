using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystemCoreBLL
{
	public class MongoTeacherManager : ITeacherRepository
	{
		private readonly IMongoCollection<PersonModel> _persons;
		private readonly IMongoCollection<TeacherModel> _teachers;

		public MongoTeacherManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(settings.PersonCollectionName);
			_teachers = database.GetCollection<TeacherModel>(settings.TeacherCollectionName);
		}

		public MongoTeacherManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(ConnectionStrings.PersonCollectionName);
			_teachers = database.GetCollection<TeacherModel>(ConnectionStrings.TeacherCollectionName);
		}

		public List<TeacherModel> GetAllTeachers()
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join teachers in _teachers.AsQueryable() on persons.personId equals teachers.teacherId

			select new TeacherModel
			{
				personId = persons.personId,
				personFirstName = persons.personFirstName,
				personLastName = persons.personLastName,
				personBeforeTelephone = persons.personBeforeTelephone,
				personTelephone = persons.personTelephone,
				personBeforeCellphone = persons.personBeforeCellphone,
				personCellphone = persons.personCellphone,
				personCode = persons.personCode,
				teacherId = teachers.teacherId,
				teacherFacultyCode = teachers.teacherFacultyCode,
				teacherStage = teachers.teacherStage
			};

			return resultQuary.ToList();
		}


		public TeacherModel GetOneTeacherById(string teacherId)
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join teachers in _teachers.AsQueryable() on persons.personId equals teachers.teacherId
			where (persons.personId.Equals(teacherId))
			select new TeacherModel
			{
				personId = persons.personId,
				personFirstName = persons.personFirstName,
				personLastName = persons.personLastName,
				personBeforeTelephone = persons.personBeforeTelephone,
				personTelephone = persons.personTelephone,
				personBeforeCellphone = persons.personBeforeCellphone,
				personCellphone = persons.personCellphone,
				personCode = persons.personCode,
				teacherId = teachers.teacherId,
				teacherFacultyCode = teachers.teacherFacultyCode,
				teacherStage = teachers.teacherStage
			};

			return resultQuary.SingleOrDefault();
		}


		public TeacherModel AddTeacher(TeacherModel teacherModel)
		{
			if (_persons.Find<PersonModel>(Builders<PersonModel>.Filter.Eq(person => person.personId, teacherModel.teacherId)).FirstOrDefault() == null)
			{
				PersonModel personModel = new PersonModel(teacherModel.personId, teacherModel.personFirstName, teacherModel.personLastName, teacherModel.personBeforeTelephone, teacherModel.personTelephone, teacherModel.personBeforeCellphone, teacherModel.personCellphone, teacherModel.personCode);
				_persons.InsertOne(personModel);
				_teachers.InsertOne(teacherModel);
			}

			TeacherModel tmpTeacherModel = GetOneTeacherById(teacherModel.teacherId);
			return tmpTeacherModel;
		}


		public TeacherModel UpdateTeacher(TeacherModel teacherModel)
		{
			PersonModel personModel = new PersonModel(teacherModel.personId, teacherModel.personFirstName, teacherModel.personLastName, teacherModel.personBeforeTelephone, teacherModel.personTelephone, teacherModel.personBeforeCellphone, teacherModel.personCellphone, teacherModel.personCode);
			_persons.ReplaceOne(person => person.personId.Equals(teacherModel.teacherId), personModel);
			_teachers.ReplaceOne(teacher => teacher.teacherId.Equals(teacherModel.teacherId), teacherModel);
			TeacherModel tmpTeacherModel = GetOneTeacherById(teacherModel.teacherId);
			return tmpTeacherModel;
		}


		public int DeleteTeacher(string teacherId)
		{
			_persons.DeleteOne(person => person.personId.Equals(teacherId));
			_teachers.DeleteOne(teacher => teacher.teacherId.Equals(teacherId));
			return 1;
		}
	}
}
