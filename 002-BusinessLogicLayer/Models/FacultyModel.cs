using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class FacultyModel
	{
		private string _facultyCode;
		private string _facultyName;
		private string _facultyHead;

		[DataMember]
		public string facultyCode
		{
			set
			{
				_facultyCode = value;
			}

			get
			{
				return _facultyCode;
			}
		}

		[DataMember]
		public string facultyName
		{
			set
			{
				_facultyName = value;
			}

			get
			{
				return _facultyName;
			}
		}

		[DataMember]
		public string facultyHead
		{
			set
			{
				_facultyHead = value;
			}

			get
			{
				return _facultyHead;
			}
		}

		public FacultyModel(string name, string code, string head)
		{
			facultyName = name;
			facultyCode = code;
			facultyHead = head;
		}

		public FacultyModel()
		{
		}

		public override string ToString()
		{
			return
				facultyCode + " " +
				facultyName + " " +
				facultyHead;
		}

		public static FacultyModel ToObject(DataRow reader)
		{
			FacultyModel facultyModel = new FacultyModel();
			facultyModel.facultyCode = reader[0].ToString();
			facultyModel.facultyName = reader[1].ToString();
			facultyModel.facultyHead = reader[2].ToString();

			Debug.WriteLine("FacultyModel:" + facultyModel.ToString());
			return facultyModel;
		}
	}
}
