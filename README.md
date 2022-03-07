# Rg.TagHelpers
## what is it?
useful TagHelpers for any ASP.NET Core project.
### Pagination TagHelper
Create a pagination control styled with bootstrap 4.x && 5.x using simple html tag
````html
<Paging-Tag rg-total-record="@Model.totalrow"
            rg-page-index="@Model.pageindex"
            rg-page-size="@Model.pagesize">
</Paging-Tag>
````

Dark Mode

![PagingTagHelper default](https://raw.githubusercontent.com/raminghaffari/upload/main/taghelper/paginationdarkmode.png)

Persian Language And RTL Direction

![PagingTagHelper default](https://raw.githubusercontent.com/raminghaffari/upload/main/taghelper/paginationlightmode.png)
