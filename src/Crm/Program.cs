using Crm.Entities;
using Crm.Services;


System.Console.WriteLine("Чтобы создать пользователя наберите <Create client> ");
System.Console.WriteLine("Чтобы оформить заказ наберите <Create order>");
string command = Console.ReadLine();
ClientService service = new();
OrderService orderService = new();

if(command.Equals("Create client"))
{
    System.Console.WriteLine("Скольких клиентов хотите создать?");
    int count = int.Parse(Console.ReadLine());
    while(count > 0)
    {
    CreateClient();
    System.Console.WriteLine("Creating client...");
    count--;
    }
     System.Console.WriteLine("Чтобы получить пользователя наберите <yes>");
    command = Console.ReadLine();
    if (command.Equals("yes"))
    {
        System.Console.WriteLine("Введите имя затем нажав <enter> введите фамилию: ");
        Client myClient = service.GetClient(Console.ReadLine(), Console.ReadLine());
        System.Console.WriteLine($"Name: {myClient.FirstName}\nLast Name: {myClient.LastName}\nMiddle Name: {myClient.MiddleName}\nAge: {myClient.Age}\nPassport Number: {myClient.PassportNumber}\nPhone Number: {myClient.UserPhone}");
    }
    System.Console.WriteLine("Чтобы изменить имя и фамилию пользователя наберите <yes>");
    command = Console.ReadLine();
    if(command.Equals("yes"))
    {
        System.Console.WriteLine("Введите имя после нажав на <enter> введите фамилию!");
        Client ChangeClientName = service.ChangeClientName(Console.ReadLine(), Console.ReadLine());
        System.Console.WriteLine($"Name: {ChangeClientName.FirstName}\nLast Name: {ChangeClientName.LastName}\nMiddle Name: {ChangeClientName.MiddleName}\nAge: {ChangeClientName.Age}\nPassport Number: {ChangeClientName.PassportNumber}\nPhone Number: {ChangeClientName.UserPhone}");

    }
}
else if(command.Equals("Create order"))
{
    System.Console.WriteLine("Введите количество заказов: ");
    int count = int.Parse(Console.ReadLine());
    while(count > 0)
    {    
        GetOrderDetails();
        System.Console.WriteLine("Creating order...");
        count--;
    }

System.Console.WriteLine("Чтобы найти заказ наберите <yes>");
command = Console.ReadLine();
if(command.Equals("yes"))
{
    System.Console.WriteLine("Введите описание заказа: ");
    command = Console.ReadLine();
    Order myOrder = orderService.GetOrder(command);
    System.Console.WriteLine($"id: {myOrder.OrderId}\nОписание: {myOrder.OrderDescription}\nЦена: {myOrder.OrderPrice}\nДата заказа: {myOrder.OrderDate}\nТип доставки: {myOrder.OrderDeliveryType}\nАдрес: {myOrder.OrderDeliveryAddress}");
}
System.Console.WriteLine("Чтобы изменить описание заказа наберите <change> или <ch>");
command = Console.ReadLine();
if(command.Equals("change") || command.Equals("ch"))
{
    System.Console.WriteLine("Введите id или описание заказа!");
    Order changeOrder = orderService.ChangeDescription(Console.ReadLine());
    System.Console.WriteLine($"id: {changeOrder.OrderId}\nОписание: {changeOrder.OrderDescription}\nЦена: {changeOrder.OrderPrice}\nДата заказа: {changeOrder.OrderDate}\nТип доставки: {changeOrder.OrderDeliveryType}\nАдрес: {changeOrder.OrderDeliveryAddress}");
}

System.Console.WriteLine("Чтобы удалить заказ наберите <Del>");
command = Console.ReadLine();
if(command.Equals("Del"))
{
    System.Console.WriteLine("Введите ордер для удаления заказа: ");
    orderService.DeleteOrder(Console.ReadLine());
}

}else System.Console.WriteLine("Не известная команда!");

void CreateClient()
{
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
    System.Console.WriteLine("Введите номер телефона: ");
    string userPhone = Console.ReadLine();
    System.Console.WriteLine("Введите вашу почту: ");
    string userEmail = Console.ReadLine();
    System.Console.WriteLine("Придумайте пароль: ");
    string userPassword = Console.ReadLine();
    System.Console.WriteLine("Повторите пароль: ");
    string userPassword2 = Console.ReadLine();

    if(!ValidateClient(firstName,lastName,middleName,ageInputStr,passportNumber,genderInpurStr, userPhone, userEmail, userPassword, userPassword2))
    {
        System.Console.WriteLine("Validation error!");
        return;
    }
        

    Gender gender = (Gender)int.Parse(genderInpurStr);
    short age = short.Parse(ageInputStr);

    Client newClient = service.CreateClient( new ClientInfo()
    {
        FirstName = firstName,
        LastName = lastName,
        MiddleName = middleName,
        Age = age,
        PassportNumber = passportNumber,
        Gender = gender,
        UserPhone = userPhone,
        UserEmail = userEmail,
        UserPassword = userPassword
        
    });
}
void GetOrderDetails()
{
    
    System.Console.WriteLine("Введите идентификатор заказа:");
    string orderIdStr = Console.ReadLine();
    System.Console.WriteLine("Введите описание заказа:");
    string orderDescription = Console.ReadLine();
    Console.WriteLine("Введите цену заказа:");
    string orderPriceStr = Console.ReadLine();
    Console.WriteLine("Введите дату заказа (в формате дд.мм.гггг):");
    DateTime orderDate = Convert.ToDateTime(Console.ReadLine());
    System.Console.WriteLine("Введите тип доставки: <1 - express, 0 - free>");
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
    decimal orderPrice = decimal.Parse(orderPriceStr);
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
    string genderStr,
    string userPhone,
    string userEmail,
    string userPassword,
    string userPasswordForCheck)
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
        if(userPhone is {Length: 0})
            errors.Add("Поле телефон не может быть пустым!");
        if(userEmail is {Length: 0})
            errors.Add("Поле e-mail не может быть пустым!");
        if(userPassword is {Length: 0} || userPasswordForCheck is {Length: 0})
            errors.Add("Поле пароль не може быть пустым!");
        bool areEqual = userPassword.Equals(userPasswordForCheck);
        if(!areEqual)
            errors.Add("Пароли отличаются!");

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