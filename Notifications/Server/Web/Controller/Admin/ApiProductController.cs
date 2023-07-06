
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Model;
using Microsoft.AspNetCore.SignalR;
using API.Signalr;
using Contract.Repository;

namespace API.Controller.Admin;

[ApiController]
[Route("[controller]")]
public class ApiProductController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHubContext<ShopNotificationHub> _notificationHubContext;
    public ApiProductController(IUnitOfWork unitOfWork, IMapper mapper, IHubContext<ShopNotificationHub> notificationHubContext)
    {
        this.unitOfWork = unitOfWork;
        _mapper = mapper;
        _notificationHubContext = notificationHubContext;

    }


    [HttpGet]
    [Route("GetAllProducts")]
    public IActionResult GetAllProducts() => Ok(unitOfWork.Product.GetAll());

    [HttpGet]
    [Route("GetByIdProducts")]
    public IActionResult GetByIdProducts(int Id) => Ok(unitOfWork.Product.GetById(Id));




    [HttpPost]
    [Route("InsertToProducts")]
    public IActionResult InsertToProducts(ProductDto Product)
    {

        var newProduct = _mapper.Map<Product>(Product);
        unitOfWork.Product.Add(newProduct);

        unitOfWork.Save();

        _notificationHubContext.Clients.All.SendAsync("getproduct", newProduct.ProductName, newProduct.CategoryName, newProduct.Price);

        return Ok(newProduct);
    }




}
