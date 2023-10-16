﻿using Crm.BusinessLogic;
using Crm.DataAccess;

IClientService clientService = ClientServiceFactory.CreateClientService();
IOrderService orderService = OrderServiceFactory.CreateOrderService();


System.Console.WriteLine("Чтобы создать пользователя наберите <Create client>, чтобы пропустить нажмите <enter> ");
string command = Console.ReadLine();
ClientService service = new();

if (command.Equals("Create client"))
{
    System.Console.WriteLine("Скольких клиентов хотите создать?");
    int count = int.Parse(Console.ReadLine());
    while (count > 0)
    {
        CreateClient();
        System.Console.WriteLine("Creating client...");
        count--;
    }
    System.Console.WriteLine("Чтобы получить пользователя наберите <yes>, чтобы пропустить нажмите <enter>");
    command = Console.ReadLine();
    if (command.Equals("yes"))
    {
        System.Console.WriteLine("Введите имя затем нажав <enter> введите фамилию: ");
        var myClient = clientService.GetClient(Console.ReadLine(), Console.ReadLine());

        System.Console.WriteLine($"Name: {myClient.Value.FirstName}\nLast Name: {myClient.Value.LastName}\nMiddle Name: {myClient.Value.MiddleName}\nAge: {myClient.Value.Age}\nPassport Number: {myClient.Value.PassportNumber}\nPhone Number: {myClient.Value.Phone}");
    }
    System.Console.WriteLine("Чтобы изменить имя и фамилию пользователя наберите <yes>, чтобы пропустить нажмите <enter>");
    command = Console.ReadLine();
    if (command.Equals("yes"))
    {
        System.Console.WriteLine("Наберите имя и фамилию пользователя: ");
        System.Console.WriteLine("Введите имя: ");
        string searchFirstName = Console.ReadLine();
        System.Console.WriteLine("Введите фамилию: ");
        string searchLastName = Console.ReadLine();
        System.Console.WriteLine("Теперь введите изменения: ");
        System.Console.WriteLine("Имя: ");
        string newFirstName = Console.ReadLine();
        System.Console.WriteLine("Фамилия: ");
        string newLastName = Console.ReadLine();
        var ChangeClientName = clientService.ChangeClientName(searchFirstName, searchLastName, newFirstName, newLastName);
        if (ChangeClientName)
        {
            System.Console.WriteLine("изменения успешно сохранены!");
        }
    }
}
System.Console.WriteLine("Чтобы оформить заказ наберите <Create order>, чтобы пропустить нажмите <enter>");
command = Console.ReadLine();
if (command.Equals("Create order"))
{
    System.Console.WriteLine("Введите количество заказов: ");
    int count = int.Parse(Console.ReadLine());
    while (count > 0)
    {
        GetOrderDetails();
        System.Console.WriteLine("Creating order...");
        count--;
    }

    System.Console.WriteLine("Чтобы найти заказ наберите <yes>, чтобы пропустить нажмите <enter>");
    command = Console.ReadLine();
    if (command.Equals("yes"))
    {
        System.Console.WriteLine("Введите описание заказа: ");
        command = Console.ReadLine();
        var myOrder = orderService.GetOrder(command);
        System.Console.WriteLine($"id: {myOrder.Value.Id}\nОписание: {myOrder.Value.Description}\nЦена: {myOrder.Value.Price}\nДата заказа: {myOrder.Value.Date}\nТип доставки: {myOrder.Value.DeliveryType}\nАдрес: {myOrder.Value.DeliveryAddress}\nСтатус заказа: {myOrder.Value.NewOrderState}");
    }
    System.Console.WriteLine("Чтобы изменить описание заказа наберите <change> или <ch>, чтобы пропустить нажмите <enter>");
    command = Console.ReadLine();
    if (command.Equals("change") || command.Equals("ch"))
    {
        System.Console.WriteLine("Введите id или описание заказа!");
        string getId = Console.ReadLine();
        string getNewDasciption = Console.ReadLine();
        var changeOrder = orderService.ChangeDescription(getId, getNewDasciption);
        if (changeOrder)
        {
            System.Console.WriteLine("Изменения успешно сохранены!");
        }
    }

    System.Console.WriteLine("Чтобы удалить заказ наберите <Del>, чтобы пропустить нажмите <enter>");
    command = Console.ReadLine();
    if (command.Equals("Del"))
    {
        System.Console.WriteLine("Введите ордер для удаления заказа: ");
        orderService.DeleteOrder(Console.ReadLine());
    }

    System.Console.WriteLine("Чтобы изменить состояние заказа введите <yes>, чтобы пропустить нажмите <enter>");
    command = Console.ReadLine();
    if (command.Equals("yes"))
    {
        System.Console.WriteLine("Введите id заказа");
        long command1 = long.Parse(Console.ReadLine());
        System.Console.WriteLine("чтобы изменить состояние заказа введите: <0> - Ожидание, <1> - одобренный <2> - отменён");
        OrderState command2 = Enum.Parse<OrderState>(Console.ReadLine());
        bool result = orderService.UpdateOrderState(command1, command2);
        if (!result)
            throw new Exception("пользователь не найден!");
        else System.Console.WriteLine("Состояние заказа успешно изменено!");
    }

}
else System.Console.WriteLine("Не известная команда!");

