using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class CellphoneModel
	{
		public CellphoneModel()
		{
		}

		public CellphoneModel(string beforeCellphone1)
		{
			_beforeCellphone = beforeCellphone1;
		}


		protected string _beforeCellphone;
		//protected string _cellphone;

		[DataMember]
		public string beforeCellphone
		{
			set
			{
				_beforeCellphone = value;
			}

			get
			{
				return _beforeCellphone;
			}
		}

		//public string cellphone
		//{
		//	set
		//	{
		//		_cellphone = value;
		//	}

		//	get
		//	{
		//		return _cellphone;
		//	}
		//}

		public override string ToString()
		{
			return
				beforeCellphone;
		}

		public static CellphoneModel ToObject(DataRow reader)
		{
			CellphoneModel cellphoneModel = new CellphoneModel();
			cellphoneModel.beforeCellphone = reader[0].ToString();

			Debug.WriteLine("CellphoneModel:" + cellphoneModel.ToString());
			return cellphoneModel;
		}
	}
}
