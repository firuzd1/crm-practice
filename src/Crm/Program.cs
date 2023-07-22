using Crm.Entities;
using Crm.Services;

ClientService clientService = new();

System.Console.WriteLine("Чтобы создать пользователя наберите <Create client> ");
System.Console.WriteLine("Чтобы оформить заказ наберите <Create Order>");
string command = Console.ReadLine();

if(command.Equals("Create client"))
{
    CreateClient();
    System.Console.WriteLine("Creating client...");
}
else if(command.Equals("Create order"))
{
    GetOrderDetails();
    System.Console.WriteLine("Creating order...");
}else System.Console.WriteLine("Заходите ещё!");

void CreateClient()
{
    string firstName = GetString("Введите фамилию: ");
    string lastName = GetString("Введите имя: ");
    string middleName = GetString("Введите отчество: ");
    short age = GetNumber("Введите ваш возраст: ");
    string passportNumber = GetString("Введите номер паспорта: ");
    Gender gender = (Gender) GetNumber("Ваш пол: 1 - Male, 2 - Female");

    Client newClient = clientService.CreateClient(
        firstName,
        lastName,
        middleName,
        age,
        passportNumber,
        gender
    );

    Console.WriteLine("Client Name: {0}",string.Join(' ', newClient.FirstName, newClient.MiddleName, newClient.LastName));

    Console.WriteLine("Client Age: {0}", newClient.Age);
    Console.WriteLine("Client Passport Number: {0}", newClient.PassportNumber);
}
void GetOrderDetails()
{
    Order order = new Order();
    
    order.OrderId = GetNumber("Введите идентификатор заказа:");

    order.OrderDescription = GetString("Введите описание заказа:");

    Console.WriteLine("Введите цену заказа:");
    order.OrderPrice = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Введите дату заказа (в формате дд.мм.гггг):");
    order.OrderDate = Convert.ToDateTime(Console.ReadLine());

    order.OrderDeliveryType = GetString("Введите тип доставки:");

    order.OrderDeliveryAddress = GetString("Введите адрес доставки:");

    System.Console.WriteLine("Идентификатор заказа: {0}\nOписание заказа: {1}\nЦена заказа: {2}\nДата заказа: {3}\nТип доставки: {4}\nAдрес доставки: {5}",
    order.OrderId, order.OrderDescription, order.OrderPrice, order.OrderDate, order.OrderDeliveryType, order.OrderDeliveryAddress);
}

string GetString(string name)
{
    string word;
    do
    {
    System.Console.WriteLine(name);
    word = Console.ReadLine();
    }while(string.IsNullOrWhiteSpace(word));
    return word;
}

short GetNumber(string info)
{
    short number1; 
    string number;
    bool result;
    do
    {
        System.Console.WriteLine(info);
        number = Console.ReadLine();
        result = short.TryParse(number, out number1);
    }
    while(number1 <= 0 || !result); 
    return number1;
}