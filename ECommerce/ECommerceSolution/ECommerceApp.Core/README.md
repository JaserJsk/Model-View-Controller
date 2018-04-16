
The following code creates the catalog entities.

``` Catalog.cs 
public Guid Id { get; set; }
​
[Required]
[MaxLength(100)]
public string CatalogName { get; set; }
​
[Required]
[DataType(DataType.MultilineText)]
public string Description { get; set; }
​
public virtual ICollection<Category> Categories { get; set; }
```

This interface class contains all the methods for CRUD operations.

``` ICatalogRepository.cs 
void AddCatalog(string name , string description);
​
void UpdateCatalog(Guid Id, Catalog ca);
​
Catalog FindById(Guid Id);
​
void RemoveCatalog(Guid Id);
​
IEnumerable GetCatalogs();
```

***

The following code creates the category entities.

``` Category.cs 
public Guid Id { get; set; }
​
[Required]
[MaxLength(100)]
public string CategoryName { get; set; }
​
[Required]
[DataType(DataType.MultilineText)]
public string Description { get; set; }
​
[ForeignKey("Catalog")]
public Guid CatalogId { get; set; }
​
public virtual Catalog Catalog { get; set; }
​
public virtual ICollection<Product> Products { get; set; }
```

This interface class contains all the methods for CRUD operations.

``` ICategoryRepository.cs 
void AddCategory(string name , string description);
​
void UpdateCategory(Guid Id, Category ca);
​
Category FindById(Guid Id);
​
void RemoveCategory(Guid Id);
​
IEnumerable GetCategories();
```

***

The following code creates the product entities.

``` Category.cs 
public Guid Id { get; set; }
​
[Required]
public string Article { get; set; }
​
[Required]
[MaxLength(100)]
public string ProductName { get; set; }
​
[Required]
[DataType(DataType.MultilineText)]
public string Description { get; set; }
​
[Required]
public decimal Price { get; set; }
​
public decimal PriceWithTax
{
    get
    {
        return Price * 1.125m;
    }
}
​
[Required]
public bool InStock { get; set; }
​
[ForeignKey("Category")]
public Guid CategoryId { get; set; }
​
public virtual Category Category { get; set; }
​
public virtual ICollection<File> Files { get; set; }
```

This interface class contains all the methods for CRUD operations.

``` ICategoryRepository.cs 
void AddProduct(string article , string name , string description , decimal price , bool instock);
​
void UpdateProduct(Guid Id , Product pr);
​
Product FindById(Guid Id);
​
void RemoveProduct(Guid Id);
​
IEnumerable GetProducts();
```