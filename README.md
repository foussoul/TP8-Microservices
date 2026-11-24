# TP8 - Architecture Microservices (ASP.NET Core)

## Projets
- ProductsAPI (https://localhost:7204)
- OrdersAPI (https://localhost:7295)
- ApiGateway (Ocelot, https://localhost:7286)
- Shared (classe ProductCreated)

## Prérequis
- .NET 10, SQL Server LocalDB
- Docker : `docker run -d --hostname my-rabbit --name ecomm -p 4001:5672 -p 15672:15672 rabbitmq:3-management`

## Lancement
1. Lancer RabbitMQ (Docker)
2. Démarrage multiple : ProductsAPI, OrdersAPI, ApiGateway
3. Test : POST https://localhost:7286/apigateway/Products

## Auteur
Bahri Foussoul - GLNT 1
