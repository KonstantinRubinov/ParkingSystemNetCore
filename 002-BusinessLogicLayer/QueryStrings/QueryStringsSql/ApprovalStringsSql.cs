using System.Data.SqlClient;

namespace ParkingSystemCoreBLL
{
	static public class ApprovalStringsSql
	{
		static private string queryApprovalsString = "SELECT * from Approvals";
		static private string queryApprovalsByCodeString = "SELECT * from Approvals where approvalCode=@approvalCode";
		static private string queryApprovalsByIdString = "SELECT * from Approvals where approvalPersonId=@approvalPersonId";
		static private string queryApprovalsByNumberString = "SELECT * from Approvals where approvalNumber=@approvalNumber";
		static private string queryApprovalsPost = "INSERT INTO Approvals (approvalCode, approvalFrom, approvalUntil, approvalPersonId, approvalNumber) VALUES (@approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber); SELECT * FROM Approvals WHERE approvalNumber = SCOPE_IDENTITY();";
		static private string queryApprovalsUpdate = "UPDATE Approvals SET approvalCode = @approvalCode, approvalFrom = @approvalFrom, approvalUntil = @approvalUntil, approvalPersonId = @approvalPersonId, approvalNumber = @approvalNumber where approvalPersonId = @approvalPersonId;" + queryApprovalsByNumberString;
		static private string queryApprovalsDelete = "DELETE FROM Approvals WHERE approvalNumber=@approvalNumber;";
		static private string queryApprovalsDeleteById = "DELETE FROM Approvals WHERE approvalPersonId=@approvalPersonId;";

		static private string procedureApprovalsString = "EXEC GetAllApprovals;";
		static private string procedureApprovalsByCodeString = "EXEC GetOneApprovalByCode @approvalCode";
		static private string procedureApprovalsByIdString = "EXEC GetOneApprovalByPersonId @approvalPersonId";
		static private string procedureApprovalsByNumberString = "EXEC GetOneApprovalByNumber a@approvalNumber;";
		static private string procedureApprovalsPost = "EXEC AddApproval @approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber;";
		static private string procedureApprovalsUpdate = "EXEC UpdateApproval @approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber;";
		static private string procedureApprovalsDelete = "EXEC DeleteApprovalByNumber @approvalNumber;";
		static private string procedureApprovalsDeleteById = "EXEC DeleteApprovalByPerson @approvalPersonId;";

		static public SqlCommand GetAllApprovals()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryApprovalsString);
			else
				return CreateSqlCommand(procedureApprovalsString);
		}

		static public SqlCommand GetOneApprovalByCode(string approvalCode)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandCode(approvalCode, queryApprovalsByCodeString);
			else
				return CreateSqlCommandCode(approvalCode, procedureApprovalsByCodeString);
		}

		static public SqlCommand GetOneApprovalByPersonId(string personId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandId(personId, queryApprovalsByIdString);
			else
				return CreateSqlCommandId(personId, procedureApprovalsByIdString);
		}

		static public SqlCommand GetOneApprovalByNumber(int approvalNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(approvalNumber, queryApprovalsByNumberString);
			else
				return CreateSqlCommandNumber(approvalNumber, procedureApprovalsByNumberString);
		}

		static public SqlCommand AddApproval(ApprovalModel approvalModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalModel, queryApprovalsPost);
			else
				return CreateSqlCommand(approvalModel, procedureApprovalsPost);
		}

		static public SqlCommand UpdateApproval(ApprovalModel approvalModel)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(approvalModel, queryApprovalsUpdate);
			else
				return CreateSqlCommand(approvalModel, procedureApprovalsUpdate);
		}

		static public SqlCommand DeleteApproval(int approvalNumber)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandNumber(approvalNumber, queryApprovalsDelete);
			else
				return CreateSqlCommandNumber(approvalNumber, procedureApprovalsDelete);
		}

		static public SqlCommand DeleteApprovalById(string approvalPersonId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandId(approvalPersonId, queryApprovalsDeleteById);
			else
				return CreateSqlCommandId(approvalPersonId, procedureApprovalsDeleteById);
		}

		static private SqlCommand CreateSqlCommand(ApprovalModel approval, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

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

		static private SqlCommand CreateSqlCommandCode(string approvalCode, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalCode);

			return command;
		}

		static private SqlCommand CreateSqlCommandId(string approvalPersonId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalPersonId", approvalPersonId);

			return command;
		}

		static private SqlCommand CreateSqlCommandNumber(int approvalNumber, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@approvalNumber", approvalNumber);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}
