# OrderManagementSystem
## Описание
Система управления заказами с использованием микросервисной архитектуры.
Включает в себя два независимых микросервиса, взаимодействующих между собой.

### Сервис 1 (RepositoryService)
- Хранит информацию о товарах  и заказах.
- Предоставляет REST API для получения информации о товарах, заказах, деталях заказа.
- Использует БД для хранения данных.

### Сервис 2 (OrderManagementSystem)
- Обрабатывает создание и отмену заказа, изменение статуса заказа, редактирование заказа (удалить/добавить товар).
- Предоставляет REST API для управления заказами.
- Взаимодействует с RepositoryService посредством http-запросов и отправкой сообщений в очередь RabbitMQ

## Технологии
1. ASP.NET CORE
2. PostgreSQL
3. Entity Framework Core
4. Linq
5. Automapper
6. Swagger, Postman
7. MediatR
8. CQRS
9. RabbitMQ
10. Чистая архитектура
11. UnitOfWork
12. FluentValidation
13. Serilog - логирование данных в файл и консоль

## Установка и настройка
### Общее
Для работы и корректного взаимодействия между микросервисами необходимо установить броке сообщений RabbitMQ локально на устройство либо через докер:
```
docker run -d --hostname my-rabbit --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management
```
*Примечание: При желании можно установить другую версию контейнера с другими портами*

### Сервис 1 (RepositoryService)
Для работы сервиса необходимо:
1. Задать подключение к базе данных PostgreSQL в файле `appsettings.json`
2. Задать настройки и ключи для обмена RabbitMQ в файле `appsettings.json` в секции `RabbitMQ`.
На данный момент стоят настройки по умолчанию.

### Сервис 2 (OrderManagementSystem)
Для работы сервиса необходимо:
1. Задать адрес для подключения к **Сервису 1** в файле `appsettings.json` в секции `Microservices:RepositoryService`.<br/> Дополнительно можно задать время ожидания в миллисекунда `"Timeout": 1000`
2. Задать настройки и ключи для обмена RabbitMQ в файле `appsettings.json` в секции `RabbitMQ`.<br/> На данный момент стоят настройки по умолчанию.

Дополнительно можно настроить:
1. Стандартное количество дней хранения товара в секции `OrdersOptions`.
2. Путь до xml-документации (пример для Сервиса 2):
![image](https://github.com/user-attachments/assets/ab91f2c0-aa89-475c-a7ac-354ed11e8131)
