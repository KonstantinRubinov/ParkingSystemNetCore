using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class CellphoneStringsInner
	{
		static private string queryCellphonesString = "SELECT beforeCellphone from BeforeCellphones";
		static private string queryCellphonesByBefore = "SELECT beforeCellphone from BeforeCellphones where beforeCellphone=@beforeCellphone";
		static private string queryCellphonesPost = "INSERT INTO BeforeCellphones (beforeCellphone) VALUES (@beforeCellphone);" + queryCellphonesByBefore;
		static private string queryCellphonesUpdate = "UPDATE BeforeCellphones SET beforeCellphone = @beforeCellphone where beforeCellphone=@beforeCellphone;" + queryCellphonesByBefore;
		static private string queryCellphonesDelete = "DELETE FROM BeforeCellphones WHERE BeforeCellphones=@BeforeCellphones";


		static public OleDbCommand GetAllCellphones()
		{
			return CreateOleDbCommand(queryCellphonesString);
		}

		static public OleDbCommand GetOneBeforeCellphone(string beforeCellphone)
		{
			return CreateOleDbCommandBefore(beforeCellphone, queryCellphonesByBefore);
		}

		static public OleDbCommand AddCellphone(CellphoneModel cellphoneModel)
		{
			return CreateOleDbCommand(cellphoneModel, queryCellphonesPost);
		}

		static public OleDbCommand UpdateCellphone(CellphoneModel cellphoneModel)
		{
			return CreateOleDbCommand(cellphoneModel, queryCellphonesUpdate);
		}

		static public OleDbCommand DeleteCellphone(string beforeCellphone)
		{
			return CreateOleDbCommandBefore(beforeCellphone, queryCellphonesDelete);
		}



		static private OleDbCommand CreateOleDbCommand(CellphoneModel cellphoneModel, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@beforeCellphone", cellphoneModel.beforeCellphone);
			return command;
		}

		static private OleDbCommand CreateOleDbCommandBefore(string beforeCellphone, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@beforeCellphone", beforeCellphone);
			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
