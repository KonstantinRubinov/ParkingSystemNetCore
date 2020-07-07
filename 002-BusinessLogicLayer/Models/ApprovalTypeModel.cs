using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class ApprovalTypeModel
	{
		private string _approvalCode;
		private string _approvalName;

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
		public string approvalName
		{
			set
			{
				_approvalName = value;
			}

			get
			{
				return _approvalName;
			}
		}


		public ApprovalTypeModel(string name, string code)
		{
			approvalName = name;
			approvalCode = code;
		}

		public ApprovalTypeModel()
		{
		}

		public override string ToString()
		{
			return
				approvalCode + " " +
				approvalName;
		}

		public static ApprovalTypeModel ToObject(DataRow reader)
		{
			ApprovalTypeModel approvalTypeModel = new ApprovalTypeModel();
			approvalTypeModel.approvalCode = reader[0].ToString();
			approvalTypeModel.approvalName = reader[1].ToString();

			Debug.WriteLine("ApprovalTypeModel:" + approvalTypeModel.ToString());
			return approvalTypeModel;
		}
	}
}
