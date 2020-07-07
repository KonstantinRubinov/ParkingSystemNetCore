using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class ApprovalModel
	{
		private string _approvalCode;
		private DateTime _approvalFrom;
		private DateTime _approvalUntil;
		private string _approvalPersonId;
		private int _approvalNumber;

		[DataMember]
		public string approvalCode
		{
			set
			{
				_approvalCode = value;
			}

			get
			{
				return _approvalCode;
			}
		}

		[DataMember]
		public DateTime approvalFrom
		{
			set
			{
				_approvalFrom = value;
			}

			get
			{
				return _approvalFrom;
			}
		}

		[DataMember]
		public DateTime approvalUntil
		{
			set
			{
				_approvalUntil = value;
			}

			get
			{
				return _approvalUntil;
			}
		}

		[DataMember]
		[PossibleID]
		public string approvalPersonId
		{
			set
			{
				_approvalPersonId = value;
			}

			get
			{
				return _approvalPersonId;
			}
		}

		[DataMember]
		public int approvalNumber
		{
			set
			{
				_approvalNumber = value;
			}

			get
			{
				return _approvalNumber;
			}
		}

		public ApprovalModel(DateTime From, DateTime Until, string Id, string apprCode, int apprNum)
		{
			approvalFrom = From;
			approvalUntil = Until;
			approvalPersonId = Id;
			approvalCode = apprCode;
			approvalNumber = apprNum;
		}

		public ApprovalModel(DateTime From, DateTime Until, string apprCode, string Id)
		{
			approvalFrom = From;
			approvalUntil = Until;
			approvalPersonId = Id;
			approvalCode = apprCode;
		}

		public ApprovalModel()
		{
		}

		public override string ToString()
		{
			return
				approvalCode + " " +
				approvalFrom + " " +
				approvalUntil + " " +
				approvalPersonId + " " +
				approvalNumber;
		}

		public static ApprovalModel ToObject(DataRow reader)
		{
			ApprovalModel approvalModel = new ApprovalModel();
			approvalModel.approvalCode = reader[0].ToString();
			approvalModel.approvalFrom = DateTime.Parse(reader[1].ToString());
			approvalModel.approvalUntil = DateTime.Parse(reader[2].ToString());
			approvalModel.approvalPersonId = reader[3].ToString();
			approvalModel.approvalNumber = int.Parse(reader[4].ToString());

			Debug.WriteLine("ApprovalModel:" + approvalModel.ToString());
			return approvalModel;
		}
	}
}
