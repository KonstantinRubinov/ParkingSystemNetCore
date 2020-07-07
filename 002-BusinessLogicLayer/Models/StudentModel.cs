using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class StudentModel : PersonModel
	{
		private string _studentId;
		private string _studentFacultyCode;
		private int _studentYear;
		private int _studentType;


		[DataMember]
		[PossibleID]
		public string studentId
		{
			set
			{
				_studentId = value;
			}

			get
			{
				return _studentId;
			}
		}

		[DataMember]
		public string studentFacultyCode
		{
			set
			{
				_studentFacultyCode = value;
			}

			get
			{
				return _studentFacultyCode;
			}
		}

		[DataMember]
		public int studentYear
		{
			set
			{
				_studentYear = value;
			}

			get
			{
				return _studentYear;
			}
		}

		[DataMember]
		public int studentType
		{
			set
			{
				_studentType = value;
			}

			get
			{
				return _studentType;
			}
		}

		public StudentModel(string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2, int Code, string Id, int Year, int Type, string FacultyCode)/* : base(Id, Name, Family, BeforeTelephone1, Telephone1, BeforeTelephone2, Telephone2, Code)*/
		{
			personId = Id;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
			personCode = Code;
			studentId = Id;
			studentYear = Year;
			studentFacultyCode = FacultyCode;
			studentType = Type;
		}

		public StudentModel(string pId, string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2, int Code, string Id, int Year, int Type, string FacultyCode)/* : base(pId, Name, Family, BeforeTelephone1, Telephone1, BeforeTelephone2, Telephone2, Code)*/
		{
			personId = pId;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
			personCode = Code;
			studentId = Id;
			studentFacultyCode = FacultyCode;
			studentYear = Year;
			studentType = Type;
		}

		public StudentModel(string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2, int Code, string Id, int Year, int Type)/* : base(Id, Name, Family, BeforeTelephone1, Telephone1, BeforeTelephone2, Telephone2, Code)*/
		{
			personId = Id;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
			personCode = Code;
			studentId = Id;
			studentYear = Year;
			studentType = Type;
		}

		public StudentModel(string Name, string Family, string BeforeTelephone1, string Telephone1, int Code, string Id, int Year, int Type)/* : base(Id, Name, Family, BeforeTelephone1, Telephone1, Code)*/
		{
			personId = Id;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personCode = Code;
			studentId = Id;
			studentYear = Year;
			studentType = Type;
		}

		public StudentModel(string Id, int Year, int Type, string FacultyCode)/* : base(Id)*/
		{
			personId = Id;
			studentId = Id;
			studentFacultyCode = FacultyCode;
			studentYear = Year;
			studentType = Type;
		}

		public StudentModel()
		{
		}

		public override string ToString()
		{
			return
				personId + " " +
				personFirstName + " " +
				personLastName + " " +
				personBeforeTelephone + " " +
				personTelephone + " " +
				personBeforeCellphone + " " +
				personCellphone + " " +
				personCode + " " +

				studentId + " " +
				studentFacultyCode + " " +
				studentYear + " " +
				studentType;
		}





		public static StudentModel ToObject(DataRow reader)
		{
			StudentModel studentModel = new StudentModel();
			studentModel.personId = reader[0].ToString();

			try
			{
				studentModel.personFirstName = reader[1].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personFirstName:" + ex.Message);
			}

			try
			{
				studentModel.personLastName = reader[2].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personLastName:" + ex.Message);
			}

			try
			{
				studentModel.personBeforeTelephone = reader[3].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personBeforeTelephone:" + ex.Message);
			}

			try
			{
				studentModel.personTelephone = reader[4].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personTelephone:" + ex.Message);
			}

			try
			{
				studentModel.personBeforeCellphone = reader[5].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personBeforeCellphone:" + ex.Message);
			}

			try
			{
				studentModel.personCellphone = reader[6].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personCellphone:" + ex.Message);
			}

			try
			{
				studentModel.personCode = int.Parse(reader[7].ToString());
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personCode:" + ex.Message);
			}

			studentModel.studentId = reader[8].ToString();
			studentModel.studentFacultyCode = reader[9].ToString();
			studentModel.studentYear = int.Parse(reader[10].ToString());
			studentModel.studentType = int.Parse(reader[11].ToString());

			Debug.WriteLine("StudentModel:" + studentModel.ToString());
			return studentModel;
		}
	}
}
