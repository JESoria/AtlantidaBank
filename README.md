# AtlantidaBank
Este repositorio contiene una prueba realizada para el Banco Atlántida, implementada con tecnologías de desarrollo de última generación en el ecosistema .NET. Consta de dos proyectos: ASP.NET CORE Web API con .NET 6 (Servicio) y ASP.NET CORE con .NET 6 MVC (Cliente)

## Tecnologías Utilizadas:
- ASP.NET CORE Web API con .NET 6 (Servicio): la API proporciona la funcionalidad principal para interactuar con los servicios del Banco Atlántida
- ASP.NET CORE con .NET 6 MVC (Cliente) : La interfaz de usuario del cliente el cual consume la API

## AtlantidaBankAPI:

## API endpoints:

```json
### Token
POST
Ruta: /api/Token/GetToken
Request body

{
  "username": "string",
  "password": "string"
}

### CreditCard
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

### Shopping

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
