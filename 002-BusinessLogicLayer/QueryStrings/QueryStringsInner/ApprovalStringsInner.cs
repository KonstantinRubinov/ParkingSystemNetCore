using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class ApprovalStringsInner
	{
		static private string queryApprovalsString = "SELECT * from Approvals";
		static private string queryApprovalsByCodeString = "SELECT * from Approvals where approvalCode=@approvalCode";
		static private string queryApprovalsByIdString = "SELECT * from Approvals where approvalPersonId=@approvalPersonId";
		static private string queryApprovalsByNumberString = "SELECT * from Approvals where approvalNumber=@approvalNumber";
		static private string queryApprovalsPost = "INSERT INTO Approvals (approvalCode, approvalFrom, approvalUntil, approvalPersonId, approvalNumber) VALUES (@approvalCode, @approvalFrom, @approvalUntil, @approvalPersonId, @approvalNumber); SELECT * FROM Approvals WHERE approvalNumber = SCOPE_IDENTITY();";
		static private string queryApprovalsUpdate = "UPDATE Approvals SET approvalCode = @approvalCode, approvalFrom = @approvalFrom, approvalUntil = @approvalUntil, approvalPersonId = @approvalPersonId, approvalNumber = @approvalNumber where approvalPersonId = @approvalPersonId;" + queryApprovalsByNumberString;
		static private string queryApprovalsDelete = "DELETE FROM Approvals WHERE approvalNumber=@approvalNumber";
		static private string queryApprovalsDeleteById = "DELETE FROM Approvals WHERE approvalPersonId=@approvalPersonId";


		static public OleDbCommand GetAllApprovals()
		{
			return CreateOleDbCommand(queryApprovalsString);
		}

		static public OleDbCommand GetOneApprovalByCode(string approvalCode)
		{
			return CreateOleDbCommandCode(approvalCode, queryApprovalsByCodeString);
		}

		static public OleDbCommand GetOneApprovalByPersonId(string personId)
		{
			return CreateOleDbCommandId(personId, queryApprovalsByIdString);
		}

		static public OleDbCommand GetOneApprovalByNumber(int approvalNumber)
		{
			return CreateOleDbCommandNumber(approvalNumber, queryApprovalsByNumberString);
		}

		static public OleDbCommand AddApproval(ApprovalModel approvalModel)
		{
			return CreateOleDbCommand(approvalModel, queryApprovalsPost);
		}

		static public OleDbCommand UpdateApproval(ApprovalModel approvalModel)
		{
			return CreateOleDbCommand(approvalModel, queryApprovalsUpdate);
		}

		static public OleDbCommand DeleteApproval(int approvalNumber)
		{
			return CreateOleDbCommandNumber(approvalNumber, queryApprovalsDelete);
		}

		static public OleDbCommand DeleteApprovalById(string approvalPersonId)
		{
			return CreateOleDbCommandId(approvalPersonId, queryApprovalsDeleteById);
		}



		static private OleDbCommand CreateOleDbCommand(ApprovalModel approval, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

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



		static private OleDbCommand CreateOleDbCommandCode(string approvalCode, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalCode);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandId(string approvalPersonId, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@approvalPersonId", approvalPersonId);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandNumber(int approvalNumber, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@approvalNumber", approvalNumber);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
