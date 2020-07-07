using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public interface ICellphoneRepository
	{
		List<CellphoneModel> GetAllCellphones();
		CellphoneModel GetOneBeforeCellphone(string beforeCellphone1);
		CellphoneModel AddCellphone(CellphoneModel cellphoneModel);
		CellphoneModel UpdateCellphone(CellphoneModel cellphoneModel);
		int DeleteCellphone(string beforeCellphone1);
	}
}
