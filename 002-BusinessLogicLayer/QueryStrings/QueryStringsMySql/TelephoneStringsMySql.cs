using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class TelephoneStringsMySql
	{
		static private string queryTelephonesString = "SELECT beforeTelephone from BeforeTelephones;";
		static private string queryTelephonesByBefore = "SELECT beforeTelephone from BeforeTelephones where beforeTelephone=@beforeTelephone;";
		static private string queryTelephonesPost = "INSERT INTO BeforeTelephones (beforeTelephone) VALUES (@beforeTelephone);" + queryTelephonesByBefore;
		static private string queryTelephonesUpdate = "UPDATE BeforeTelephones SET beforeTelephone = @beforeTelephone where beforeTelephone=@beforeTelephone;" + queryTelephonesByBefore;
		static private string queryTelephonesDelete = "DELETE FROM BeforeTelephones WHERE beforeTelephone=@beforeTelephone;";

		static private string procedureTelephonesString = "CALL `Parking`.`GetAllTelephones`();";
		static private string procedureTelephonesByBefore = "CALL `Parking`.`GetOneBeforeTelephone`(@beforeTelephone);";
		static private string procedureTelephonesPost = "CALL `Parking`.`AddTelephone`(@beforeTelephone);";
		static private string procedureTelephonesUpdate = "CALL `Parking`.`UpdateTelephone`(@beforeTelephone);";
		static private string procedureTelephonesDelete = "CALL `Parking`.`DeleteTelephone`(@beforeTelephone);";

		static public MySqlCommand GetAllTelephones()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryTelephonesString);
			else
				return CreateSqlCommand(procedureTelephonesString);
		}

		static public MySqlCommand GetOneBeforeTelephone(string beforeTelephone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeTelephone, queryTelephonesByBefore);
			else
				return CreateSqlCommandBefore(beforeTelephone, procedureTelephonesByBefore);
		}

		static public MySqlCommand AddTelephone(TelephoneModel telephoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(telephoneModel, queryTelephonesPost);
			else
				return CreateSqlCommand(telephoneModel, procedureTelephonesPost);
		}

		static public MySqlCommand UpdateTelephone(TelephoneModel telephoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(telephoneModel, queryTelephonesUpdate);
			else
				return CreateSqlCommand(telephoneModel, procedureTelephonesUpdate);
		}

		static public MySqlCommand DeleteTelephone(string beforeTelephone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeTelephone, queryTelephonesDelete);
			else
				return CreateSqlCommandBefore(beforeTelephone, procedureTelephonesDelete);
		}

		static private MySqlCommand CreateSqlCommand(TelephoneModel telephoneModel, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeTelephone", telephoneModel.beforeTelephone);
			return command;
		}

		static private MySqlCommand CreateSqlCommandBefore(string beforeTelephone, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeTelephone", beforeTelephone);
			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
