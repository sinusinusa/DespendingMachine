Проекты настроены под адрес:порт:
Фронтенд: https://localhost:7246/
Бэкенд: https://localhost:7167/

Swagger: https://localhost:7167/swagger/index.html

Перед запуском установите connection string в .\DespendingMachine\DespendingMachine\appsettings.Development.json !!!

Бэк написан на Asp.Net core (.NET 6) и EF Core (обязательно применить миграции!!!! PW: "dotnet ef database update" в папке проекта)

Фронт запускается на Blazor веб-сервере (bootstrap верстка + js + инъекции), база данных Postgres,
чтобы зайти в админку используйте /User/admin/{secret}
При запуске инициализируется ключ "mysecret" -  т.е адрес становится https://localhost:7167/User/admin/mysecret

Также при запуске вносятся монеты для использования автоматом - номинал 1,2,5,10 рублей, в админке можно поменять количество/доступность

Страничка пользователя находится во вкладке боковой панели /Despending


