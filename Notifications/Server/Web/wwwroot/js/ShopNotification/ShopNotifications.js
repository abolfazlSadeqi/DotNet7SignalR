"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/ShopNotificationHub").build();
connection.on("getproduct", ( ProductName, CategoryName, Price) => {
    var div = "<tr>";
   

    div = div + "<td>" + ProductName + "</td>";
    div = div + "<td>" + CategoryName + "</td>";

    div = div + "<td>" + Price + "</td>";
    div = div + " </tr>";


    $('#ShopList').append(div);


});


connection.start().catch(function (err) {
    return console.error(err.toString());
});