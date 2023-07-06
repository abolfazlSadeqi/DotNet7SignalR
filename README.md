# Overview

There is a very esay simple application(show product to all client when product insert)  signalr and .Net7

## SignalR
ASP.NET Core SignalR is a library that simplifies adding real-time web functionality to apps. It uses WebSockets whenever possible.

### hubs
SignalR uses hubs to communicate between clients and servers.
A hub is a high-level pipeline that allows a client and server to call methods on each other.
Hubs call client-side code by sending messages that contain the name and parameters of the client-side method. Objects sent as method parameters are deserialized using the configured protocol. The client tries to match the name to a method in the client-side code. When the client finds a match, it calls the method and passes to it the deserialized parameter data.

### Authenticate users connecting to a SignalR hub
SignalR can be used with ASP.NET Core authentication to associate a user with each connection.

### Tech Specification
|Tech Specification|
|--|
|SignalR|
|EFCore7|
|MVC|
|Net7|

## Steps

### 1.Install package on Nuget

Microsoft.AspNet.SignalR.Core

### 2.Create and use hubs
```
public class ShopNotificationHub : Hub
{
}
```

### 3. Enable SignalR and Configure in startup or program file
```
// Enable SignalR
 services.AddSignalR();

//add Configure(add hub)
    
app.UseEndpoints(endpoints =>
        {
            
            endpoints.MapHub<ShopNotificationHub>("/ShopNotificationHub");
        });

```


### 4.set Configure Controller(use Hubs)
```
private readonly IHubContext<ShopNotificationHub> _notificationHubContext;
public ApiProductController(IHubContext<ShopNotificationHub> notificationHubContext)
    {
        _notificationHubContext = notificationHubContext;

    }
```

### 5.call method in action

Example(Call Method getproduct for All Clients)
```
_notificationHubContext.Clients.All.SendAsync("getproduct", newProduct.ProductName, newProduct.CategoryName, newProduct.Price);
```

### Config Client

### 6.Add microsoft/signalr on the client

### 7. add Code View
```

<div id="ShopList"></div>
<script src="~/js/shopnotification/shopnotifications.js"></script>
<script src="~/lib/microsoft-signalr/signalr.min.js"></script>

```

### 8. Implementation function to get product(use Hub and use product data)

```
"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/ShopNotificationHub").build();
connection.on("getproduct", ( ProductName, CategoryName, Price) => {
    var div = "<tr>"; 
    div = div + "<td>" + ProductName + "</td>";
    div = div + "<td>" + CategoryName + "</td>";
    div = div + "<td>" + Price + "</td>";div = div + " </tr>";
    $('#ShopList').append(div); 
});


connection.start().catch(function (err) {
    return console.error(err.toString());
});
```

