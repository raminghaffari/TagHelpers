# Rg.TagHelpers
## what is it?
useful TagHelpers for any ASP.NET Core project.

### Installation:
Install via nuget package manager :
````html
PM> Install-Package Rg.TagHelpers -Version 1.2.0
````
Then add to _ViewImports.cshtml :
````html
 @addTagHelper *, Rg.TagHelpers
````
Then Add RgPagination.css Link To <Head> Section HTML Page.
````html
<Link href="~/css/RgPagination.css" rel="stylesheet"/>
````
![PagingTagHelper default](https://raw.githubusercontent.com/raminghaffari/raminghaffari/main/Upload/RgPaginationCss.png)            
### Pagination TagHelper
Create a pagination control styled with bootstrap 4.x && 5.x using simple html tag
````html
<Paging-Tag rg-total-record="@Model.totalrow"
            rg-page-index="@Model.pageindex"
            rg-page-size="@Model.pagesize">
</Paging-Tag>
````

Dark Mode

![PagingTagHelper default](https://raw.githubusercontent.com/raminghaffari/raminghaffari/main/Upload/paginationdarkmode.png)

Persian Language And RTL Direction

![PagingTagHelper default](https://raw.githubusercontent.com/raminghaffari/raminghaffari/main/Upload/paginationlightmode.png)
