namespace OnlineBookstoreManagement
{
    public class OrderDetails
    {
        int _orderId;
        string _title;
        string _author;
        string _genre;
        double _price;
        int _quantity;

        public int OrderId
        {
            get => _orderId;
            set => _orderId = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public string Genre
        {
            get => _genre;
            set => _genre = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public OrderDetails(int orderId, string title, string author, string genre, double price, int quantity)
        {
            OrderId = orderId;
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Price: {Price}, Quantity: {Quantity}";
        }

        //This code returns OrderDetails List from OrderDetails.txt file
        public static List<OrderDetails> GetAllOrderDetails()
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            string[] orderDetailsString = File.ReadAllLines("OrderDetails.txt");
            foreach (var orderDetailString in orderDetailsString)
            {
                string[] orderDetailProperties = orderDetailString.Split(",");
                OrderDetails orderDetail = new OrderDetails(int.Parse(orderDetailProperties[0]), orderDetailProperties[1], orderDetailProperties[2], orderDetailProperties[3], double.Parse(orderDetailProperties[4]), int.Parse(orderDetailProperties[5]));
                orderDetails.Add(orderDetail);
            }

            return orderDetails;
        }

        //This code adds new OrderDetail to OrderDetails.txt file
        public static void AddOrderDetail(OrderDetails orderDetail)
        {
            File.AppendAllText("OrderDetails.txt", $"{orderDetail.OrderId},{orderDetail.Title},{orderDetail.Author},{orderDetail.Genre},{orderDetail.Price},{orderDetail.Quantity}\n");
        }       

    }
}
