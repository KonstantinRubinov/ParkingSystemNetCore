using MongoDB.Driver;
using ParkingSystemCoreDAL;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystemCoreBLL
{
	public class MongoVehicleManager : IVehicleRepository
	{
		private readonly IMongoCollection<PersonModel> _persons;
		private readonly IMongoCollection<VehicleModel> _vehicles;

		public MongoVehicleManager(ParkingDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(settings.PersonCollectionName);
			_vehicles = database.GetCollection<VehicleModel>(settings.VehicleCollectionName);
		}

		public MongoVehicleManager()
		{
			var client = new MongoClient(ConnectionStrings.ConnectionString);
			var database = client.GetDatabase(ConnectionStrings.DatabaseName);

			_persons = database.GetCollection<PersonModel>(ConnectionStrings.PersonCollectionName);
			_vehicles = database.GetCollection<VehicleModel>(ConnectionStrings.VehicleCollectionName);
		}

		public List<string> GetAllVehicleNumbers()
		{
			var resultQuary = _vehicles.Find(vehicles => true).Project(v => new VehicleModel
			{
				vehicleNumber = v.vehicleNumber
			}).ToList();

			List<string> vehicleNumbers = new List<string>();

			foreach (var vehicle in resultQuary)
			{
				vehicleNumbers.Add(vehicle.vehicleNumber);
			}

			return vehicleNumbers;
		}

		public List<VehicleModel> GetAllVehicles()
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join vehicles in _vehicles.AsQueryable() on persons.personId equals vehicles.vehicleOwnerId

			select new VehicleModel
			{
				vehicleNumber = vehicles.vehicleNumber,
				vehicleManufacturer = vehicles.vehicleManufacturer,
				vehicleColor = vehicles.vehicleColor,
				vehicleOwnerId = vehicles.vehicleOwnerId,
				vehicleOwnerName = persons.personFirstName + " " + persons.personLastName
			};

			return resultQuary.ToList();
		}


		public VehicleModel GetOneVehicleByNumber(string vehicleNumber)
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join vehicles in _vehicles.AsQueryable() on persons.personId equals vehicles.vehicleOwnerId
			where (vehicles.vehicleNumber.Equals(vehicleNumber))
			select new VehicleModel
			{
				vehicleNumber = vehicles.vehicleNumber,
				vehicleManufacturer = vehicles.vehicleManufacturer,
				vehicleColor = vehicles.vehicleColor,
				vehicleOwnerId = vehicles.vehicleOwnerId,
				vehicleOwnerName = persons.personFirstName + " " + persons.personLastName
			};

			return resultQuary.SingleOrDefault();
		}


		public VehicleModel GetOneVehicleByOwnerId(string personId)
		{
			var resultQuary =
			from persons in _persons.AsQueryable()
			join vehicles in _vehicles.AsQueryable() on persons.personId equals vehicles.vehicleOwnerId
			where (vehicles.vehicleOwnerId.Equals(personId))
			select new VehicleModel
			{
				vehicleNumber = vehicles.vehicleNumber,
				vehicleManufacturer = vehicles.vehicleManufacturer,
				vehicleColor = vehicles.vehicleColor,
				vehicleOwnerId = vehicles.vehicleOwnerId,
				vehicleOwnerName = persons.personFirstName + " " + persons.personLastName
			};

			return resultQuary.SingleOrDefault();
		}


		public VehicleModel AddVehicle(VehicleModel vehicleModel)
		{
			if (_vehicles.Find<VehicleModel>(Builders<VehicleModel>.Filter.Eq(vehicle => vehicle.vehicleNumber, vehicleModel.vehicleNumber)).FirstOrDefault() == null)
			{
				_vehicles.InsertOne(vehicleModel);
			}

			VehicleModel tmpVehicleModel = GetOneVehicleByNumber(vehicleModel.vehicleNumber);
			return tmpVehicleModel;
		}


		public VehicleModel UpdateVehicle(VehicleModel vehicleModel)
		{
			_vehicles.ReplaceOne(vehicle => vehicle.vehicleNumber.Equals(vehicleModel.vehicleNumber), vehicleModel);
			VehicleModel tmpVehicleModel = GetOneVehicleByNumber(vehicleModel.vehicleNumber);
			return tmpVehicleModel;
		}


		public int DeleteVehicleByNumber(string vehicleNumber)
		{
			_vehicles.DeleteOne(vehicle => vehicle.vehicleNumber.Equals(vehicleNumber));
			return 1;
		}


		public int DeleteVehicleByOwnerId(string ownerId)
		{
			_vehicles.DeleteOne(vehicle => vehicle.vehicleOwnerId.Equals(ownerId));
			return 1;
		}
	}
}
