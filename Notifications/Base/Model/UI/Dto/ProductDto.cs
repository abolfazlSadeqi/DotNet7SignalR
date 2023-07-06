namespace Model;

public class ProductDto
{


   
    public int ID { set; get; }
    public string ProductName { set; get; }
    public string CategoryName { set; get; }
    public string Url { set; get; }
    public string Price { set; get; }
    public DateTime ModifiedDate { set; get; }
    public DateTime CreateDate { set; get; }


}
