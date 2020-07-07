using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class ApprovalTypeStringsSql
	{
		static private string queryApprovalTypesString = "SELECT approvalCode, approvalName from ApprovalTypes;";
		static private string queryApprovalTypesByCodeString = "SELECT approvalCode, approvalName from ApprovalTypes where approvalCode=@approvalCode;";
		static private string queryApprovalTypesByNameString = "SELECT approvalCode, approvalName from ApprovalTypes where approvalName=@approvalName;";
		static private string queryApprovalTypesPost = "INSERT INTO ApprovalTypes (approvalCode, approvalName) VALUES (@approvalCode, @approvalName);" + queryApprovalTypesByCodeString;
		static private string queryApprovalTypesUpdate = "UPDATE ApprovalTypes SET approvalCode = @approvalCode, approvalName = @approvalName where approvalCode=@approvalCode;" + queryApprovalTypesByCodeString;
		static private string queryApprovalTypesDelete = "DELETE FROM ApprovalTypes WHERE approvalCode=@approvalCode;";

		static private string procedureApprovalTypesString = "EXEC GetAllApprovalTypes;";
		static private string procedureApprovalTypesByCodeString = "EXEC GetOneApprovalTypeByCode @approvalCode;";
		static private string procedureApprovalTypesByNameString = "EXEC GetOneApprovalTypeByName @approvalName;";
		static private string procedureApprovalTypesPost = "EXEC AddApprovalType @approvalCode, @approvalName;";
		static private string procedureApprovalTypesUpdate = "EXEC UpdateApprovalType @approvalCode, @approvalName;";
		static private string procedureApprovalTypesDelete = "EXEC DeleteApprovalType @approvalCode;";

		static public SqlCommand GetAllApprovalTypes()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryApprovalTypesString);
			else
				return CreateSqlCommand(procedureApprovalTypesString);
		}

		static public SqlCommand GetOneApprovalTypeByCode(string approvalCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(approvalCode, queryApprovalTypesByCodeString);
			else
				return CreateSqlCommandCode(approvalCode, procedureApprovalTypesByCodeString);
		}

		static public SqlCommand GetOneApprovalTypeByName(string approvalName)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandName(approvalName, queryApprovalTypesByNameString);
			else
				return CreateSqlCommandName(approvalName, procedureApprovalTypesByNameString);
		}

		static public SqlCommand AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalTypeModel, queryApprovalTypesPost);
			else
				return CreateSqlCommand(approvalTypeModel, procedureApprovalTypesPost);
		}

		static public SqlCommand UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalTypeModel, queryApprovalTypesUpdate);
			else
				return CreateSqlCommand(approvalTypeModel, procedureApprovalTypesUpdate);
		}

		static public SqlCommand DeleteApprovalType(string approvalCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(approvalCode, queryApprovalTypesDelete);
			else
				return CreateSqlCommandCode(approvalCode, procedureApprovalTypesDelete);
		}

		static private SqlCommand CreateSqlCommand(ApprovalTypeModel approvalType, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalType.approvalCode);
			command.Parameters.AddWithValue("@approvalName", approvalType.approvalName);
			return command;
		}

		static private SqlCommand CreateSqlCommandCode(string approvalCode, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalCode);

			return command;
		}

		static private SqlCommand CreateSqlCommandName(string approvalName, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalName", approvalName);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
