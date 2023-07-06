using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class Product
{

    [Key]
    public int ID { set; get; }
    public string ProductName { set; get; }
    public string CategoryName { set; get; }
    public string Url { set; get; }
    public string Price { set; get; }
    public DateTime ModifiedDate { set; get; }
    public DateTime CreateDate { set; get; }


}