/*
System.Console.WriteLine("Чтобы перейти в раздел статистики наберите <stat>, чтобы пропустить нажмите <enter> ");
command = Console.ReadLine();
if (command.Equals("stat"))
{
    int statistics = clientService.GetClientCount();
    System.Console.WriteLine("Количество созданных пользователей: " + statistics);
    statistics = orderService.GetOrderCount();
    System.Console.WriteLine("Количество созданных заказов: " + statistics);
    statistics = orderService.PendingStatistics();
    System.Console.WriteLine("Количество заказов в ожидании: " + statistics);
    statistics = orderService.ApprovedStatistics();
    System.Console.WriteLine("Количество подтверждённых заказов: " + statistics);
    statistics = orderService.CancelledStatistics();
    System.Console.WriteLine("Количество отменнёных заказов: " + statistics);
}
*/
void CreateClient()
{
    System.Console.WriteLine("Введите имя: ");
    string firstName = Console.ReadLine();
    System.Console.WriteLine("Введите Фамилию: ");
    string lastName = Console.ReadLine();
    System.Console.WriteLine("Введите отчество: ");
    string middleName = Console.ReadLine();
    System.Console.WriteLine("Ваш возраст: ");
    string ageInputStr = Console.ReadLine();
    System.Console.WriteLine("Введите номер паспорта: ");
    string passportNumber = Console.ReadLine();
    System.Console.WriteLine("Выберите свой гендер (0 - Male, 1 - Female): ");
    string genderInpurStr = Console.ReadLine();
    System.Console.WriteLine("Введите номер телефона: ");
    string userPhone = Console.ReadLine();
    System.Console.WriteLine("Введите вашу почту: ");
    string userEmail = Console.ReadLine();
    System.Console.WriteLine("Придумайте пароль: ");
    string userPassword = Console.ReadLine();
    System.Console.WriteLine("Повторите пароль: ");
    string userPassword2 = Console.ReadLine();

    if (!ValidateClient(firstName, lastName, middleName, ageInputStr, passportNumber, genderInpurStr, userPhone, userEmail, userPassword, userPassword2))
    {
        System.Console.WriteLine("Validation error!");
        return;
    }

    short age = short.Parse(ageInputStr);

    clientService.CreateClient(new ClientInfo()
    {
        FirstName = firstName,
        LastName = lastName,
        MiddleName = middleName,
        Age = age,
        PassportNumber = passportNumber,
        Gender = genderInpurStr,
        Phone = userPhone,
        Email = userEmail,
        Password = userPassword

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
    System.Console.WriteLine("Введите статус заказа: Pending = 0, Approved = 1, Cancelled = 2");
    string OrderStateStr = Console.ReadLine();

    if (!ValidateOrder(orderIdStr,
    orderDescription,
    orderPriceStr,
    orderDeliveryTypeStr,
    orderDeliveryAddress,
    OrderStateStr))
        return;

    short orderId = short.Parse(orderIdStr);
    decimal orderPrice = decimal.Parse(orderPriceStr);

    orderService.CreateOrder(new OrderInfo()
    {
        Id = orderId,
        Description = orderDescription,
        Price = orderPrice,
        Date = orderDate,
        DeliveryType = orderDeliveryTypeStr,
        DeliveryAddress = orderDeliveryAddress,
        NewOrderState = OrderStateStr
    });
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

    if (firstname is { Length: 0 })
        errors.Add("Поле имя объязательно!");
    if (lastname is { Length: 0 })
        errors.Add("Поле Фамилия объязательно");
    if (middleName is { Length: 0 })
        errors.Add("Поле отчество объязательно");
    bool isAgeCorrect = short.TryParse(ageStr, out short age);
    if (!isAgeCorrect)
        errors.Add("Введены не правельные значения!");
    if (passportnum is { Length: 0 })
        errors.Add("Введите корректно свой номер паспорта!");
    if (genderStr != "1" && genderStr != "0")
        errors.Add("Пожалуйста введите корректные данные для поля Гендер (0 - Male, 1 - Female)!");
    if (userPhone is { Length: 0 })
        errors.Add("Поле телефон не может быть пустым!");
    if (userEmail is { Length: 0 })
        errors.Add("Поле e-mail не может быть пустым!");
    if (userPassword is { Length: 0 } || userPasswordForCheck is { Length: 0 })
        errors.Add("Поле пароль не може быть пустым!");
    bool areEqual = userPassword.Equals(userPasswordForCheck);
    if (!areEqual)
        errors.Add("Пароли отличаются!");

    if (errors is { Count: > 0 })
    {
        foreach (string errorMessage in errors)
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
    string orderDeliveryAddress,
    string OrderState)
{
    List<string> errors = new();
    bool isIdCorrect = ushort.TryParse(orderIdStr, out ushort orderId);
    if (!isIdCorrect)
        errors.Add("Введите корректный ID!");
    if (orderDescription is { Length: 0 })
        errors.Add("Поле описания объязательна!");
    bool isOrderPriceCorrect = decimal.TryParse(orderPriceStr, out decimal orderPrice);
    if (!isOrderPriceCorrect)
        errors.Add("Не указанна цена!");
    if (orderDeliveryType is not "0" || orderDeliveryType is not "1")
        errors.Add("Выберите корректно доставку (0 - free, 1 - express)!");
    if (orderDeliveryAddress is { Length: 0 })
        errors.Add("Поле адресс является объязательным!");
    if (OrderState is not "0" || OrderState is not "1" || OrderState is not "2")
        errors.Add("Поле статус заказа введены не корректно!!");

    if (errors is { Count: > 0 })
    {
        foreach (string errorMessage in errors)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
        }
        Console.ForegroundColor = ConsoleColor.White;
        return false;
    }

    return true;

}