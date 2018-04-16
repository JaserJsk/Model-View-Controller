
First make sure that the correct ```data source & initial catalog``` is configured.

``` Web.config
<connectionStrings>
    <add name="ECommerceAppConnectionString" connectionString="Trusted_Connection=yes; Persist Security Info=True; 
    data source=DESKTOP-LM7PGQ6; initial catalog=ECommerceDB; Multipleactiveresultsets=true;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

The following code creates a new catalog item.

``` CatalogsController.cs 
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,CatalogName,Description")] Catalog catalog)
{
    if (ModelState.IsValid)
    {
        catalog.Id = Guid.NewGuid();
        db.Catalogs.Add(catalog);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
​
    return View(catalog);
}
```

The following code displays selected catalog details.

``` CatalogsController.cs 
public ActionResult Details(Guid? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Catalog catalog = db.Catalogs.Find(id);
    if (catalog == null)
    {
        return HttpNotFound();
    }
    
    return View(catalog);
}
```

The following code edits selected catalog item.

``` CatalogsController.cs 
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "Id,CatalogName,Description")] Catalog catalog)
{
    if (ModelState.IsValid)
    {
        db.Entry(catalog).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
​
    return View(catalog);
}
```

The following code deletes selected catalog item.

``` CatalogsController.cs 
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(Guid id)
{
    Catalog catalog = db.Catalogs.Find(id);
    db.Catalogs.Remove(catalog);
    db.SaveChanges();
    return RedirectToAction("Index");
}
```

***

The following code creates a new category item.

``` CategoriesController.cs 
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,CategoryName,Description,CatalogId")] Category category)
{
    if (ModelState.IsValid)
    {
        category.Id = Guid.NewGuid();
        db.Categories.Add(category);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
​
    ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "CatalogName", category.CatalogId);
    return View(category);
}
```

The following code displays selected category details.

``` CategoriesController.cs 
public ActionResult Details(Guid? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Category category = db.Categories.Find(id);
    if (category == null)
    {
        return HttpNotFound();
    }
    
    return View(category);
}
```

The following code edits selected category item.

``` CategoriesController.cs 
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "Id,CategoryName,Description,CatalogId")] Category category)
{
    if (ModelState.IsValid)
    {
        db.Entry(category).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "CatalogName", category.CatalogId);
    return View(category);
}
```

The following code deletes selected category item.

``` CategoriesController.cs 
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(Guid id)
{
    Category category = db.Categories.Find(id);
    db.Categories.Remove(category);
    db.SaveChanges();
    return RedirectToAction("Index");
}
``

***

The following code creates a new product item.

``` ProductsController.cs 
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,Article,ProductName,Description,Price,InStock,CategoryId")] Product product)
{
    if (ModelState.IsValid)
    {
        product.Id = Guid.NewGuid();
        db.Products.Add(product);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
​
        ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
        return View(product);
}
```

The following code displays selected product details.

``` ProductsController.cs 
public ActionResult Details(Guid? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Product product = db.Products.Find(id);
    if (product == null)
    {
        return HttpNotFound();
    }
    
    return View(product);
}
```

The following code edits selected product item.

``` ProductsController.cs 
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "Id,Article,ProductName,Description,Price,InStock,CategoryId")] Product product)
{
    if (ModelState.IsValid)
    {
        db.Entry(product).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
    return View(product);
}
```

The following code deletes selected product item.

``` ProductsController.cs 
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(Guid id)
{
    Product product = db.Products.Find(id);
    db.Products.Remove(product);
    db.SaveChanges();
    return RedirectToAction("Index");
}
``