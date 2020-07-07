using MySql.Data.MySqlClient;
using ParkingSystemCoreDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingSystemCoreBLL
{
	public class MySqlPersonManager : MySqlDataBase, IPersonRepository
	{
		public List<PersonModel> GetAllPersons()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(PersonStringsMySql.GetAllPersons());
			}
			
			List<PersonModel> arrPerson = new List<PersonModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrPerson.Add(PersonModel.ToObject(ms));
			}

			return arrPerson;
		}

		public List<PersonModel> GetAllPersonsId()
		{
			DataTable dt = new DataTable();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(PersonStringsMySql.GetAllPersonsId());
			}
			
			List<PersonModel> arrPerson = new List<PersonModel>();

			foreach (DataRow ms in dt.Rows)
			{
				arrPerson.Add(PersonModel.ToObjectId(ms));
			}

			return arrPerson;
		}


		public PersonModel GetOnePersonById(string personId)
		{
			DataTable dt = new DataTable();

			if (personId.Equals(string.Empty) || personId.Equals(""))
				throw new ArgumentOutOfRangeException();
			PersonModel personModel = new PersonModel();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(PersonStringsMySql.GetOnePersonById(personId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				personModel = PersonModel.ToObject(ms);
			}

			return personModel;
		}

		public int DeletePerson(string personId)
		{
			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(PersonStringsMySql.DeletePerson(personId));
			}
			
			return i;
		}

		public bool checkIfIdExists(string personId)
		{
			DataTable dt = new DataTable();


			if (personId.Equals(string.Empty) || personId.Equals(""))
				throw new ArgumentOutOfRangeException();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(PersonStringsMySql.checkIfIdExists(personId));
			}
			
			int num = 0;
			foreach (DataRow ms in dt.Rows)
			{
				num = int.Parse(ms[0].ToString());
			}

			if (num == 0) return false;
			else return true;
		}
	}
}
