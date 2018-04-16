
First make sure to add a reference to the core project.

Make sure that the correct ```data source & initial catalog``` is configured.

``` App.config
<connectionStrings>
    <add name="ECommerceAppConnectionString" connectionString="Trusted_Connection=yes; Persist Security Info=True; 
    data source=DESKTOP-LM7PGQ6; initial catalog=ECommerceDB; Multipleactiveresultsets=true;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

The following code creates a new catalog item.

``` ECommerceContext.cs 
public ECommerceContext() : base("name=ECommerceAppConnectionString")
{
    this.Configuration.LazyLoadingEnabled = false;
}
​
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
}
​
public virtual DbSet<Catalog> Catalogs { get; set; }
​
public virtual DbSet<Category> Categories { get; set; }
​
public virtual DbSet<Product> Products { get; set; }
​
public virtual DbSet<File> Files { get; set; }
```