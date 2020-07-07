using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class MongoCellphoneManager : ICellphoneRepository
	{
		private readonly IMongoCollection<CellphoneModel> _cellphone;

		public MongoCellphoneManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_cellphone = database.GetCollection<CellphoneModel>(settings.CellphonesCollectionName);
		}

		public MongoCellphoneManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_cellphone = database.GetCollection<CellphoneModel>(ConnectionStrings.CellphonesCollectionName);
		}

		public List<CellphoneModel> GetAllCellphones()
		{
			return _cellphone.Find(cellphone => true).Project(cp => new CellphoneModel
			{
				beforeCellphone = cp.beforeCellphone
			}).ToList();
		}


		public CellphoneModel GetOneBeforeCellphone(string beforeCellphone1)
		{
			if (beforeCellphone1.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _cellphone.Find<CellphoneModel>(Builders<CellphoneModel>.Filter.Eq(cellphone => cellphone.beforeCellphone, beforeCellphone1)).Project(cp => new CellphoneModel
			{
				beforeCellphone = cp.beforeCellphone
			}).FirstOrDefault();
		}


		public CellphoneModel AddCellphone(CellphoneModel cellphoneModel)
		{
			if (GetOneBeforeCellphone(cellphoneModel.beforeCellphone) == null)
			{
				_cellphone.InsertOne(cellphoneModel);
			}

			CellphoneModel tmpCellphoneModel = GetOneBeforeCellphone(cellphoneModel.beforeCellphone);
			return tmpCellphoneModel;
		}


		public CellphoneModel UpdateCellphone(CellphoneModel cellphoneModel)
		{
			_cellphone.ReplaceOne(cellphone => cellphone.beforeCellphone.Equals(cellphoneModel.beforeCellphone), cellphoneModel);
			CellphoneModel tmpCellphoneModel = GetOneBeforeCellphone(cellphoneModel.beforeCellphone);
			return tmpCellphoneModel;
		}


		public int DeleteCellphone(string beforeCellphone1)
		{
			_cellphone.DeleteOne(cellphone => cellphone.beforeCellphone.Equals(beforeCellphone1));
			return 1;
		}
	}
}
