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
- AtlantidaBankAPI.postman_collection

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

## Pasos para ejecutar proyecto

1. Ejecutar Script de base de datos o Backup
2. Modificar appsettings.json con la cadena de conexion
3. Ejecutar ambos proyectos, para ello se debe configurar la solución dando clic derecho -> Propiedades -> Proyectos de inicio y colocar ambos en "Iniciar"
4. Ejecutar proyecto
5. En el login colocar las credenciales usuario: **jsoria** y clave: **admin**
6. Una vez dentro del sistema puedes hacer testing segun la prueba PDF

## AtlantidaBankAPI:

## API endpoints:

### Consideraciones para hacer uso del API
- Utilizando POSTMAN se debe importar la coleccion AtlantidaBankAPI.postman_collection
- Se debe iniciar ejecutando el EndPont de Token y copiar el token que devuelva la API (Previo a haber ejecutado la BD)
- Cambiar el Token en Authorization de cada Endpoint a ejecutar esto debido a la caducida el cual es de 60 minutos

### Token
Metodo: POST
Ruta: /api/Token/GetToken
Request body
```json
{
  "username": "string",
  "password": "string"
}
```
### CreditCard
Metodo: POST
Ruta: /api/CreditCard/GetBonifiableInterest
Request body
```json
{
  "crediCardId": "string"
}
```

Metodo: POST
Ruta: /api/CreditCard/GetCalculateMinimumPayment
Request body
```json
{
  "crediCardId": "string"
}
```

Metodo: POST
Ruta: /api/CreditCard/GetCurrentPurchases
Request body
```json
{
  "crediCardId": "string"
}
```

Metodo: POST
Ruta: /api/CreditCard/GetAccount
Request body
```json
{
  "userId": "string",
  "crediCardId": "string"
}
```

Metodo: POST
Ruta: /api/CreditCard/GetTotalAmountToPay
Request body
```json
{
  "crediCardId": "string"
}
```

Metodo: POST
Ruta: /api/CreditCard/GetTotalCashAmountToPayWithInterest
Request body
```json
{
  "crediCardId": "string"
}
```

Metodo: POST
Ruta: /api/CreditCard/GetTotalPurchases
Request body
```json
{
  "crediCardId": "string"
}
```

Metodo:POST
Ruta: /api/CreditCard/GetAllTransactionsForCreditCard
Request body
```json
{
  "crediCardId": "string"
}
```

### Shopping

Metodo:POST
Ruta: /api/Shopping/AddPurchase
Request body
```json
{
  "crediCardId": "string",
  "transactionDate": "string",
  "description": "string",
  "amount": "string",
  "ipAddress": "string"
}
```

Metodo:POST
Ruta: /api/Shopping/MakePayment
Request body
```json
{
  "crediCardId": "string",
  "transactionDate": "string",
  "description": "string",
  "amount": "string",
  "ipAddress": "string"
}
```
