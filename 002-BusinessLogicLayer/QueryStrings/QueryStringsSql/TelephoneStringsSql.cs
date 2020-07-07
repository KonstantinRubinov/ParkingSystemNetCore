using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class TelephoneStringsSql
	{
		static private string queryTelephonesString = "SELECT beforeTelephone from BeforeTelephones;";
		static private string queryTelephonesByBefore = "SELECT beforeTelephone from BeforeTelephones where beforeTelephone=@beforeTelephone;";
		static private string queryTelephonesPost = "INSERT INTO BeforeTelephones (beforeTelephone) VALUES (@beforeTelephone);" + queryTelephonesByBefore;
		static private string queryTelephonesUpdate = "UPDATE BeforeTelephones SET beforeTelephone = @beforeTelephone where beforeTelephone=@beforeTelephone;" + queryTelephonesByBefore;
		static private string queryTelephonesDelete = "DELETE FROM BeforeTelephones WHERE beforeTelephone=@beforeTelephone;";

		static private string procedureTelephonesString = "EXEC GetAllTelephones;";
		static private string procedureTelephonesByBefore = "EXEC GetOneBeforeTelephone @beforeTelephone;";
		static private string procedureTelephonesPost = "EXEC AddTelephone @beforeTelephone;";
		static private string procedureTelephonesUpdate = "EXEC UpdateTelephone @beforeTelephone;";
		static private string procedureTelephonesDelete = "EXEC DeleteTelephone @beforeTelephone;";

		static public SqlCommand GetAllTelephones()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryTelephonesString);
			else
				return CreateSqlCommand(procedureTelephonesString);
		}

		static public SqlCommand GetOneBeforeTelephone(string beforeTelephone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeTelephone, queryTelephonesByBefore);
			else
				return CreateSqlCommandBefore(beforeTelephone, procedureTelephonesByBefore);
		}

		static public SqlCommand AddTelephone(TelephoneModel telephoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(telephoneModel, queryTelephonesPost);
			else
				return CreateSqlCommand(telephoneModel, procedureTelephonesPost);
		}

		static public SqlCommand UpdateTelephone(TelephoneModel telephoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(telephoneModel, queryTelephonesUpdate);
			else
				return CreateSqlCommand(telephoneModel, procedureTelephonesUpdate);
		}

		static public SqlCommand DeleteTelephone(string beforeTelephone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeTelephone, queryTelephonesDelete);
			else
				return CreateSqlCommandBefore(beforeTelephone, procedureTelephonesDelete);
		}

		static private SqlCommand CreateSqlCommand(TelephoneModel telephoneModel, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeTelephone", telephoneModel.beforeTelephone);
			return command;
		}

		static private SqlCommand CreateSqlCommandBefore(string beforeTelephone, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeTelephone", beforeTelephone);
			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
