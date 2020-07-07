using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class CellphoneStringsSql
	{
		static private string queryCellphonesString = "SELECT beforeCellphone from BeforeCellphones;";
		static private string queryCellphonesByBefore = "SELECT beforeCellphone from BeforeCellphones where beforeCellphone=@beforeCellphone;";
		static private string queryCellphonesPost = "INSERT INTO BeforeCellphones (beforeCellphone) VALUES (@beforeCellphone);" + queryCellphonesByBefore;
		static private string queryCellphonesUpdate = "UPDATE BeforeCellphones SET beforeCellphone = @beforeCellphone where beforeCellphone=@beforeCellphone;" + queryCellphonesByBefore;
		static private string queryCellphonesDelete = "DELETE FROM BeforeCellphones WHERE beforeCellphone=@beforeCellphone;";

		static private string procedureCellphonesString = "EXEC GetAllCellphones;";
		static private string procedureCellphonesByBefore = "EXEC GetOneBeforeCellphone @beforeCellphone;";
		static private string procedureCellphonesPost = "EXEC AddCellphone @beforeCellphone;";
		static private string procedureCellphonesUpdate = "EXEC UpdateCellphone @beforeCellphone;";
		static private string procedureCellphonesDelete = "EXEC DeleteCellphone @beforeCellphone;";

		static public SqlCommand GetAllCellphones()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryCellphonesString);
			else
				return CreateSqlCommand(procedureCellphonesString);
		}

		static public SqlCommand GetOneBeforeCellphone(string beforeCellphone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeCellphone, queryCellphonesByBefore);
			else
				return CreateSqlCommandBefore(beforeCellphone, procedureCellphonesByBefore);
		}

		static public SqlCommand AddCellphone(CellphoneModel cellphoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(cellphoneModel, queryCellphonesPost);
			else
				return CreateSqlCommand(cellphoneModel, procedureCellphonesPost);
		}

		static public SqlCommand UpdateCellphone(CellphoneModel cellphoneModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(cellphoneModel, queryCellphonesUpdate);
			else
				return CreateSqlCommand(cellphoneModel, procedureCellphonesUpdate);
		}

		static public SqlCommand DeleteCellphone(string beforeCellphone)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandBefore(beforeCellphone, queryCellphonesDelete);
			else
				return CreateSqlCommandBefore(beforeCellphone, procedureCellphonesDelete);
		}

		static private SqlCommand CreateSqlCommand(CellphoneModel cellphoneModel, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeCellphone", cellphoneModel.beforeCellphone);
			return command;
		}

		static private SqlCommand CreateSqlCommandBefore(string beforeCellphone, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@beforeCellphone", beforeCellphone);
			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
