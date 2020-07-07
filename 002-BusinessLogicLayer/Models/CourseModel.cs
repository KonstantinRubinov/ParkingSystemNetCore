using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class CourseModel
	{
		private string _courseCode;
		private string _courseName;

		[DataMember]
		public string courseCode
		{
			set
			{
				_courseCode = value;
			}

			get
			{
				return _courseCode;
			}
		}

		[DataMember]
		public string courseName
		{
			set
			{
				_courseName = value;
			}

			get
			{
				return _courseName;
			}
		}

		public CourseModel(string code, string name)
		{
			courseCode = code;
			courseName = name;
		}

		public CourseModel()
		{
		}

		public override string ToString()
		{
			return
				courseCode + " " +
				courseName;
		}

		public static CourseModel ToObject(DataRow reader)
		{
			CourseModel courseModel = new CourseModel();
			courseModel.courseCode = reader[0].ToString();
			courseModel.courseName = reader[1].ToString();

			Debug.WriteLine("CourseModel:" + courseModel.ToString());
			return courseModel;
		}
	}
}
