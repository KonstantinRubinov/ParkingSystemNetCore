using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class TeacherModel : PersonModel
	{
		private string _teacherId;
		private string _teacherFacultyCode;
		private int _teacherStage;

		[DataMember]
		[PossibleID]
		public string teacherId
		{
			set
			{
				_teacherId = value;
			}

			get
			{
				return _teacherId;
			}
		}

		[DataMember]
		public string teacherFacultyCode
		{
			set
			{
				_teacherFacultyCode = value;
			}

			get
			{
				return _teacherFacultyCode;
			}
		}

		[DataMember]
		public int teacherStage
		{
			set
			{
				_teacherStage = value;
			}

			get
			{
				return _teacherStage;
			}
		}

		public TeacherModel(string pId, string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2, int Code, string Id, string FacultyCode) /*: base(pId, Name, Family, BeforeTelephone1, Telephone1, BeforeTelephone2, Telephone2, Code)*/
		{
			personId = pId;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
			personCode = Code;
			teacherId = Id;
			teacherFacultyCode = FacultyCode;
		}

		public TeacherModel(string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2, int Code, string Id, string FacultyCode)/* : base(Id, Name, Family, BeforeTelephone1, Telephone1, BeforeTelephone2, Telephone2, Code)*/
		{
			personId = Id;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
			personCode = Code;
			teacherId = Id;
			teacherFacultyCode = FacultyCode;
		}

		public TeacherModel(string Name, string Family, string BeforeTelephone1, string Telephone1, int Code, string Id, string FacultyCode)/* : base(Id, Name, Family, BeforeTelephone1, Telephone1, Code)*/
		{
			personId = Id;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personCode = Code;
			teacherId = Id;
			teacherFacultyCode = FacultyCode;
		}

		public TeacherModel(string Id, string FacultyCode) /*: base(Id)*/
		{
			personId = Id;
			teacherId = Id;
			teacherFacultyCode = FacultyCode;
		}

		public TeacherModel()
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

				teacherId + " " +
				teacherFacultyCode + " " +
				teacherStage;
		}

		public static TeacherModel ToObject(DataRow reader)
		{
			TeacherModel teacherModel = new TeacherModel();
			teacherModel.personId = reader[0].ToString();

			try
			{
				teacherModel.personFirstName = reader[1].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personFirstName:" + ex.Message);
			}

			try
			{
				teacherModel.personLastName = reader[2].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personLastName:" + ex.Message);
			}

			try
			{
				teacherModel.personBeforeTelephone = reader[3].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personBeforeTelephone:" + ex.Message);
			}

			try
			{
				teacherModel.personTelephone = reader[4].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personTelephone:" + ex.Message);
			}

			try
			{
				teacherModel.personBeforeCellphone = reader[5].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personBeforeCellphone:" + ex.Message);
			}

			try
			{
				teacherModel.personCellphone = reader[6].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personCellphone:" + ex.Message);
			}

			try
			{
				teacherModel.personCode = int.Parse(reader[7].ToString());
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personCode:" + ex.Message);
			}

			teacherModel.teacherId = reader[8].ToString();
			teacherModel.teacherFacultyCode = reader[9].ToString();
			teacherModel.teacherStage = int.Parse(reader[10].ToString());

			Debug.WriteLine("TeacherModel:" + teacherModel.ToString());
			return teacherModel;
		}
	}
}
