using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class MongoPersonManager : IPersonRepository
	{
		private readonly IMongoCollection<PersonModel> _persons;

		public MongoPersonManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(settings.PersonCollectionName);
		}

		public MongoPersonManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(ConnectionStrings.PersonCollectionName);
		}

		public List<PersonModel> GetAllPersons()
		{
			return _persons.Find(persons => true).Project(p => new PersonModel
			{
				personId = p.personId,
				personFirstName = p.personFirstName,
				personLastName = p.personLastName,
				personBeforeTelephone = p.personBeforeTelephone,
				personTelephone = p.personTelephone,
				personBeforeCellphone = p.personBeforeCellphone,
				personCellphone = p.personCellphone,
				personCode = p.personCode
			}).ToList();
		}


		public List<PersonModel> GetAllPersonsId()
		{
			return _persons.Find(persons => true).Project(p => new PersonModel
			{
				personId = p.personId
			}).ToList();
		}


		public PersonModel GetOnePersonById(string personId)
		{
			if (personId.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _persons.Find<PersonModel>(Builders<PersonModel>.Filter.Eq(person => person.personId, personId)).Project(p => new PersonModel
			{
				personId = p.personId,
				personFirstName = p.personFirstName,
				personLastName = p.personLastName,
				personBeforeTelephone = p.personBeforeTelephone,
				personTelephone = p.personTelephone,
				personBeforeCellphone = p.personBeforeCellphone,
				personCellphone = p.personCellphone,
				personCode = p.personCode
			}).FirstOrDefault();
		}


		public int DeletePerson(string personId)
		{
			_persons.DeleteOne(person => person.personId.Equals(personId));
			return 1;
		}


		public bool checkIfIdExists(string id)
		{
			if (id.Equals(string.Empty) || id.Equals(""))
				throw new ArgumentOutOfRangeException();

			return _persons.Find<PersonModel>(person => person.personId.Equals(id)).Any();
		}
	}
}
