using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class TelephoneStringsInner
	{
		static private string queryTelephonesString = "SELECT beforeTelephone from BeforeTelephones";
		static private string queryTelephonesByBefore = "SELECT beforeTelephone from BeforeTelephones where beforeTelephone=@beforeTelephone";
		static private string queryTelephonesPost = "INSERT INTO BeforeTelephones (beforeTelephone) VALUES (@beforeTelephone);" + queryTelephonesByBefore;
		static private string queryTelephonesUpdate = "UPDATE BeforeTelephones SET beforeTelephone = @beforeTelephone where beforeTelephone=@beforeTelephone;" + queryTelephonesByBefore;
		static private string queryTelephonesDelete = "DELETE FROM BeforeTelephones WHERE beforeTelephone=@beforeTelephone";

		static public OleDbCommand GetAllTelephones()
		{
			return CreateOleDbCommand(queryTelephonesString);
		}

		static public OleDbCommand GetOneBeforeTelephone(string beforeTelephone)
		{
			return CreateOleDbCommandBefore(beforeTelephone, queryTelephonesByBefore);
		}

		static public OleDbCommand AddTelephone(TelephoneModel telephoneModel)
		{
			return CreateOleDbCommand(telephoneModel, queryTelephonesPost);
		}

		static public OleDbCommand UpdateTelephone(TelephoneModel telephoneModel)
		{
			return CreateOleDbCommand(telephoneModel, queryTelephonesUpdate);
		}

		static public OleDbCommand DeleteTelephone(string beforeTelephone)
		{
			return CreateOleDbCommandBefore(beforeTelephone, queryTelephonesDelete);
		}

		static private OleDbCommand CreateOleDbCommand(TelephoneModel telephoneModel, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@beforeTelephone", telephoneModel.beforeTelephone);
			return command;
		}

		static private OleDbCommand CreateOleDbCommandBefore(string beforeTelephone, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@beforeTelephone", beforeTelephone);
			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
