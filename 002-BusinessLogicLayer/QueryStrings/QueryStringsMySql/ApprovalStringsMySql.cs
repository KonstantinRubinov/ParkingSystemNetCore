using MySql.Data.MySqlClient;

namespace ParkingSystemCoreBLL
{
	static public class ApprovalStringsMySql
	{
		static private string queryApprovalsString = "SELECT * from Approvals";
		static private string queryApprovalsByCodeString = "SELECT * from Approvals where approvalCode=@approvalCode";
		static private string queryApprovalsByIdString = "SELECT * from Approvals where approvalPersonId=@approvalPersonId";
		static private string queryApprovalsByNumberString = "SELECT * from Approvals where approvalNumber=@approvalNumber";
		static private string queryApprovalsPost = "INSERT INTO Approvals (approvalCode, approvalFrom, approvalUntil, approvalPersonId, approvalNumber) VALUES (@approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber); SELECT * FROM Approvals WHERE approvalNumber = SCOPE_IDENTITY();";
		static private string queryApprovalsUpdate = "UPDATE Approvals SET approvalCode = @approvalCode, approvalFrom = @approvalFrom, approvalUntil = @approvalUntil, approvalPersonId = @approvalPersonId, approvalNumber = @approvalNumber where approvalPersonId = @approvalPersonId;" + queryApprovalsByNumberString;
		static private string queryApprovalsDelete = "DELETE FROM Approvals WHERE approvalNumber=@approvalNumber;";
		static private string queryApprovalsDeleteById = "DELETE FROM Approvals WHERE approvalPersonId=@approvalPersonId;";


		static private string procedureApprovalsString = "CALL `Parking`.`GetAllApprovals`();";
		static private string procedureApprovalsByCodeString = "CALL `Parking`.`GetOneApprovalByCode` (@approvalCode);";
		static private string procedureApprovalsByIdString = "CALL `Parking`.`GetOneApprovalByPersonId` (@approvalPersonId);";
		static private string procedureApprovalsByNumberString = "CALL `Parking`.`GetOneApprovalByNumber` (@approvalNumber);";
		static private string procedureApprovalsPost = "CALL `Parking`.`AddApproval` (@approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber);";
		static private string procedureApprovalsUpdate = "CALL `Parking`.`UpdateApproval` (@approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber);";
		static private string procedureApprovalsDelete = "CALL `Parking`.`DeleteApprovalByNumber` (@approvalNumber);";
		static private string procedureApprovalsDeleteById = "CALL `Parking`.`DeleteApprovalByPerson` (@approvalPersonId);";

		static public MySqlCommand GetAllApprovals()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryApprovalsString);
			else
				return CreateSqlCommand(procedureApprovalsString);
		}

		static public MySqlCommand GetOneApprovalByCode(string approvalCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(approvalCode, queryApprovalsByCodeString);
			else
				return CreateSqlCommandCode(approvalCode, procedureApprovalsByCodeString);
		}

		static public MySqlCommand GetOneApprovalByPersonId(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandId(personId, queryApprovalsByIdString);
			else
				return CreateSqlCommandId(personId, procedureApprovalsByIdString);
		}

		static public MySqlCommand GetOneApprovalByNumber(int approvalNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(approvalNumber, queryApprovalsByNumberString);
			else
				return CreateSqlCommandNumber(approvalNumber, procedureApprovalsByNumberString);
		}

		static public MySqlCommand AddApproval(ApprovalModel approvalModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalModel, queryApprovalsPost);
			else
				return CreateSqlCommand(approvalModel, procedureApprovalsPost);
		}

		static public MySqlCommand UpdateApproval(ApprovalModel approvalModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalModel, queryApprovalsUpdate);
			else
				return CreateSqlCommand(approvalModel, procedureApprovalsUpdate);
		}

		static public MySqlCommand DeleteApproval(int approvalNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(approvalNumber, queryApprovalsDelete);
			else
				return CreateSqlCommandNumber(approvalNumber, procedureApprovalsDelete);
		}

		static public MySqlCommand DeleteApprovalById(string approvalPersonId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandId(approvalPersonId, queryApprovalsDeleteById);
			else
				return CreateSqlCommandId(approvalPersonId, procedureApprovalsDeleteById);
		}

		static private MySqlCommand CreateSqlCommand(ApprovalModel approval, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approval.approvalCode);
			command.Parameters.AddWithValue("@approvalFrom", approval.approvalFrom);
			command.Parameters.AddWithValue("@approvalUntil", approval.approvalUntil);
			command.Parameters.AddWithValue("@approvalPersonId", approval.approvalPersonId);
			if (approval.approvalNumber > 0)
			{
				command.Parameters.AddWithValue("@approvalNumber", approval.approvalNumber);
			}
			return command;
		}

		static private MySqlCommand CreateSqlCommandCode(string approvalCode, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalCode);

			return command;
		}

		static private MySqlCommand CreateSqlCommandId(string approvalPersonId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalPersonId", approvalPersonId);

			return command;
		}

		static private MySqlCommand CreateSqlCommandNumber(int approvalNumber, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalNumber", approvalNumber);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}
