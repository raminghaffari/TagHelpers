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


        #region setting
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
        /// Gets or sets a value indicating whether RgShowFirstLastButton
        /// the boolean parameter for showing first page && Last page buttons or not
        /// <para> true : Show , false : dont show </para>
        /// <para> default : false </para>..
        /// </summary>
        public bool RgShowFirstLastButton { get; set; } = false;

        /// <summary>
        /// get string number list like example and set in page size dropdown item
        /// <para> exaple : "5,10,15,20,50" </para>
        /// <para> default : "5,10,15,20,50" </para>..
        /// </summary>
        public string RgPageSizeDropdownItems { get; set; } = $@"5,10,15,20,50";
        /// <summary>
        /// the boolean parameter for dark theme
        /// if set true pagination dark mode is active
        /// <para>defult : false</para>
        /// </summary>
        public bool RgDarkMode { get; set; } = false;

        /// <summary>
        /// the boolean parameter for set rtl direction
        /// if set true pagination rtl direction is active
        /// <para>defult : false</para>
        /// </summary>
        public bool RgRtlDirection { get; set; } = false;
        #endregion

        #region text
        /// <summary>
        /// Gets or sets the RgPageSizeLabelText
        /// text of pagesize label 
        /// <para> default = "PageSize" </para>
        /// <para> exampel = "PageSize" </para>..
        /// </summary>
        public string RgPageSizeLabelText { get; set; } = "PageSize";

        /// <summary>
        /// Gets or sets the RgPageOfPagesText
        /// text for Page Of Pages box
        /// <para> default = "Page,Of" </para>
        /// <para> exampel = "Page,Of" </para>..
        /// </summary>
        public string RgPageOfPagesText { get; set; } = "Page,Of";


        #endregion

        #region QueryString
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
        #endregion


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

            //--> svg-icon
            var FirstPageNumberLi_Icon = SVGIcons.Chevron_double_left;
            var LastPageNumberLi_Icon = SVGIcons.Chevron_double_right;
            var PrevPageNumberLi_Icon = SVGIcons.Chevron_left;
            var NextPageNumberLi_Icon = SVGIcons.Chevron_right;



            //--> Row-In-Main-Div
            var Rowdiv = _utilities.Create_Tag_div("row align-items-center");

            ////----> dark-mode
            if (RgDarkMode)
            {
                Rowdiv.AddCssClass("pagination-dark");
            }

            //////------> rtl-direction
            if (RgRtlDirection)
            {
                Rowdiv.AddCssClass("rtldirection");
                FirstPageNumberLi_Icon = SVGIcons.Chevron_double_right;
                LastPageNumberLi_Icon = SVGIcons.Chevron_double_left;
                PrevPageNumberLi_Icon = SVGIcons.Chevron_right;
                NextPageNumberLi_Icon = SVGIcons.Chevron_left;
            }

            #region Page_Of_Pages
            //--> First-Col-In-Row
            var First_col_of_row = _utilities.Create_Tag_div("col-sm-12 col-md-2");

            ////----> Page-Of-Pages-In_First-Col-In-Row
            var Page_of_pages_Div = _utilities.Create_Tag_div("pagination-box");

            var Page_of_Pages_text = RgPageOfPagesText.Split(",");

            try
            {
                Page_of_pages_Div.InnerHtml.SetContent($@"{Page_of_Pages_text[0]} {RgPageIndex} {Page_of_Pages_text[1]} {Pager.TotalPages}");
            }
            catch (System.Exception)
            {

                Page_of_pages_Div.InnerHtml.SetContent($@"Page {RgPageIndex} Of {Pager.TotalPages}");
            }

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



            //////////----------> FirstPage button
            var FirstPageNumberLi = _utilities.Create_Tag_li_with_inner_tag_a
                (
                FirstPageNumberLi_Icon,
                $"?{RgQueryStringKeyPageNo}=1&&{PageSize_Query}",
                "page-link",
                "paginate_button page-item prev"
                );

            if (RgShowFirstLastButton)
            {
                Pagination_Ul.InnerHtml.AppendHtml(FirstPageNumberLi);
            }

            //////////----------> Prev button
            var PreNumberLi = _utilities.Create_Tag_li_with_inner_tag_a
                (
                PrevPageNumberLi_Icon,
                $"?{RgQueryStringKeyPageNo}={RgPageIndex - 1}&&{PageSize_Query}",
                "page-link",
                "paginate_button page-item prev"
                );

            if (RgPageIndex == 1)
            {
                PreNumberLi.AddCssClass("disabled");
                FirstPageNumberLi.AddCssClass("disabled");
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
                NextPageNumberLi_Icon,
                 $"?{RgQueryStringKeyPageNo}={RgPageIndex + 1}&&{PageSize_Query}",
                "page-link",
                "paginate_button page-item next"
                );

            Pagination_Ul.InnerHtml.AppendHtml(NextNumberLi);


            //////////////--------------> LastPage button
            var LastPageButton = _utilities.Create_Tag_li_with_inner_tag_a(
                LastPageNumberLi_Icon,
                 $"?{RgQueryStringKeyPageNo}={Pager.TotalPages}&&{PageSize_Query}",
                "page-link",
                "paginate_button page-item next"
                );

            if (RgShowFirstLastButton)
            {
                Pagination_Ul.InnerHtml.AppendHtml(LastPageButton);
            }


            if (RgPageIndex == Pager.TotalPages)
            {
                NextNumberLi.AddCssClass("disabled");
                LastPageButton.AddCssClass("disabled");
            }




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
                var Page_Size_Label = _utilities.Create_Tag_label($"{RgPageSizeLabelText} :");
                Page_Size_Dropdown_Div.InnerHtml.AppendHtml(Page_Size_Label);

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



                //////////-->Page-Size-Dropdown-items

                var Page_Size_Dropdown_menu_Div = _utilities.Create_Tag_div("dropdown-menu pagination-pagesize-dropdown");
                Page_Size_Dropdown_menu_Div.MergeAttribute("aria-labelledby", "Page-Size-Menu");

                List<int> PageSize_Item_List = new List<int>();
                try
                {
                    foreach (var item in RgPageSizeDropdownItems.Split(","))
                    {
                        PageSize_Item_List.Add(int.Parse(item));
                    }
                }
                catch (System.Exception)
                {
                    PageSize_Item_List = new List<int>() { 5, 10, 15, 20, 50 };
                }

                if (!PageSize_Item_List.Contains(RgPageSize))
                {
                    PageSize_Item_List.Add(RgPageSize);
                }

                PageSize_Item_List.Sort();
                foreach (var item in PageSize_Item_List)
                {
                    var Page_Size_Dropdown_menu_Item = _utilities.Create_Tag_a("dropdown-item", $"?{RgQueryStringKeyPageSize}={item}", item.ToString());
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
