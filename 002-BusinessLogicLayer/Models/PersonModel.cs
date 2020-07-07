using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ParkingSystemCoreBLL
{
	[DataContract]
	public class PersonModel
	{
		protected string _personId;
		protected string _personName;
		protected string _personFamily;
		protected string _personBeforeTelephone;
		protected string _personTelephone;
		protected string _personBeforeCellphone;
		protected string _personCellphone;
		protected int _personCode;

		[DataMember]
		[PossibleID]
		public string personId
		{
			set
			{
				_personId = value;
			}

			get
			{
				return _personId;
			}
		}


		[DataMember]
		public string personFirstName
		{
			set
			{
				_personName = value;
			}

			get
			{
				return _personName;
			}
		}


		[DataMember]
		public string personLastName
		{
			set
			{
				_personFamily = value;
			}

			get
			{
				return _personFamily;
			}
		}

		[DataMember]
		public string personBeforeTelephone
		{
			set
			{
				_personBeforeTelephone = value;
			}

			get
			{
				return _personBeforeTelephone;
			}
		}

		[DataMember]
		public string personTelephone
		{
			set
			{
				_personTelephone = value;
			}

			get
			{
				return _personTelephone;
			}
		}


		[DataMember]
		public string personBeforeCellphone
		{
			set
			{
				_personBeforeCellphone = value;
			}

			get
			{
				return _personBeforeCellphone;
			}
		}

		[DataMember]
		public string personCellphone
		{
			set
			{
				_personCellphone = value;
			}

			get
			{
				return _personCellphone;
			}
		}

		[DataMember]
		public int personCode
		{
			set
			{
				_personCode = value;
			}

			get
			{
				return _personCode;
			}
		}





		public PersonModel(string pId, string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2, int Code)
		{
			personId = pId;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
			personCode = Code;
		}

		public PersonModel(string pId, string Name, string Family, string BeforeTelephone1, string Telephone1, string BeforeTelephone2, string Telephone2)
		{
			personId = pId;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personBeforeCellphone = BeforeTelephone2;
			personCellphone = Telephone2;
		}

		public PersonModel(string pId, string Name, string Family, string BeforeTelephone1, string Telephone1, int Code)
		{
			personId = pId;
			personFirstName = Name;
			personLastName = Family;
			personBeforeTelephone = BeforeTelephone1;
			personTelephone = Telephone1;
			personCode = Code;
		}

		public PersonModel(string pId)
		{
			personId = pId;
		}

		public PersonModel()
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
				personCode;
		}

		public static PersonModel ToObject(DataRow reader)
		{
			PersonModel personModel = new PersonModel();
			personModel.personId = reader[0].ToString();


			try
			{
				personModel.personFirstName = reader[1].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personFirstName:" + ex.Message);
			}

			try
			{
				personModel.personLastName = reader[2].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personLastName:" + ex.Message);
			}

			try
			{
				personModel.personBeforeTelephone = reader[3].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personBeforeTelephone:" + ex.Message);
			}

			try
			{
				personModel.personTelephone = reader[4].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personTelephone:" + ex.Message);
			}

			try
			{
				personModel.personBeforeCellphone = reader[5].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personBeforeCellphone:" + ex.Message);
			}

			try
			{
				personModel.personCellphone = reader[6].ToString();
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personCellphone:" + ex.Message);
			}

			try
			{
				personModel.personCode = int.Parse(reader[7].ToString());
			}
			catch (IndexOutOfRangeException ex)
			{
				Debug.WriteLine("personCode:" + ex.Message);
			}



			Debug.WriteLine("PersonModel:" + personModel.ToString());
			return personModel;
		}


		public static PersonModel ToObjectId(DataRow reader)
		{
			PersonModel personModel = new PersonModel();
			personModel.personId = reader[0].ToString();

			Debug.WriteLine("PersonModel:" + personModel.ToString());
			return personModel;
		}
	}
}
