# Prueba técnica Yansel Martínez

## Índice
1. [Ejecución de la aplicación](#ejecución-de-la-aplicación)
2. [Casos de uso](#casos-de-uso)
    - [Vehículos](#vehículos)
        1. [Listar vehículos](#1-listar-vehiculos)
        2. [Obtener detalles de un vehículo](#2-obtener-detalles-de-un-vehículo)
        3. [Agregar un nuevo vehículo](#3-agregar-un-nuevo-vehículo)
    - [Reservas](#reservas)
        1. [Obtener reserva](#1-obtener-reserva)
        2. [Crear nueva reserva](#2-crear-nueva-reserva)
        3. [Pagar reserva](#3-pagar-reserva)
        4. [Cancelar reserva](#4-cancelar-reserva)
        5. [Finalizar reserva](#5-finalizar-reserva)
3. [Resultados de las pruebas](#Resultados-de-las-pruebas)
    - [Users](#users)
    - [Vehicles](#vehicles)
    - [Bookings](#bookings)
    - [Payments](#payments)
4. [Testing](#testing)
    - [Prueba unitaria](#prueba-unitaria)
    - [Prueba de infraestructura](#prueba-de-infraestructura)
    - [Prueba funcional](#prueba-funcional)
5. [Mejoras a la aplicación](#mejoras-a-la-aplicación)


## Ejecución de la aplicación.

Para ejecutar la aplicación correctamente, se debe seleccionar el proyecto docker-compose como inicio, para poder ejecutar la aplicación con todas sus deopendencias base de datos sql server y redis.

**Fichero docker-compose**
```yml
services:
  gtmotive.estimate.microservice.host:
    image: ${DOCKER_REGISTRY-}gtmotiveestimatemicroservicehost
    build:
      context: .
      dockerfile: GtMotive.Estimate.Microservice.Host/Dockerfile
    depends_on:
      - gtmotive.estimate.microservice.sqlserverdb
      - gtmotive.estimate.microservice.rediscache

  gtmotive.estimate.microservice.sqlserverdb:
    image: mcr.microsoft.com/mssql/server:latest
    environment:
      ACCEPT_EULA: "Y"
      SA_PASSWORD: NuevaContra123#
    ports:
      - "1433:1433"
    volumes:
      - dbdata:/var/opt/mssql

  gtmotive.estimate.microservice.rediscache:
     image: redis:latest
     restart: always
     ports:
       - '6379:6379'
     volumes:
       - redis_volume_data:/data

  gtmotive.estimate.microservice.redisinsight:
    image: redislabs/redisinsight:1.14.0
    restart: always
    ports:
      - "8001:8001"
    volumes:
       - redis_insight_data:/db

volumes:
  dbdata:
  redis_volume_data:
  redis_insight_data:

```

## Casos de uso
## Vehículos
### 1. Listar vehiculos
**GET /api/Vehicles**
Si no existen vehículos en la base de datos el endpoint devuelve un **205 NoContent**, pero si existen vehículos, se devuelve entonces un **200 OK** con el listado.

**Request**
```
GET /api/Vehicles
```

**Response** 
> ```json
> [
>   {
>    "id": "a7253349-1463-4589-827b-2436ad9f0f74",
>    "vsn": "PKA-987",
>    "modelName": "Picanto",
>    "modelYear": 2021,
>    "price": 38.6,
>    "currency": "EUR"
>  },
>  {
>    "id": "9e36f048-021d-4d7c-8cd6-9185ec6c5d18",
>    "vsn": "AAA-123",
>    "modelName": "Qashqai",
>    "modelYear": 2022,
>    "price": 50,
>    "currency": "EUR"
>  }
> ]
> ```

### 2. Obtener detalles de un vehículo 
**GET /api/Vehicles/id**
La aplicación intenta obtener el vehículo de la memoria caché (redis), si lo encuentra entonces devuelve un **200 OK** con vehículo cacheado, pero, si no se encuentra el vehículo en la memoria cache, entonce lo busca en la base de datos y Si lo encuentra devuelve un **200 OK** con la información del vehículo.

**Request**
```
GET /api/Vehicles/9E36F048-021D-4D7C-8CD6-9185EC6C5D18
```
**Response** 
```json
{
  "id": "a7253349-1463-4589-827b-2436ad9f0f74",
  "vsn": "PKA-987",
  "modelName": "Picanto",
  "modelYear": 2021,
  "price": 38.6,
  "currency": "EUR"
}
```

Si el vehiculo no existe, se devuelve un **404 Not found**.


### 3. Agregar un nuevo vehículo 
**POST /api/Vehicles**

#### 3.1 Matrícula duplicada.
La aplicación valida que no se intente registrar un nuevo vehículo con una matricula ya existente, si se da este caso, se devuelve un **400 BadRequest** con un mensaje.

**Request**
```
POST /api/Vehicles
```
```json
{
  "vsn": "AAA-123",
  "modelBrand": "Kia",
  "modelName": "Picanto",
  "modelYear": 2019,
  "price": 38.60,
  "currency": "EUR"
}
```
**Response**
```
"The VSN: AAA-123 already exists. It can not be registered twice."
```

#### 3.2 Año del modelo mayor a 5 años.
La aplicación valida que el año del modelo del vehículo que se intenta registrar no sea mayor a 5 años, si se da el caso, se devuelve un **400 BadRequest** con un mensaje.

**Request**
```
POST /api/Vehicles
```
```json
{
  "vsn": "PDM-987",
  "modelBrand": "Nisan",
  "modelName": "Qashqai",
  "modelYear": 2019,
  "price": 50.00,
  "currency": "EUR"
}
```
**Reesponse**
```
"The model year of vehicle is invalid. Only it's permited until 5 years. The model actual is 2019"
```

#### 3.3 Validaciones correctas.
Si la información del vehículo es correcta, se inserta el vehículo y se devuelve un **201 Created**.

**Request**
```
POST /api/Vehicles
```
```json
{
  "vsn": "PDM-987",
  "modelBrand": "Nisan",
  "modelName": "Qashqai",
  "modelYear": 2022,
  "price": 50.00,
  "currency": "EUR"
}
```
**Reesponse**
```json
{
  "id": "ce066d33-98d2-42ae-9da9-ac17a78e7ad9",
  "vsn": "PDM-987",
  "modelName": "Qashqai",
  "modelYear": 2022,
  "price": 50,
  "currency": "EUR"
}
```

## Reservas
### 1. Obtener reserva
**GET /api/Bookings/id**
La aplicación intenta obtener la reserva de la memoria caché (redis), si la encuentra, devuelve un **204 OK** con la reserva cacheada. Pero, si la reserva no se encuentra en la memoría caché, entonces se busca la reserva en la base de datos. Si lo encuentra devuelve un **200 OK** con la información de la reserva.

**Request**
```
GET /api/Bookings/11F5015F-328B-49AA-9E7A-243055E4C6B5
```
**Response** 
```json
{
  "id": "11f5015f-328b-49aa-9e7a-243055e4c6b5",
  "vehicleId": "61064784-c820-4857-979d-9844b010eade",
  "userId": "c46443c2-f0de-4985-a3a5-c5413c802b8f",
  "startDate": "2026-03-10",
  "endDate": "2026-03-15",
  "totalPrice": 193,
  "status": "Pending"
}
```
Si la reserva no existe, se devuelve un **404 Not found**.

### 2. Crear nueva reserva 
**POST /api/Bookings**
#### 2.1 Usuario no encontrado.
La aplicación valida que el usuario exista, sino existe devuelve un **Not found 404** con un mensaje.

**Request** 
```
POST /api/Bookings
```
```json
{
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "vehicleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "startDate": "2026-03-10",
  "endDate": "2026-03-15"
}
```
**Response** 
```
"User not exists"
```

#### 2.2 Vehículo no encontrado.
La aplicación valida que el vehiculo exista, sino existe devuelve un **Not found 404**

**Request** 
```
POST /api/Bookings
```
```json
{
  "userId": "C46443C2-F0DE-4985-A3A5-C5413C802B8F",
  "vehicleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "startDate": "2026-03-10",
  "endDate": "2026-03-15"
}
```
**Response** 
```
"Vehicle not exists"
```

#### 2.3 Rango de fechas incorrecto.
La aplicación valida que la duración de la reserva sea correcta. es decir, que la fecha de inicio sea menor a la fecha de fin o que no sean iguales.

**Request**
```
POST /api/Bookings
```
```json
{
  "userId": "C46443C2-F0DE-4985-A3A5-C5413C802B8F",
  "vehicleId": "2283F042-882B-49AA-9EBA-2730F16D1F49",
  "startDate": "2026-03-16",
  "endDate": "2026-03-15"
}
```
**Response** 
```
"End date precedes start date"
```
o

**Request** 
```
POST /api/Bookings
```
```json
{
  "userId": "C46443C2-F0DE-4985-A3A5-C5413C802B8F",
  "vehicleId": "2283F042-882B-49AA-9EBA-2730F16D1F49",
  "startDate": "2026-03-15",
  "endDate": "2026-03-15"
}
```
**Response** 
```
"Start date cannot be equal to end date."
```

#### 2.4 Usuario con una reserva activa.
La aplicación valida si el usuario tiene una reserva ya activa en estado **pending** o **confirmed**, si tiene alguna en ese estatus, entonces no se le permite crear una nueva reserva. Se devuelve un **400 BadRequest** con un mensaje.

**Request** 
```
POST /api/Bookings
```
```json
{
  "userId": "C46443C2-F0DE-4985-A3A5-C5413C802B8F",
  "vehicleId": "ce066d33-98d2-42ae-9da9-ac17a78e7ad9",
  "startDate": "2026-03-20",
  "endDate": "2026-03-30"
}
```
**Response** 
```
"User already has an active booking"
```

#### 2.5 Validaciones correctas.
Si se pasan todas las validaciones, se crea entonces la reserva con estatus **pending**. 

**Request** 
```
POST /api/Bookings
```
```json
{
  "userId": "C46443C2-F0DE-4985-A3A5-C5413C802B8F",
  "vehicleId": "61064784-C820-4857-979D-9844B010EADE",
  "startDate": "2026-03-10",
  "endDate": "2026-03-15"
}
```
**Response** 
```json
{
  "id": "11f5015f-328b-49aa-9e7a-243055e4c6b5",
  "vehicleId": "61064784-c820-4857-979d-9844b010eade",
  "userId": "c46443c2-f0de-4985-a3a5-c5413c802b8f",
  "startDate": "2026-03-10",
  "endDate": "2026-03-15",
  "totalPrice": 193,
  "status": "Pending"
}
```

### 3. Pagar reserva 
**PUT /api/Bookings/{id}/Pay**
La aplicación valida el estatus de la reserva, si el status de la reserva es **pending** procesa el pago y revuelve un **200 OK**.

**Request** 
```
PUT /api/Bookings/11F5015F-328B-49AA-9E7A-243055E4C6B5/Pay
```
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "paymentDetails": {
    "paymentype": "CreditCard",
    "cardNumber": 12365479,
    "expirationDate": "2031-01-01"
  }
}
```
**Response** 
```
"Booking Paid sucessfully!"
```
**Nuevo status de la reserva luego del pago** 
```json
{
  "id": "11f5015f-328b-49aa-9e7a-243055e4c6b5",
  "vehicleId": "61064784-c820-4857-979d-9844b010eade",
  "userId": "c46443c2-f0de-4985-a3a5-c5413c802b8f",
  "startDate": "2026-03-10",
  "endDate": "2026-03-15",
  "totalPrice": 193,
  "status": "Confirmed"
}
```

si la reserva tiene un status distinto, entonces devuelve un **400 BadRequest** con un mensaje.

### 4. Cancelar reserva 
**PUT /api/Bookings/{id}/Cancel**
La aplicación Valida que el estatus de la reserva sea **pending** o **confirmed**. Si el status de la reserva es **pending** o **confirmed** la cancela y devuelve un **200 OK**.

**Request** 
```
PUT /api/Bookings/176E6BF0-130C-4F8C-B576-94432DC5D5AF/Cancel
```
**Response** 
```
"Booking cancelled ok!"
```
si la reserva tiene un status distinto, entonces devuelve un **400 BadRequest** con un mensaje.

**Request** 
```
PUT /api/Bookings/176E6BF0-130C-4F8C-B576-94432DC5D5AF/Cancel
```
**Response** 
```json
"Booking can not be canceled, because is not Confirmed",
```

### 5. Finalizar reserva
**PUT /api/Bookings/{id}/Finish**
La aplicación valida que el estatus de la reserva sea **confirmed**. Si el status de la reserva es **confirmed** la finaliza y revuelve un **200 OK**.

**Request** 
```
PUT /api/Bookings/11F5015F-328B-49AA-9E7A-243055E4C6B5/Finish
```
**Response** 
```
"Booking finished sucessfully!"
```

Si la reserva tiene un status distinto, entonces devuelve un **400 BadRequest**.

**Request** 
```
PUT /api/Bookings/11F5015F-328B-49AA-9E7A-243055E4C6B5/Finish
```
**Response** 
```
"Booking can not be finished, because is not Confirmed"
```

## Resultados de las pruebas
Información de la aplicación alojada en la base de datos SQL Server dentro del contenedor.  
Las tablas son `users`, `vehicles`, `bookings` y `payments`.

**Users**

| Id                                   | FirstName | LastName  | Email                        |
|--------------------------------------|-----------|-----------|------------------------------|
| 8AADFDF1-58AD-4AD9-B029-5C5529D02A56 | Test      | User      | TestUser@test.com           |
| C46443C2-F0DE-4985-A3A5-C5413C802B8F | Yansel    | Martínez  | YanselMartinez@test.com     |

**Vehicles**

| Id                                   | Model_Name | Model_Year | Vpn     | Price_Amount | Price_Currency | LastBookedOnUtc           | Model_Brand |
|--------------------------------------|------------|------------|---------|--------------|----------------|---------------------------|-------------|
| A7253349-1463-4589-827B-2436AD9F0F74 | Picanto    | 2021       | PKA-987 | 38.60        | EUR            | 0001-01-01 00:00:00.0000000 | Kia         |
| 9E36F048-021D-4D7C-8CD6-9185EC6C5D18 | Qashqai    | 2022       | AAA-123 | 50.00        | EUR            | 0001-01-01 00:00:00.0000000 | Nisan       |


**Bookings**

| Id                                   | VehicleId                             | UserId                                | Duration_StartDate | Duration_EndDate | PriceForPeriod_Amount | PriceForPeriod_Currency | TotalPrice_Amount | TotalPrice_Currency | Status | CreatedOnUtc               | FinishedOnUtc              | CanceledOnUtc              | ConfirmeddOnUtc            |
|--------------------------------------|---------------------------------------|---------------------------------------|--------------------|------------------|-----------------------|--------------------------|-------------------|---------------------|--------|----------------------------|----------------------------|----------------------------|----------------------------|
| 11F5015F-328B-49AA-9E7A-243055E4C6B5 | 61064784-C820-4857-979D-9844B010EADE | C46443C2-F0DE-4985-A3A5-C5413C802B8F | 2026-03-10         | 2026-03-15       | 193.00                | EUR                      | 193.00            | EUR                 | 3      | 2026-03-09 19:29:19.9565209 | 2026-03-09 19:52:06.7638161 | NULL                       | 2026-03-09 19:45:34.4793113 |
| 176E6BF0-130C-4F8C-B576-94432DC5D5AF | CE066D33-98D2-42AE-9DA9-AC17A78E7AD9 | 8AADFDF1-58AD-4AD9-B029-5C5529D02A56 | 2026-03-20         | 2026-03-30       | 500.00                | EUR                      | 500.00            | EUR                 | 2      | 2026-03-09 19:50:34.7008919 | NULL                       | 2026-03-09 19:53:19.2656661 | NULL                       |


**Payments**

| Id                                   | BookingId                             | PaymentType | PaidOnUtc                  |
|--------------------------------------|---------------------------------------|-------------|----------------------------|
| 6329D9F2-2F6F-4480-B8C4-B5565004B04C | 11F5015F-328B-49AA-9E7A-243055E4C6B5 | 0           | 2026-03-09 19:45:34.4796139 |



## Testing
### Prueba unitaria
Pruebas unitarias que validan dos casos de uso para crear una reserva.
```cs
        [Theory]
        [InlineData("2026-02-01", "2026-01-10")]
        [InlineData("2026-01-01", "2026-01-01")]
        public void CreateBookingShouldThrowAnExceptionwWhenInvalidDateRange(string startDate, string endDate)
        {
            // Arrange
            var start = DateOnly.Parse(startDate, CultureInfo.InvariantCulture);
            var end = DateOnly.Parse(endDate, CultureInfo.InvariantCulture);

            // Act
            var exception = Assert.Throws<BookingDateRangeException>(
                () => new DateRange(start, end));

            // Assert
            Assert.IsType<BookingDateRangeException>(exception);
        }

        /// <summary>
        /// CreateBookingShouldReturnANewBooking.
        /// </summary>
        [Fact]
        public void CreateBookingShouldReturnANewBooking()
        {
            // Arrange
            var user = User.Create(
                UserData.FirstName,
                UserData.LastName,
                UserData.Email);

            var price = new Money(
                10.0m,
                Currency.USD);

            var vehicle = VehicleData.Create(price);

            var duration = new DateRange(
                new DateOnly(2024, 1, 1),
                new DateOnly(2024, 1, 10));

            // Act
            var booking = Booking.Reserve(
                vehicle,
                user.Id,
                duration,
                DateTime.UtcNow);

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(vehicle);
            Assert.NotNull(booking);
            Assert.NotEqual(Guid.Empty, user.Id);
            Assert.NotEqual(Guid.Empty, vehicle.Id);
            Assert.NotEqual(Guid.Empty, booking.Id);
            Assert.Equal(BookingStatus.Pending, booking.Status);
        }
```

### Prueba de infraestructura
No implementadas en la solución, dado que, no entendí muy bien la estructura base que hay que usar para la implementar la prueba.

### Prueba funcional
No implementadas en la solución, dado que, no entendí muy bien la estructura base que hay que usar para la implementar la prueba.

### Mejoras a la aplicación
- Agregar autenticación y auitorización en los controladores para impedir el acceso anónimo o no pemritido
- Una vez hecho lo anterior, obtener dinámicamente el ID del usuario directamente del token en lugar de enviarlo en la request para realizar una reserva.
- Usar fluent validation para realizar validaciones también en la entrada del api.
- Implementar el paginado, filtrado y ordenamiento en el endpoint que devuelve de la lista de vehiculos.
- Usar autoMapper para los mapeaos entre clases (Request, input, response, etc).
- Implementart los tests funcionales y de infraestructura.