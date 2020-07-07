using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class MongoApprovalManager : IApprovalRepository
	{
		private readonly IMongoCollection<ApprovalModel> _approvals;

		public MongoApprovalManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_approvals = database.GetCollection<ApprovalModel>(settings.ApprovalsCollectionName);
		}

		public MongoApprovalManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_approvals = database.GetCollection<ApprovalModel>(ConnectionStrings.ApprovalsCollectionName);
		}

		public List<ApprovalModel> GetAllApprovals()
		{
			return _approvals.Find(approval => true).Project(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			}).ToList();
		}


		public ApprovalModel GetOneApprovalByCode(string approvalCode)
		{
			if (approvalCode.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _approvals.Find<ApprovalModel>(Builders<ApprovalModel>.Filter.Eq(approval => approval.approvalCode, approvalCode)).Project(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			}).FirstOrDefault();
		}


		public ApprovalModel GetOneApprovalByPersonId(string personId)
		{
			if (personId.Equals(string.Empty))
				throw new ArgumentOutOfRangeException();

			return _approvals.Find<ApprovalModel>(Builders<ApprovalModel>.Filter.Eq(approval => approval.approvalPersonId, personId)).Project(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			}).FirstOrDefault();
		}


		public ApprovalModel GetOneApprovalByNumber(int approvalNumber)
		{
			if (approvalNumber<0)
				throw new ArgumentOutOfRangeException();

			return _approvals.Find<ApprovalModel>(Builders<ApprovalModel>.Filter.Eq(approval => approval.approvalNumber, approvalNumber)).Project(a => new ApprovalModel
			{
				approvalCode = a.approvalCode,
				approvalFrom = a.approvalFrom,
				approvalUntil = a.approvalUntil,
				approvalPersonId = a.approvalPersonId,
				approvalNumber = a.approvalNumber
			}).FirstOrDefault();
		}


		public ApprovalModel AddApproval(ApprovalModel approvalModel)
		{
			if (_approvals.Find<ApprovalModel>(Builders<ApprovalModel>.Filter.Eq(approval => approval.approvalPersonId, approvalModel.approvalPersonId)).FirstOrDefault() == null)
			{
				_approvals.InsertOne(approvalModel);
			}

			ApprovalModel tmpApprovalModel = GetOneApprovalByPersonId(approvalModel.approvalPersonId);
			return tmpApprovalModel;
		}


		public ApprovalModel UpdateApproval(ApprovalModel approvalModel)
		{
			_approvals.ReplaceOne(approval => approval.approvalNumber.Equals(approvalModel.approvalNumber), approvalModel);
			ApprovalModel tmpApprovalModel = GetOneApprovalByPersonId(approvalModel.approvalPersonId);
			return tmpApprovalModel;
		}


		public int DeleteApproval(int approvalNumber)
		{
			_approvals.DeleteOne(approval => approval.approvalNumber==approvalNumber);
			return 1;
		}


		public int DeleteApprovalById(string approvalPersonId)
		{
			_approvals.DeleteOne(approval => approval.approvalPersonId.Equals(approvalPersonId));
			return 1;
		}
	}
}
