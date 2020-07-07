using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class MongoApprovalTypeManager : IApprovalTypesRepository
	{
		private readonly IMongoCollection<ApprovalTypeModel> _approvalTypes;

		public MongoApprovalTypeManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_approvalTypes = database.GetCollection<ApprovalTypeModel>(settings.ApprovalTypesCollectionName);
		}

		public MongoApprovalTypeManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_approvalTypes = database.GetCollection<ApprovalTypeModel>(ConnectionStrings.ApprovalTypesCollectionName);
		}

		public List<ApprovalTypeModel> GetAllApprovalTypes()
		{
			return _approvalTypes.Find(approvalType => true).Project(at => new ApprovalTypeModel
			{
				approvalCode = at.approvalCode,
				approvalName = at.approvalName
			}).ToList();
		}


		public ApprovalTypeModel GetOneApprovalTypeByCode(string approvalCode)
		{
			if (approvalCode.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _approvalTypes.Find<ApprovalTypeModel>(Builders<ApprovalTypeModel>.Filter.Eq(approvalType => approvalType.approvalCode, approvalCode)).Project(at => new ApprovalTypeModel
			{
				approvalCode = at.approvalCode,
				approvalName = at.approvalName
			}).FirstOrDefault();
		}


		public ApprovalTypeModel AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			if (_approvalTypes.Find<ApprovalTypeModel>(Builders<ApprovalTypeModel>.Filter.Eq(approvalType => approvalType.approvalCode, approvalTypeModel.approvalCode)).FirstOrDefault() == null)
			{
				_approvalTypes.InsertOne(approvalTypeModel);
			}

			ApprovalTypeModel tmpApprovalTypeModel = GetOneApprovalTypeByCode(approvalTypeModel.approvalCode);
			return tmpApprovalTypeModel;
		}


		public ApprovalTypeModel UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			_approvalTypes.ReplaceOne(approvalType => approvalType.approvalCode.Equals(approvalTypeModel.approvalCode), approvalTypeModel);
			ApprovalTypeModel tmpApprovalTypeModel = GetOneApprovalTypeByCode(approvalTypeModel.approvalCode);
			return tmpApprovalTypeModel;
		}


		public int DeleteApprovalType(string approvalCode)
		{
			_approvalTypes.DeleteOne(approvalType => approvalType.approvalCode.Equals(approvalCode));
			return 1;
		}
	}
}
