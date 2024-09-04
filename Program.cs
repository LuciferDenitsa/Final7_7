namespace DeliveryService
{

    abstract class Delivery
    {
        public string Address;

        public Delivery(string address)
        {
            Address = address;
        }
    }

    class HomeDelivery : Delivery
    {
        public string _customerName;

        public HomeDelivery(string customerName, string address) : base(address)
        {
            _customerName = customerName;
        }
    }

    class PickPointDelivery : Delivery
    {
        public string _customerName;
        public PickPointDelivery(string customerName, string address) : base(address)
        {
            _customerName = customerName;
        }
    }

    class ShopDelivery : Delivery
    {
        public string _shopName;
        public string _customerName;

        public ShopDelivery(string shopName, string customerName, string address) : base(address)
        {
            _shopName = shopName;
            _customerName = customerName;
        }
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public int idOrder;

        public TDelivery delivery;

        public Product product;

        public int count;

        public Courier courier;

        public void DisplayOrderInfo()
        {
            if (delivery is HomeDelivery)
            {
                Console.WriteLine("Доствка на дом");
            }
            else if (delivery is ShopDelivery)
            {
                Console.WriteLine("Доствка в магазин");
            }
            else if (delivery is PickPointDelivery)
            {
                Console.WriteLine("Пункт выдачи товара");
            }
            Console.WriteLine("Адрес: {0}", delivery.Address);
            Console.WriteLine("Товар: {0}", product._name);
            Console.WriteLine("Стоймость товара: {0}", product._price);
            Console.WriteLine("Количество: {0}", count);
            if (courier != null)
            {
                Console.WriteLine("Курьер: {0}", courier._name);
            }
        }

        public Order(int idOrder, TDelivery delivery, Product product, int count, Courier courier)
        {
            this.idOrder = idOrder;
            this.delivery = delivery;
            this.product = product;
            this.count = count;
            this.courier = courier;
        }
    }

    class Product
    {
        public string _name;
        public int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }

    class Courier
    {
        public string _name;
        public string _telnumber;

        public Courier(string name, string telnumber)
        {
            _name = name;
            _telnumber = telnumber;
        }
    }

    class Customer
    {
        public string _name;
        public string _address;
        public Customer(string name, string address)
        {
            _name = name;
            _address = address;
        }
    }

    class Shop
    {
        public string _name;
        public string _address;
        public Shop(string name, string address)
        {
            _name = name;
            _address = address;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new("Vladimir", "Add1");
            Customer customer2 = new("Andrey", "Add2");
            Shop shop1 = new("Lenta", "Lenina 1");
            HomeDelivery homeDelivery1 = new(customer2._name, customer2._address);
            ShopDelivery shopDelivery1 = new(shop1._name, customer1._name, shop1._address);
            PickPointDelivery pickPointDelivery1 = new(customer2._name, "Smolenskaya 34");
            Product product1 = new("Watch", 5);
            Product product2 = new("Phone", 12);
            Courier courier1 = new("Vlad", "89134184488");
            Courier courier2 = new("Dima", "89193182345");

            Order<HomeDelivery> order1 = new(1, homeDelivery1, product1, 2, courier1);
            Order<ShopDelivery> order2 = new(2, shopDelivery1, product2, 20, courier2);
            Order<PickPointDelivery> order3 = new(3, pickPointDelivery1, product1, 1, courier1);

            
            order1.DisplayOrderInfo();
            Console.WriteLine();
            order2.DisplayOrderInfo();
            Console.WriteLine();
            order3.DisplayOrderInfo();
        }
    }
}
