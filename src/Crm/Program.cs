using Crm.Entities;
using Crm.Services;


System.Console.WriteLine("Чтобы создать пользователя наберите <Create client> ");
System.Console.WriteLine("Чтобы оформить заказ наберите <Create order>");
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
}else System.Console.WriteLine("Не известная команда!");

void CreateClient()
{
    ClientService clientService = new();
    System.Console.WriteLine("Введите имя: ");
    string firstName = Console.ReadLine();
    System.Console.WriteLine("Введите Фамилию: ");
    string lastName =  Console.ReadLine();
    System.Console.WriteLine("Введите отчество: ");
    string middleName =  Console.ReadLine();
    System.Console.WriteLine("Ваш возраст: ");
    string ageInputStr = Console.ReadLine();
    System.Console.WriteLine("Введите номер паспорта: ");
    string passportNumber =  Console.ReadLine();
    System.Console.WriteLine("Выберите свой гендер (0 - Male, 1 - Female): ");
    string genderInpurStr =  Console.ReadLine();

    if(!ValidateClient(firstName,lastName,middleName,ageInputStr,passportNumber,genderInpurStr))
        return;

    Gender gender = (Gender)int.Parse(genderInpurStr);
    short age = short.Parse(ageInputStr);

    Client newClient = clientService.CreateClient( new ClientInfo()
    {
        FirstName = firstName,
        LastName = lastName,
        MiddleName = middleName,
        Age = age,
        PassportNumber = passportNumber,
        Gender = gender
    });

    Console.WriteLine("Client Name: {0}",string.Join(' ', newClient.FirstName, newClient.MiddleName, newClient.LastName));

    Console.WriteLine("Client Age: {0}", newClient.Age);
    Console.WriteLine("Client Passport Number: {0}", newClient.PassportNumber);
}
void GetOrderDetails()
{
    Order order = new Order();
    OrderService orderService = new();
    
    System.Console.WriteLine("Введите идентификатор заказа:");
    string orderIdStr = Console.ReadLine();
    System.Console.WriteLine("Введите описание заказа:");
    string orderDescription = Console.ReadLine();
    Console.WriteLine("Введите цену заказа:");
    string orderPriceStr = Console.ReadLine();
    Console.WriteLine("Введите дату заказа (в формате дд.мм.гггг):");
    DateTime orderDate = order.OrderDate = Convert.ToDateTime(Console.ReadLine());
    System.Console.WriteLine("Введите тип доставки:");
    string orderDeliveryTypeStr = Console.ReadLine();
    System.Console.WriteLine("Введите адрес доставки:");
    string orderDeliveryAddress = Console.ReadLine();

    if(!ValidateOrder(orderIdStr,
    orderDescription,
    orderPriceStr,
    orderDeliveryTypeStr,
    orderDeliveryAddress))
        return;

    short orderId = short.Parse(orderIdStr);
    decimal orderPrice = short.Parse(orderPriceStr);
    DeliveryType orderDeliveryType = (DeliveryType)int.Parse(orderDeliveryTypeStr);

    Order newOrder = orderService.CreateOrder( new OrderInfo()
    {
    OrderId = orderId,
    OrderDescription = orderDescription,
    OrderPrice = orderPrice,
    OrderDate = orderDate,
    OrderDeliveryType = orderDeliveryType,
    OrderDeliveryAddress = orderDeliveryAddress
    });
    System.Console.WriteLine(newOrder);
}

bool ValidateClient(
    string firstname,
    string lastname,
    string middleName,
    string ageStr,
    string passportnum,
    string genderStr)
    {
        List<string> errors = new();

        if(firstname is {Length: 0})
            errors.Add("Поле имя объязательно!");
        if(lastname is {Length: 0})
            errors.Add("Поле Фамилия объязательно");
        if(middleName is {Length: 0})
            errors.Add("Поле отчество объязательно");
        bool isAgeCorrect = short.TryParse(ageStr, out short age);
        if(!isAgeCorrect)
            errors.Add("Введены не правельные значения!");
        if(passportnum is {Length: 0})
            errors.Add("Введите корректно свой номер паспорта!");
        bool isGenderCorrect = int.TryParse(genderStr, out int genderIndex);
        if(!isGenderCorrect)
            errors.Add("для поля гендер введены не верные данные!");
        bool isEnumGenderCorrect = genderIndex.TryParse(out Gender gender);
        if(!isEnumGenderCorrect)
            errors.Add("Пожалуйста введите корректные данные для поля Гендер (0 - Male, 1 - Female)!");

            if(errors is {Count: >0})
            {
                foreach(string errorMessage in errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                }
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;

    }

    bool ValidateOrder(
        string orderIdStr,
        string orderDescription,
        string orderPriceStr,
        string orderDeliveryType,
        string orderDeliveryAddress)
        {
            List<string> errors = new();
            bool isIdCorrect = ushort.TryParse(orderIdStr, out ushort orderId);
            if(!isIdCorrect)
                errors.Add("Введите корректный ID!");
            if(orderDescription is {Length: 0})
                errors.Add("Поле описания объязательна!");
            bool isOrderPriceCorrect = decimal.TryParse(orderPriceStr, out decimal orderPrice);
            if(!isOrderPriceCorrect)
                errors.Add("Не указанна цена!");
            bool isDeliveryTypeCorrect = int.TryParse(orderDeliveryType, out int deliveryTypeIndex);
            if(!isDeliveryTypeCorrect)
            errors.Add("Поле тип доставки является объязательным!");
            bool isEnumDeliveryType = deliveryTypeIndex.TryParseForDeliverytype(out DeliveryType deliveyType);
            if(!isEnumDeliveryType)
                errors.Add("Выберите корректно доставку (0 - free, 1 - express)!");
            if(orderDeliveryAddress is {Length: 0})
                errors.Add("Поле адресс является объязательным!");
                
            if(errors is {Count: >0})
            {
                foreach(string errorMessage in errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                }
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            return true;

        }