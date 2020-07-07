using lcpi.data.oledb;

namespace ParkingSystemCoreBLL
{
	static public class ApprovalTypeStringsInner
	{
		static private string queryApprovalTypesString = "SELECT approvalCode, approvalName from ApprovalTypes";
		static private string queryApprovalTypesByCodeString = "SELECT approvalCode, approvalName from ApprovalTypes where approvalCode=@approvalCode";
		static private string queryApprovalTypesByNameString = "SELECT approvalCode, approvalName from ApprovalTypes where approvalName=@approvalName";
		static private string queryApprovalTypesPost = "INSERT INTO ApprovalTypes (approvalCode, approvalName) VALUES (@approvalCode, @approvalName);" + queryApprovalTypesByCodeString;
		static private string queryApprovalTypesUpdate = "UPDATE ApprovalTypes SET approvalCode = @approvalCode, approvalName = @approvalName where approvalCode=@approvalCode;" + queryApprovalTypesByCodeString;
		static private string queryApprovalTypesDelete = "DELETE FROM ApprovalTypes WHERE approvalCode=@approvalCode";


		static public OleDbCommand GetAllApprovalTypes()
		{
			return CreateOleDbCommand(queryApprovalTypesString);
		}

		static public OleDbCommand GetOneApprovalTypeByCode(string approvalCode)
		{
			return CreateOleDbCommandCode(approvalCode, queryApprovalTypesByCodeString);
		}

		static public OleDbCommand GetOneApprovalTypeByName(string approvalName)
		{
			return CreateOleDbCommandName(approvalName, queryApprovalTypesByNameString);
		}

		static public OleDbCommand AddApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			return CreateOleDbCommand(approvalTypeModel, queryApprovalTypesPost);
		}

		static public OleDbCommand UpdateApprovalType(ApprovalTypeModel approvalTypeModel)
		{
			return CreateOleDbCommand(approvalTypeModel, queryApprovalTypesUpdate);
		}

		static public OleDbCommand DeleteApprovalType(string approvalCode)
		{
			return CreateOleDbCommandCode(approvalCode, queryApprovalTypesDelete);
		}



		static private OleDbCommand CreateOleDbCommand(ApprovalTypeModel approvalType, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalType.approvalCode);
			command.Parameters.AddWithValue("@approvalName", approvalType.approvalName);
			return command;
		}



		static private OleDbCommand CreateOleDbCommandCode(string approvalCode, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@approvalCode", approvalCode);

			return command;
		}

		static private OleDbCommand CreateOleDbCommandName(string approvalName, string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			command.Parameters.AddWithValue("@approvalName", approvalName);

			return command;
		}

		static private OleDbCommand CreateOleDbCommand(string commandText)
		{
			OleDbCommand command = new OleDbCommand(commandText);

			return command;
		}
	}
}
