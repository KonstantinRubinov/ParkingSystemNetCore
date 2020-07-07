using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class TelephoneModel
	{
		protected string _beforeTelephone;
		//protected string _telephone;

		public TelephoneModel()
		{
		}

		public TelephoneModel(string beforeTelephone1)
		{
			beforeTelephone = beforeTelephone1;
		}

		[DataMember]
		public string beforeTelephone
		{
			set
			{
				_beforeTelephone = value;
			}

			get
			{
				return _beforeTelephone;
			}
		}

		//public string telephone
		//{
		//	set
		//	{
		//		_telephone = value;
		//	}

		//	get
		//	{
		//		return _telephone;
		//	}
		//}

		public override string ToString()
		{
			return
				beforeTelephone;
		}

		public static TelephoneModel ToObject(DataRow reader)
		{
			TelephoneModel telephoneModel = new TelephoneModel();
			telephoneModel.beforeTelephone = reader[0].ToString();

			Debug.WriteLine("TelephoneModel:" + telephoneModel.ToString());
			return telephoneModel;
		}

	}
}
