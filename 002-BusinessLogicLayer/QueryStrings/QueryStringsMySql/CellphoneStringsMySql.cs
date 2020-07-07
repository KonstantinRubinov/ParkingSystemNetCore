using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class CellphoneStringsMySql
	{
		static private string queryCellphonesString = "SELECT beforeCellphone from BeforeCellphones;";
		static private string queryCellphonesByBefore = "SELECT beforeCellphone from BeforeCellphones where beforeCellphone=@beforeCellphone;";
		static private string queryCellphonesPost = "INSERT INTO BeforeCellphones (beforeCellphone) VALUES (@beforeCellphone);" + queryCellphonesByBefore;
		static private string queryCellphonesUpdate = "UPDATE BeforeCellphones SET beforeCellphone = @beforeCellphone where beforeCellphone=@beforeCellphone;" + queryCellphonesByBefore;
		static private string queryCellphonesDelete = "DELETE FROM BeforeCellphones WHERE beforeCellphone=@beforeCellphone;";

		static private string procedureCellphonesString = "CALL `Parking`.`GetAllCellphones`();";
		static private string procedureCellphonesByBefore = "CALL `Parking`.`GetOneBeforeCellphone`(@beforeCellphone);";
		static private string procedureCellphonesPost = "CALL `Parking`.`AddCellphone`(@beforeCellphone);";
		static private string procedureCellphonesUpdate = "CALL `Parking`.`UpdateCellphone`(@beforeCellphone);";
		static private string procedureCellphonesDelete = "CALL `Parking`.`DeleteCellphone`(@beforeCellphone);";

		static public MySqlCommand GetAllCellphones()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryCellphonesString);
			else
				return CreateSqlCommand(procedureCellphonesString);
		}

		static public MySqlCommand GetOneBeforeCellphone(string beforeCellphone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeCellphone, queryCellphonesByBefore);
			else
				return CreateSqlCommandBefore(beforeCellphone, procedureCellphonesByBefore);
		}

		static public MySqlCommand AddCellphone(CellphoneModel cellphoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(cellphoneModel, queryCellphonesPost);
			else
				return CreateSqlCommand(cellphoneModel, procedureCellphonesPost);
		}

		static public MySqlCommand UpdateCellphone(CellphoneModel cellphoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(cellphoneModel, queryCellphonesUpdate);
			else
				return CreateSqlCommand(cellphoneModel, procedureCellphonesUpdate);
		}

		static public MySqlCommand DeleteCellphone(string beforeCellphone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeCellphone, queryCellphonesDelete);
			else
				return CreateSqlCommandBefore(beforeCellphone, procedureCellphonesDelete);
		}

		static private MySqlCommand CreateSqlCommand(CellphoneModel cellphoneModel, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeCellphone", cellphoneModel.beforeCellphone);
			return command;
		}

		static private MySqlCommand CreateSqlCommandBefore(string beforeCellphone, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeCellphone", beforeCellphone);
			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
