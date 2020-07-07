using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class MongoFacultyManager : IFacultyRepository
	{
		private readonly IMongoCollection<FacultyModel> _faculties;

		public MongoFacultyManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_faculties = database.GetCollection<FacultyModel>(settings.FacultyCollectionName);
		}

		public MongoFacultyManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_faculties = database.GetCollection<FacultyModel>(ConnectionStrings.FacultyCollectionName);
		}

		public List<FacultyModel> GetAllFaculties()
		{
			return _faculties.Find(faculty => true).Project(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyName = f.facultyName,
				facultyHead = f.facultyHead
			}).ToList();
		}


		public FacultyModel GetOneFacultyByCode(string facultyCode)
		{
			if (facultyCode.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _faculties.Find<FacultyModel>(Builders<FacultyModel>.Filter.Eq(faculty => faculty.facultyCode, facultyCode)).Project(f => new FacultyModel
			{
				facultyCode = f.facultyCode,
				facultyName = f.facultyName,
				facultyHead = f.facultyHead
			}).FirstOrDefault();
		}


		public FacultyModel AddFaculty(FacultyModel facultyModel)
		{
			if (_faculties.Find<FacultyModel>(Builders<FacultyModel>.Filter.Eq(faculty => faculty.facultyCode, facultyModel.facultyCode)).FirstOrDefault() == null)
			{
				_faculties.InsertOne(facultyModel);
			}

			FacultyModel tmpFacultyModel = GetOneFacultyByCode(facultyModel.facultyCode);
			return tmpFacultyModel;
		}


		public FacultyModel UpdateFaculty(FacultyModel facultyModel)
		{
			_faculties.ReplaceOne(faculty => faculty.facultyCode.Equals(facultyModel.facultyCode), facultyModel);
			FacultyModel tmpFacultyModel = GetOneFacultyByCode(facultyModel.facultyCode);
			return tmpFacultyModel;
		}


		public int DeleteFaculty(string facultyCode)
		{
			_faculties.DeleteOne(faculty => faculty.facultyCode.Equals(facultyCode));
			return 1;
		}
	}
}
