using System.Collections.Generic;

namespace ParkingSystemCoreBLL
{
	public class InnerThreeObjectsManager : IThreeObjectsRepository
	{
		public InnerThreeObjectsManager(string connectionString)
		{
			personRepository = new InnerPersonManager(connectionString);
			studentRepository = new InnerStudentManager(connectionString);
			teacherRepository = new InnerTeacherManager(connectionString);
			vehicleRepository = new InnerVehicleManager(connectionString);
			approvalRepository = new InnerApprovalManager(connectionString);
		}

		IPersonRepository personRepository;
		IStudentRepository studentRepository;
		ITeacherRepository teacherRepository;
		IVehicleRepository vehicleRepository;
		IApprovalRepository approvalRepository;

		public List<ThreeObjectsModel> GetAllThreeObjects()
		{
			List<ThreeObjectsModel> threeObjectsList = new List<ThreeObjectsModel>();

			List<PersonModel> allPersonsId = personRepository.GetAllPersonsId();

			for (int i = 0; i < allPersonsId.Count; i++)
			{
				ThreeObjectsModel threeObjects = new ThreeObjectsModel();

				PersonModel personModel;

				if (studentRepository.GetOneStudentById(allPersonsId[i].personId) != null)
				{
					personModel = studentRepository.GetOneStudentById(allPersonsId[i].personId);
				}
				else
				{
					personModel = teacherRepository.GetOneTeacherById(allPersonsId[i].personId);
				}

				VehicleModel vehicleModel = vehicleRepository.GetOneVehicleByOwnerId(allPersonsId[i].personId);
				ApprovalModel approvalModel = approvalRepository.GetOneApprovalByPersonId(allPersonsId[i].personId);

				threeObjects.personModel = personModel;
				threeObjects.vehicleModel = vehicleModel;
				threeObjects.approvalModel = approvalModel;

				threeObjectsList.Add(threeObjects);
			}

			return threeObjectsList;
		}

		public ThreeObjectsModel GetAllThreeObjectsByPersonId(string personId)
		{
			ThreeObjectsModel threeObjects = new ThreeObjectsModel();

			PersonModel personModel;

			if (studentRepository.GetOneStudentById(personId) != null)
			{
				personModel = studentRepository.GetOneStudentById(personId);
			}
			else
			{
				personModel = teacherRepository.GetOneTeacherById(personId);
			}
			VehicleModel vehicleModel = vehicleRepository.GetOneVehicleByOwnerId(personId);
			ApprovalModel approvalModel = approvalRepository.GetOneApprovalByPersonId(personId);

			threeObjects.personModel = personModel;
			threeObjects.vehicleModel = vehicleModel;
			threeObjects.approvalModel = approvalModel;

			return threeObjects;
		}

		public ThreeObjectsModel GetAllThreeObjectsByVehicleNumber(string vehicleNumber)
		{
			ThreeObjectsModel threeObjects = new ThreeObjectsModel();


			VehicleModel vehicleModel = vehicleRepository.GetOneVehicleByNumber(vehicleNumber);
			PersonModel personModel;

			if (studentRepository.GetOneStudentById(vehicleModel.vehicleOwnerId) != null)
			{
				personModel = studentRepository.GetOneStudentById(vehicleModel.vehicleOwnerId);
			}
			else
			{
				personModel = teacherRepository.GetOneTeacherById(vehicleModel.vehicleOwnerId);
			}

			ApprovalModel approvalModel = approvalRepository.GetOneApprovalByPersonId(vehicleModel.vehicleOwnerId);

			threeObjects.personModel = personModel;
			threeObjects.vehicleModel = vehicleModel;
			threeObjects.approvalModel = approvalModel;

			return threeObjects;
		}

		public ThreeObjectsModel AddThreeObjects(ThreeObjectsModel threeObjectsModel)
		{
			if (threeObjectsModel.personModel is StudentModel)
			{
				studentRepository.AddStudent(threeObjectsModel.personModel as StudentModel);
			}

			if (threeObjectsModel.personModel is TeacherModel)
			{
				teacherRepository.AddTeacher(threeObjectsModel.personModel as TeacherModel);
			}

			vehicleRepository.AddVehicle(threeObjectsModel.vehicleModel);
			approvalRepository.AddApproval(threeObjectsModel.approvalModel);


			return GetAllThreeObjectsByPersonId(threeObjectsModel.personModel.personId);
		}

		public ThreeObjectsModel UpdateThreeObjects(ThreeObjectsModel threeObjectsModel)
		{
			if (threeObjectsModel.personModel is StudentModel)
			{
				studentRepository.UpdateStudent(threeObjectsModel.personModel as StudentModel);
			}

			if (threeObjectsModel.personModel is TeacherModel)
			{
				teacherRepository.UpdateTeacher(threeObjectsModel.personModel as TeacherModel);
			}

			vehicleRepository.UpdateVehicle(threeObjectsModel.vehicleModel);
			approvalRepository.UpdateApproval(threeObjectsModel.approvalModel);


			return GetAllThreeObjectsByPersonId(threeObjectsModel.personModel.personId);
		}

		public int DeleteThreeObjects(string personId)
		{
			int check = 0;
			check += studentRepository.DeleteStudent(personId);
			check += teacherRepository.DeleteTeacher(personId);
			check += vehicleRepository.DeleteVehicleByOwnerId(personId);
			return check;
		}
	}
}
