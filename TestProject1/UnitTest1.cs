using BGlobal.Controllers;
using BGlobal.Data;
using BGlobal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void NewVehiclePatenteOk()
        {
            //Arrenge
            var context = new ApplicationDbContext();
            Vehicle vehicle = new Vehicle();
            vehicle.Patente = "BBBZZZ333";
            vehicle.Marca = "Fiat";
            vehicle.Modelo = "Fuego";
            vehicle.Puertas = 4;
            vehicle.Dueño = "George Bluth";
          

        //Act
        HomeController controller = new HomeController(context);
            var result = controller.Create(vehicle);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NewVehiclePatenteShorter()
        {
            //Arrenge
            var context = new ApplicationDbContext();
            Vehicle vehicle = new Vehicle();
            vehicle.Patente = "BBBZZZ333";
            vehicle.Marca = "Fiat";
            vehicle.Modelo = "Fuego";
            vehicle.Puertas = 4;
            vehicle.Dueño = "George Bluth";

            //Act
            HomeController controller = new HomeController(context);
            var result = controller.Create(vehicle);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NewVehiclePatenteLonger()
        {
            //Arrenge
            var context = new ApplicationDbContext();
            Vehicle vehicle = new Vehicle();
            vehicle.Patente = "BBBZZZ333";
            vehicle.Marca = "Fiat";
            vehicle.Modelo = "Fuego";
            vehicle.Puertas = 4;
            vehicle.Dueño = "George Bluth";

            //Act
            HomeController controller = new HomeController(context);
            var result = controller.Create(vehicle);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
