# AtlantidaBank
Este repositorio contiene una prueba realizada para el Banco Atlántida, implementada con tecnologías de desarrollo de última generación en el ecosistema .NET. Consta de dos proyectos: ASP.NET CORE Web API con .NET 6 (Servicio) y ASP.NET CORE con .NET 6 MVC (Cliente)

## Encuentra mi perfil [linkedin](https://www.linkedin.com/in/jos%C3%A9-eduardo-guevara-soria-7a5956157/).

## Tecnologías Utilizadas:
- ASP.NET CORE Web API con .NET 6 (Servicio): la API proporciona la funcionalidad principal para interactuar con los servicios del Banco Atlántida
- ASP.NET CORE con .NET 6 MVC (Cliente) : La interfaz de usuario del cliente el cual consume la API

## Recursos:
- Script de la base datos con la estructura y data
- Backup de la base de datos
- Proyecto .Zip
- Proyecto

## Consideraciones para ejecutar el proyecto

- Se debe modificar el archivo appsettings.json el bloque de conexion a la base de datos
```json
"ConnectionStrings": {
  "AtlantidaBankConnection": "Server=localhost; Database=AtlantidaBank; User Id=sa; Password=[clave]; TrustServerCertificate=True"
}
```
- Las credenciales para el login son: usuario: **jsoria** y clave: **admin**
- Se debe configurar el proyecto para que inicie con las dos soluciones
[image](https://github.com/JESoria/AtlantidaBank/assets/45598614/22493512-ddbc-42d7-856b-f967b9e1cce3)

## AtlantidaBankAPI:

## API endpoints:

```json
Token
POST
Ruta: /api/Token/GetToken
Request body

{
  "username": "string",
  "password": "string"
}

CreditCard
POST
Ruta: /api/CreditCard/GetBonifiableInterest
Request body
{
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetCalculateMinimumPayment
Request body
{
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetCurrentPurchases
Request body
{
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetAccount
Request body
{
  "userId": "string",
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetTotalAmountToPay
Request body
{
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetTotalCashAmountToPayWithInterest
Request body
{
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetTotalPurchases
Request body
{
  "crediCardId": "string"
}

POST
Ruta: /api/CreditCard/GetAllTransactionsForCreditCard
Request body
{
  "crediCardId": "string"
}

Shopping

POST
Ruta: /api/Shopping/AddPurchase
Request body
{
  "crediCardId": "string",
  "transactionDate": "string",
  "description": "string",
  "amount": "string",
  "ipAddress": "string"
}

POST
Ruta: /api/Shopping/MakePayment
Request body
{
  "crediCardId": "string",
  "transactionDate": "string",
  "description": "string",
  "amount": "string",
  "ipAddress": "string"
}
```
