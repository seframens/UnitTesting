using TestingLib.Shop;
using TestingLib.Weather;
using Moq;

namespace UnitTesting.seframens
{
    public class LabWork7Test
    {
        private readonly Mock<IWeatherForecastSource> mockWeatherForecastSource;
        private readonly Mock<IOrderRepository> mockOrderRepository;
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        private readonly Mock<INotificationService> mockNotificationService;

        public LabWork7Test()
        {
            mockWeatherForecastSource = new Mock<IWeatherForecastSource>();
            mockOrderRepository = new Mock<IOrderRepository>();
            mockCustomerRepository = new Mock<ICustomerRepository>();
            mockNotificationService = new Mock<INotificationService>();
        }

        [Fact]
        public void GetWeatherForecast_ShouldReturnCorrectValue()
        {
            var weather = new WeatherForecast { Summary = "Дождь", TemperatureC = -2 };
            DateTime date = DateTime.Now;

            mockWeatherForecastSource.Setup(repo => repo.GetForecast(date)).Returns(weather);

            var servise = new WeatherForecastService(mockWeatherForecastSource.Object);

            var result = servise.GetWeatherForecast(date);

            Assert.NotNull(result);
            mockWeatherForecastSource.Verify(repo => repo.GetForecast(It.IsAny<DateTime>()), Times.Once());
        }

        [Fact]
        public void CreateOrder_ShouldOrderCorrectValue()
        {
            var customer = new Customer { Id = 1, Name = "Кирилл", Email = "testing@mail.ru" };
            var order = new Order { Id = 2, Date = DateTime.Now, Customer = customer, Amount = 2 };

            mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            service.CreateOrder(order);

            mockOrderRepository.Verify(repo => repo.GetOrderById(It.IsAny<int>()), Times.Once());
            mockOrderRepository.Verify(repo => repo.AddOrder(It.IsAny<Order>()), Times.Once());
        }

        [Fact]
        public void CreateOrder_ShouldNotificationCorrectValue()
        {
            var customer = new Customer { Id = 1, Name = "Кирилл", Email = "testing@mail.ru" };
            var order = new Order { Id = 2, Date = DateTime.Now, Customer = customer, Amount = 2 };

            mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            service.CreateOrder(order);

            mockNotificationService.Verify(repo => repo.SendNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void GetCustomerInfo_ShouldInfoCorrectValue()
        {
            var customer = new Customer { Id = 1, Name = "Кирилл", Email = "testing@mail.ru" };

            mockCustomerRepository.Setup(repo => repo.GetCustomerById(1)).Returns(customer);
            mockOrderRepository.Setup(repo => repo.GetOrders()).Returns(new List<Order> { new Order { Customer = customer }, new Order { Id = 2, Date = DateTime.Now, Customer = customer, Amount = 2 } });

            var service = new ShopService(mockCustomerRepository.Object, mockOrderRepository.Object, mockNotificationService.Object);

            var result = service.GetCustomerInfo(1);

            Assert.Equal("Customer " + customer.Name + "has 2 orders", result);
            mockOrderRepository.Verify(repo => repo.GetOrders(), Times.Once);
            mockCustomerRepository.Verify(repo => repo.GetCustomerById(It.IsAny<int>()), Times.Once);
        }
    }
}
