using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class ApprovalTypeStringsMySql
	{
		static private string queryApprovalTypesString = "SELECT approvalCode, approvalName from ApprovalTypes;";
		static private string queryApprovalTypesByCodeString = "SELECT approvalCode, approvalName from ApprovalTypes where approvalCode=@approvalCode;";
		static private string queryApprovalTypesByNameString = "SELECT approvalCode, approvalName from ApprovalTypes where approvalName=@approvalName;";
		static private string queryApprovalTypesPost = "INSERT INTO ApprovalTypes (approvalCode, approvalName) VALUES (@approvalCode, @approvalName);" + queryApprovalTypesByCodeString;
		static private string queryApprovalTypesUpdate = "UPDATE ApprovalTypes SET approvalCode = @approvalCode, approvalName = @approvalName where approvalCode=@approvalCode;" + queryApprovalTypesByCodeString;
		static private string queryApprovalTypesDelete = "DELETE FROM ApprovalTypes WHERE approvalCode=@approvalCode;";

		static private string procedureApprovalTypesString = "CALL `Parking`.`GetAllApprovalTypes`();";
		static private string procedureApprovalTypesByCodeString = "CALL `Parking`.`GetOneApprovalTypeByCode`(@approvalCode);";
		static private string procedureApprovalTypesByNameString = "CALL `Parking`.`GetOneApprovalTypeByName`(@approvalName);";
		static private string procedureApprovalTypesPost = "CALL `Parking`.`AddApprovalType`(@approvalCode, @approvalName);";
		static private string procedureApprovalTypesUpdate = "CALL `Parking`.`UpdateApprovalType`(@approvalCode, @approvalName);";
		static private string procedureApprovalTypesDelete = "CALL `Parking`.`DeleteApprovalType`(@approvalCode);";

		static public MySqlCommand GetAllApprovalTypes()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryApprovalTypesString);
			else
				return CreateSqlCommand(procedureApprovalTypesString);
		}

		static public MySqlCommand GetOneApprovalTypeByCode(string approvalCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(approvalCode, queryApprovalTypesByCodeString);
			else
				return CreateSqlCommandCode(approvalCode, procedureApprovalTypesByCodeString);
		}

		static public MySqlCommand GetOneApprovalTypeByName(string approvalName)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(approvalName, queryApprovalTypesByNameString);
			else
				return CreateSqlCommandName(approvalName, procedureApprovalTypesByNameString);
		}

		static public MySqlCommand AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalTypeModel, queryApprovalTypesPost);
			else
				return CreateSqlCommand(approvalTypeModel, procedureApprovalTypesPost);
		}

		static public MySqlCommand UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalTypeModel, queryApprovalTypesUpdate);
			else
				return CreateSqlCommand(approvalTypeModel, procedureApprovalTypesUpdate);
		}

		static public MySqlCommand DeleteApprovalType(string approvalCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(approvalCode, queryApprovalTypesDelete);
			else
				return CreateSqlCommandCode(approvalCode, procedureApprovalTypesDelete);
		}

		static private MySqlCommand CreateSqlCommand(ApprovalTypeModel approvalType, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalType.approvalCode);
			command.Parameters.AddWithValue("@approvalName", approvalType.approvalName);
			return command;
		}

		static private MySqlCommand CreateSqlCommandCode(string approvalCode, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalCode);

			return command;
		}

		static private MySqlCommand CreateSqlCommandName(string approvalName, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalName", approvalName);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
