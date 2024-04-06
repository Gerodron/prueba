using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.API;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Persistence.Database;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using AutoMapper;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Microsoft.AspNetCore.Http.HttpResults;
using Tarker.Booking.Application.Database.User.Queries.GetAllUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserById;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Database.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Commands.DeleteCustomer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

#region API Usuarios
app.MapPost("insertar-user", async (ICreateUserCommand service) =>
{
    try
    {
        var entity1 = new CreateUserModel()
        {
            FirstName = "Miguel",
            LastName = "Consuegra",
            UserName = "Tarker_223",
            PassWord = "Tarker_324"
        };

        var entity2 = new CreateUserModel()
        {
            FirstName = "Alejandro",
            LastName = "Gonz�lez",
            UserName = "AG_123",
            PassWord = "AG_321"
        };

        var entity3 = new CreateUserModel()
        {
            FirstName = "Mar�a",
            LastName = "L�pez",
            UserName = "ML_456",
            PassWord = "ML_654"
        };

        var entity4 = new CreateUserModel()
        {
            FirstName = "Juan",
            LastName = "P�rez",
            UserName = "JP_789",
            PassWord = "JP_987"
        };

        await service.Execute(entity1);
        await service.Execute(entity2);
        await service.Execute(entity3);
        await service.Execute(entity4);
        return Results.Ok("Se guardaron los cambios");
    }
    catch (AutoMapperMappingException ex)
    {
        Console.WriteLine($"Error de mapeo de AutoMapper: {ex.Message}");
        return Results.Json(new { error = "Error de mapeo de AutoMapper" }, statusCode: StatusCodes.Status400BadRequest);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se produjo un error durante la ejecuci�n: {ex.Message}");
        return Results.Json(new { error = "Se produjo un error durante la ejecuci�n" }, statusCode: StatusCodes.Status500InternalServerError);
    }
});
app.MapDelete("eliminar-user", async (IDeleteUserCommand service) =>
{
    await service.Execute(2);

});
app.MapPut("actualizar-user", async (IUpdateUserCommand service) =>
{
    var entity = new UpdateUserModel()
    {
        UserId = 3,
        FirstName = "Miguel",
        LastName = "Consuegra",
        PassWord = "1234",
        UserName = "Gerodron"
    };

    await service.Execute(entity);
});
app.MapPut("actualizar-user-password", async (IUpdateUserPasswordCommand service) =>
{
    var entity = new UpdateUserPasswordModel()
    {
        UserId  = 4,
        Password = $"Se cambio la contrase�a  [{DateTime.Now}] "
    };

    await service.Execute(entity);

    return Results.Ok("Se cambio la contrase�a exitosamente");
});
app.MapGet("get-all-user-list", async (IGetAllUserQuery service) =>
{
    return Results.Ok(await service.Execute());
});
app.MapGet("get-user-by-id", async (IGetUserByIdQuery service) =>
{
    return Results.Ok(await service.Execute(7));
});
app.MapGet("get-user-by-username-and-password", async (IGetUserByUserNameAndPasswordQuery service) =>
{
    return Results.Ok(await service.Execute("JP_789", "JP_987"));
});
#endregion

app.MapPost("insertar-cliente", async (ICreateCustomerCommand service) => 
{
    var entity1 = new CreateCustomerModel()
    {
        FullName = "Ana Garc�a",
        DocumentNumber = "12345678"
    };

    var entity2 = new CreateCustomerModel()
    {
        FullName = "Pedro P�rez",
        DocumentNumber = "87654321"
    };

    var entity3 = new CreateCustomerModel()
    {
        FullName = "Mar�a Rodr�guez",
        DocumentNumber = "55555555"
    };

    var entity4 = new CreateCustomerModel()
    {
        FullName = "Luisa Mart�nez",
        DocumentNumber = "11111111"
    };

    await service.Execute(entity1);
    await service.Execute(entity2);
    await service.Execute(entity3);
    await service.Execute(entity4);

    return Results.Ok("OK");
});
app.MapPut("actualizar-cliente", async (IUpdateCustomerCommand service) =>
{
    var entity = new UpdateCustomerModel()
    {
        CustomerId = 5,
        FullName = "CONSUEGRA MORAN SAUL SEBASTIAN",
        DocumentNumber = "99991243"
    };

    return Results.Ok(await service.Execute(entity));
});
app.MapDelete("remover-cliente", async (IDeleteCustomerCommand service) =>
{
    var customerId = 5;

    return Results.Ok(await service.Execute(customerId));
});

app.Run();
