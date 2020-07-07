using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class MongoTelephoneManager : ITelephoneRepository
	{
		private readonly IMongoCollection<TelephoneModel> _telephones;

		public MongoTelephoneManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_telephones = database.GetCollection<TelephoneModel>(settings.TelephoneCollectionName);
		}

		public MongoTelephoneManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_telephones = database.GetCollection<TelephoneModel>(ConnectionStrings.TelephoneCollectionName);
		}

		public List<TelephoneModel> GetAllTelephones()
		{
			return _telephones.Find(telephone => true).Project(tp => new TelephoneModel
			{
				beforeTelephone = tp.beforeTelephone
			}).ToList();
		}


		public TelephoneModel GetOneBeforeTelephone(string beforeTelephone1)
		{
			if (beforeTelephone1.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _telephones.Find<TelephoneModel>(Builders<TelephoneModel>.Filter.Eq(telephone => telephone.beforeTelephone, beforeTelephone1)).Project(tp => new TelephoneModel
			{
				beforeTelephone = tp.beforeTelephone
			}).FirstOrDefault();
		}


		public TelephoneModel AddTelephone(TelephoneModel telephoneModel)
		{
			if (GetOneBeforeTelephone(telephoneModel.beforeTelephone) == null)
			{
				_telephones.InsertOne(telephoneModel);
			}

			TelephoneModel tmpTelephoneModel = GetOneBeforeTelephone(telephoneModel.beforeTelephone);
			return tmpTelephoneModel;
		}


		public TelephoneModel UpdateTelephone(TelephoneModel telephoneModel)
		{
			_telephones.ReplaceOne(telephone => telephone.beforeTelephone.Equals(telephoneModel.beforeTelephone), telephoneModel);
			TelephoneModel tmpTelephoneModel = GetOneBeforeTelephone(telephoneModel.beforeTelephone);
			return tmpTelephoneModel;
		}


		public int DeleteTelephone(string beforeTelephone1)
		{
			_telephones.DeleteOne(telephone => telephone.beforeTelephone.Equals(beforeTelephone1));
			return 1;
		}
	}
}
