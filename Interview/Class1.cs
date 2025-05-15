using Contracts;
using Contracts.Entities;
using Contracts.Models;
using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    //Ta klasa ma być serwisem używanym w środowisku webowym. Będzie używana jako singleton przez dependency injection.
    public class Class1
    {
        private IInterviewUserContex UserContex;
        private IDealerService Service;
        private DbContext DBContext;

        public void SetContext(IInterviewUserContex userContex, DbContext dbContext, IDealerService service)
        {
            this.UserContex = userContex;
            this.Service = service;
            this.DBContext = dbContext;
        }

        public IQueryable<CarEntity> GetCars()
        {
            return DBContext.Set<CarEntity>();
        }

        public IQueryable<TruckEntity> GetTrucks()
        {
            return DBContext.Set<TruckEntity>();
        }

        public IQueryable<BusEntity> GetBuses()
        {
            return DBContext.Set<BusEntity>();
        }

        public string UpdatePriceOfTrucks(IEnumerable<TruckModel> truckModels)
        {
            var entities = GetTrucks();
            var userMessage = "";
            foreach (var entity in entities)
            {
                var truckModel = truckModels.FirstOrDefault(c => c.Id == entity.Id);
                userMessage = userMessage + UpdateTruck(truckModel, entity);
            }
            Service.UpdateVehicle(truckModels, UserContex);
            return userMessage;
        }

        private string UpdateTruck(TruckModel truckModel, TruckEntity entity)
        {
            entity.Price = truckModel.Price;
            return string.Format("Updated car price is {0}.", truckModel.Price);
        }

        public string UpdatePriceOfCars(IEnumerable<CarModel> carModels)
        {
            if (!HasAccess(UserContex))
                throw new Exception();
            var entities = GetCars();
            var userMessage = "";
            foreach (var entity in entities)
            {
                var carModel = carModels.FirstOrDefault(c => c.Id == entity.Id);
                userMessage = userMessage + UpdateCar(carModel, entity);
            }
            Service.UpdateVehicle(carModels, UserContex);
            return userMessage;
        }

        private string UpdateCar(CarModel carModel, CarEntity carEntity)
        {
            carEntity.Price = carModel.Price;
            return string.Format("Updated car price is {0}.", carModel.Price);
        }

        public string UpdatePriceOfBus(IEnumerable<BusModel> busModels)
        {
            var entities = GetBuses();
            var userMessage = "";
            foreach (var entity in entities)
            {
                var busModel = busModels.FirstOrDefault(c => c.Id == entity.Id);
                userMessage = userMessage + UpdateBus(busModel, entity);
            }
            Service.UpdateVehicle(busModels, UserContex);
            return userMessage;
        }

        private string UpdateBus(BusModel busModel, BusEntity busEntity)
        {
            busEntity.Price = busModel.Price;
            return string.Format("Updated bus price is {0}.", busModel.Price);
        }

        private bool HasAccess(IInterviewUserContex userContext)
        {
            return userContext.HasAccessToVechicle<CarModel>();
        }
    }
}
