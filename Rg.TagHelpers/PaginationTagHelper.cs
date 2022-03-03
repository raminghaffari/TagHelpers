namespace Rg.TagHelpers
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Rg.TagHelpers.Utilities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PaginationTagHelper" />.
    /// </summary>
    [HtmlTargetElement("Paging-Tag")]
    public class PaginationTagHelper : TagHelper
    {
        /// <summary>
        /// Defines the _utilities.
        /// </summary>
        private readonly PaginationTagHelper_Utilities _utilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationTagHelper"/> class.
        /// </summary>
        public PaginationTagHelper()
        {
            _utilities = new PaginationTagHelper_Utilities();
        }

        /// <summary>
        /// Gets or sets the RgTotalRecord
        /// total count of record in the database
        /// <para> default = 100 </para>
        /// <para> exampel = 100 </para>..
        /// </summary>
        public long RgTotalRecord { get; set; } = 100;

        /// <summary>
        /// Gets or sets the RgPageIndex
        /// current page number
        /// <para> default = 1 </para>
        /// <para> exampel = 1 </para>..
        /// </summary>
        public int RgPageIndex { get; set; } = 1;

        /// <summary>
        /// Gets or sets the RgPageSize
        /// how many item want get from database per page
        /// <para> default = 20 </para>
        /// <para> exampel = 20 </para>..
        /// </summary>
        public int RgPageSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets the RgMaxPage
        /// how many active page number icon want show in pagination UI 
        /// <para> default = 5 </para>
        /// <para> exampel = 5 </para>..
        /// </summary>
        public int RgMaxPage { get; set; } = 5;

        /// <summary>
        /// Gets or sets a value indicating whether RgShowPageSizeNav
        /// the boolean parameter for showing page size navbar or not
        /// <para> true : Show , false : dont show </para>
        /// <para> default : false </para>..
        /// </summary>
        public bool RgShowPageSizeNav { get; set; } = false;

        /// <summary>
        /// Gets or sets the RgQueryStringKeyPageNo
        /// the key for current page query string
        /// <para> default = pageindex </para>
        /// <para> exampel = pageindex </para>..
        /// </summary>
        public string RgQueryStringKeyPageNo { get; set; } = "pageindex";

        /// <summary>
        /// Gets or sets the RgQueryStringKeyPageSize
        /// the key for pagesize query string
        /// <para> default = pageindex </para>
        /// <para> exampel = pageindex </para>..
        /// </summary>
        public string RgQueryStringKeyPageSize { get; set; } = "pagesize";

        /// <summary>
        /// Process creating tag helper.
        /// </summary>
        /// <param name="context">.</param>
        /// <param name="output">.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "Paging";
            output.Content.AppendHtml(GetContent());
        }

        /// <summary>
        /// create pagination taghelper content.
        /// </summary>
        /// <returns> string content .</returns>
        private string GetContent()
        {
            PaginationPager Pager = new PaginationPager(RgTotalRecord, RgPageIndex, RgPageSize, RgMaxPage);

            string content = "";

            //--> Row-In-Main-Div
            var Rowdiv = _utilities.Create_Tag_div("row align-items-center");

            #region Page_Of_Pages
            //--> First-Col-In-Row
            var First_col_of_row = _utilities.Create_Tag_div("col-sm-12 col-md-2");

            ////----> Page-Of-Pages-In_First-Col-In-Row
            var Page_of_pages_Div = _utilities.Create_Tag_div("pagination-box");
            Page_of_pages_Div.InnerHtml.SetContent($@"صفحه {RgPageIndex} از {Pager.TotalPages}");
            First_col_of_row.InnerHtml.AppendHtml(Page_of_pages_Div);
            #endregion

            #region Paginat_Number
            //--> Second-Col-In-Row
            var Second_col_of_row = _utilities.Create_Tag_div("col-sm-12 col-md-7");
            Second_col_of_row.AddCssClass("text-center");

            ////----> Paginat-Number-In-Second-Col-In-Row
            var Paginat_Number_Div = _utilities.Create_Tag_div("paginating-container pagination-solid");

            //////------> Ul-In_Paginate_Nuumber
            var Pagination_Ul = _utilities.Create_Tag_ul("pagination");

            ////////--------> Li_In_Ul_Paginat_Number

            string PageSize_Query = $"{RgQueryStringKeyPageSize}={RgPageSize}";

            //////////----------> Prev button
            var PreNumberLi = _utilities.Create_Tag_li_with_inner_tag_a
                (
                $@"<svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'
                   stroke='currentColor' stroke-width ='2' stroke-linecap='round' stroke-linejoin='round'
                   class='feather feather-arrow-left'>
                   <line x1='19' y1='12' x2='5' y2='12'></line>
                   <polyline points='12 19 5 12 12 5'></polyline>
                  </svg>",
                $"?{RgQueryStringKeyPageNo}={RgPageIndex - 1}&&{PageSize_Query}",
                "page-link",
                "paginate_button page-item prev"
                );

            if (RgPageIndex == 1)
            {
                PreNumberLi.AddCssClass("disabled");
            }

            Pagination_Ul.InnerHtml.AppendHtml(PreNumberLi);

            ////////////-------------> Number button
            foreach (var item in Pager.Pages)
            {
                var NumberLi = _utilities.Create_Tag_li_with_inner_tag_a
                    (
                     $"{item}",
                     $"?{RgQueryStringKeyPageNo}={item}&&{PageSize_Query}",
                     "page-link",
                     "paginate_button page-item "
                    );
                if (item == RgPageIndex)
                {
                    NumberLi.AddCssClass("active");
                }
                Pagination_Ul.InnerHtml.AppendHtml(NumberLi);
            }


            //////////////--------------> Next button
            var NextNumberLi = _utilities.Create_Tag_li_with_inner_tag_a(
                $@"<svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'
                   stroke='currentColor' stroke-width ='2' stroke-linecap='round' stroke-linejoin='round'
                   class='feather feather-arrow-right'>
                   <line x1 ='5' y1='12' x2='19' y2='12'></line>
                   <polyline points='12 5 19 12 12 19'></polyline>
                  </svg>",
                 $"?{RgQueryStringKeyPageNo}={RgPageIndex + 1}&&{PageSize_Query}",
                "page-link",
                "paginate_button page-item next"
                );

            if (RgPageIndex == Pager.TotalPages)
            {
                NextNumberLi.AddCssClass("disabled");
            }
            Pagination_Ul.InnerHtml.AppendHtml(NextNumberLi);



            //---> Merg
            Paginat_Number_Div.InnerHtml.AppendHtml(Pagination_Ul);
            Second_col_of_row.InnerHtml.AppendHtml(Paginat_Number_Div);
            #endregion

            #region Page_Size
            //-->Third-Col-In-Row
            var Third_col_of_row = _utilities.Create_Tag_div("col-sm-12 col-md-3");

            if (RgShowPageSizeNav)
            {

                ////---->Page-Size-Dropdown
                var Page_Size_Dropdown_Div = _utilities.Create_Tag_div("dropdown pagination-pagesize-btn");

                //////-------->Page-Size-Lable
                var Page_Size_Label = _utilities.Create_Tag_label("نمایش :");

                ////////-------->Page-Size-Dropdown-Btn
                var Page_Size_DropDown_Btn = _utilities.Create_Tag_button
                    (

                    "page-size-btn btn dropdown-toggle",
                    new Dictionary<string, string> {
                        { "type", "button" },
                        {"id", "Page-Size-Menu"},
                        {"data-toggle", "dropdown"},
                        {"aria-haspopup", "true"},
                        { "aria-expanded", "false"},

                    },
                    $"{ RgPageSize}"
                    );
                Page_Size_Dropdown_Div.InnerHtml.AppendHtml(Page_Size_DropDown_Btn);



                //////////-->Page-Size-SelectList-Option

                var Page_Size_Dropdown_menu_Div = _utilities.Create_Tag_div("dropdown-menu pagination-pagesize-droodown");
                Page_Size_Dropdown_menu_Div.MergeAttribute("aria-labelledby", "Page-Size-Menu");

                var PageSize_List = new List<int> { 5, 10, 15, 20, 50 };

                if (!PageSize_List.Contains(RgPageSize))
                {
                    PageSize_List.Add(RgPageSize);
                }
                foreach (var item in PageSize_List)
                {
                    var Page_Size_Dropdown_menu_Item = _utilities.Create_Tag_a("dropdown-item", "#", item.ToString());
                    Page_Size_Dropdown_menu_Div.InnerHtml.AppendHtml(Page_Size_Dropdown_menu_Item);
                }

                Page_Size_Dropdown_Div.InnerHtml.AppendHtml(Page_Size_Dropdown_menu_Div);


                Third_col_of_row.InnerHtml.AppendHtml(Page_Size_Dropdown_Div);
            }

            #endregion


            ///-----> Merg All Col
            Rowdiv.InnerHtml.AppendHtml(First_col_of_row);
            Rowdiv.InnerHtml.AppendHtml(Second_col_of_row);
            Rowdiv.InnerHtml.AppendHtml(Third_col_of_row);
            content = content + _utilities.ConvertHtmlToString(Rowdiv);
            return content;

        }
    }
}
